// Copyright (C) 2004-2005 MySQL AB
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License version 2 as published by
// the Free Software Foundation
//
// There are special exceptions to the terms and conditions of the GPL 
// as it is applied to this software. View the full text of the 
// exception in file EXCEPTIONS in the directory of this software 
// distribution.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using NUnit.Framework;

namespace MySql.Data.MySqlClient.Tests
{
	/// <summary>
	/// Summary description for ConnectionTests.
	/// </summary>
	[TestFixture] 
	public class DataReaderTests : BaseTest
	{
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			Open();
		}

		[TestFixtureTearDown]
		public void TestFixtureTearDown() 
		{
			Close();
		}

		[SetUp]
		protected override void Setup()
		{
			base.Setup();
			execSQL("DROP TABLE IF EXISTS Test");
			execSQL("CREATE TABLE Test (id INT NOT NULL, name VARCHAR(100), d DATE, dt DATETIME, b1 LONGBLOB, PRIMARY KEY(id))");
		}


		[Test]
		public void TestMultipleResultsets()
		{
			MySqlDataReader reader =null;
			try 
			{
				MySqlCommand cmd = new MySqlCommand("", conn);
				// insert 100 records
				cmd.CommandText = "INSERT INTO Test (id,name) VALUES (?id, 'test')";
				cmd.Parameters.Add( new MySqlParameter("?id", 1));
				for (int i=1; i <= 100; i++)
				{
					cmd.Parameters[0].Value = i;
					cmd.ExecuteNonQuery();
				}
				
				// execute it one time
				cmd = new MySqlCommand("SELECT id FROM Test WHERE id<50; SELECT * FROM Test WHERE id >= 50;", conn);
				reader = cmd.ExecuteReader();
				Assert.IsNotNull( reader );
				Assert.AreEqual( true, reader.HasRows );
				Assert.IsTrue( reader.Read() );
				Assert.AreEqual( 1, reader.FieldCount );
				Assert.IsTrue( reader.NextResult() );
				Assert.AreEqual( true, reader.HasRows );
				Assert.AreEqual( 5, reader.FieldCount );
				reader.Close();

				// now do it again
				reader = cmd.ExecuteReader();
				Assert.IsNotNull( reader );
				Assert.AreEqual( true, reader.HasRows );
				Assert.IsTrue( reader.Read() );
				Assert.AreEqual( 1, reader.FieldCount );
				Assert.IsTrue( reader.NextResult() );
				Assert.AreEqual( true, reader.HasRows );
				Assert.AreEqual( 5, reader.FieldCount );
				reader.Close();
			}
			catch (Exception ex)
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		[Test()]
		public void TestNotReadingResultset()
		{
			for (int x=0; x < 10; x++)
			{
				MySqlConnection c = new MySqlConnection( conn.ConnectionString + ";pooling=false" );
				c.Open();

				MySqlCommand cmd = new MySqlCommand("INSERT INTO Test (id, name, b1) VALUES(?val, 'Test', NULL)", c);
				cmd.Parameters.Add( new MySqlParameter("?val", x));
				int affected = cmd.ExecuteNonQuery();
				Assert.AreEqual( 1, affected );

				cmd = new MySqlCommand("SELECT * FROM Test", c);
				cmd.ExecuteReader();
				c.Close();
			}
		}

		[Test()]
		public void GetBytes()
		{
			int len = 50000;
			byte[] bytes = Utils.CreateBlob( len );
			MySqlCommand cmd = new MySqlCommand("INSERT INTO Test (id, name, b1) VALUES(1, 'Test', ?b1)", conn);
			cmd.Parameters.Add( "?b1", bytes );
			cmd.ExecuteNonQuery();

			cmd.CommandText = "SELECT * FROM Test";
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader();
				reader.Read();

				long sizeBytes = reader.GetBytes( 4, 0, null, 0, 0 );
				Assert.AreEqual( len, sizeBytes );

				byte[] buff1 = new byte[len/2];
				byte[] buff2 = new byte[len - (len/2)];
				long buff1cnt = reader.GetBytes( 4, 0, buff1, 0, len /2 );
				long buff2cnt = reader.GetBytes( 4, buff1cnt, buff2, 0, buff2.Length );
				Assert.AreEqual( buff1.Length, buff1cnt );
				Assert.AreEqual( buff2.Length, buff2cnt );

				for (int i=0; i<buff1.Length; i++)
					Assert.AreEqual( bytes[i], buff1[i] );

				for (int i=0; i<buff2.Length; i++)
					Assert.AreEqual( bytes[buff1.Length + i], buff2[i] );

				reader.Close();

				//  now check with sequential access
				reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
				Assert.IsTrue(reader.Read());
				int mylen = len;
				byte[] buff = new byte[8192];
				int startIndex = 0;
				while (mylen > 0)
				{
					int readLen = Math.Min( mylen, buff.Length );
					int retVal = (int)reader.GetBytes(4, startIndex, buff, 0, readLen);
					Assert.AreEqual( readLen, retVal );
					for (int i=0; i < readLen; i++)
						Assert.AreEqual( bytes[startIndex+i], buff[i] );
					startIndex += readLen;
					mylen -= readLen;
				}
				
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}

		}

		[Test()]
		public void TestSingleResultSetBehavior()
		{
			execSQL("INSERT INTO Test (id, name, b1) VALUES (1, 'Test1', NULL)");
			execSQL("INSERT INTO Test (id, name, b1) VALUES (2, 'Test1', NULL)");

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM Test WHERE id=1; SELECT * FROM Test WHERE id=2", conn);
			MySqlDataReader reader = cmd.ExecuteReader( CommandBehavior.SingleResult );
			bool result = reader.Read();
			Assert.AreEqual( true, result );

			result = reader.NextResult();
			Assert.AreEqual( false, result );

			reader.Close();
		}

		[Test()]
		public void GetSchema() 
		{
			string sql = "CREATE TABLE test2( " +
				"id INT UNSIGNED AUTO_INCREMENT NOT NULL, " +
				"name VARCHAR(255) NOT NULL, " + 
				"PRIMARY KEY( id ))";

			execSQL("DROP TABLE IF EXISTS test2");
			execSQL(sql);
			execSQL("INSERT INTO test2 VALUES(1,'Test')");

			MySqlDataReader reader = null;

			try 
			{
				MySqlCommand cmd = new MySqlCommand("SELECT * FROM test2", conn);
				reader = cmd.ExecuteReader();
				DataTable dt = reader.GetSchemaTable();
				Assert.AreEqual( true, dt.Rows[0]["IsAutoIncrement"], "Checking auto increment" );
				Assert.AreEqual( true, dt.Rows[0]["IsUnique"], "Checking IsUnique" );
				Assert.AreEqual( false, dt.Rows[0]["AllowDBNull"], "Checking AllowDBNull" );
				Assert.AreEqual( false, dt.Rows[1]["AllowDBNull"], "Checking AllowDBNull" );
			}
			catch (Exception ex) 
			{
				Assert.Fail(ex.Message);
			}
			finally 
			{
				if (reader != null) reader.Close();
			}

			execSQL("DROP TABLE IF EXISTS test2");
		}

		[Test()]
		public void CloseConnectionBehavior() 
		{
			execSQL("INSERT INTO Test(id,name) VALUES(1,'test')");

			MySqlConnection c2 = new MySqlConnection( conn.ConnectionString );
			c2.Open();
			MySqlCommand cmd = new MySqlCommand("SELECT * FROM Test", c2);
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader( CommandBehavior.CloseConnection );
				Assert.IsTrue( reader.Read() );
				reader.Close();
				Assert.IsTrue( c2.State == ConnectionState.Closed );
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
				if (c2.State == ConnectionState.Closed) c2.Open();
			}
		}

		[Test()]
		public void SingleRowBehavior() 
		{
			execSQL("INSERT INTO Test(id,name) VALUES(1,'test1')");
			execSQL("INSERT INTO Test(id,name) VALUES(2,'test2')");
			execSQL("INSERT INTO Test(id,name) VALUES(3,'test3')");

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM Test", conn);
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
				Assert.IsTrue(reader.Read(), "First read");
				Assert.IsFalse(reader.Read(), "Second read");
				Assert.IsFalse(reader.NextResult(), "Trying NextResult");
				reader.Close();

				cmd.CommandText = "SELECT * FROM test where id=1";
				reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
				Assert.IsTrue(reader.Read());
				Assert.AreEqual("test1", reader.GetString(1));
				Assert.IsFalse(reader.Read());
				Assert.IsFalse(reader.NextResult());
				reader.Close();

				reader = null;
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		[Test()]
		public void SingleRowBehaviorWithLimit() 
		{
			execSQL("INSERT INTO Test(id,name) VALUES(1,'test1')");
			execSQL("INSERT INTO Test(id,name) VALUES(2,'test2')");
			execSQL("INSERT INTO Test(id,name) VALUES(3,'test3')");

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM Test LIMIT 2", conn);
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader( CommandBehavior.SingleRow );
				Assert.IsTrue( reader.Read(), "First read" );
				Assert.IsFalse( reader.Read(), "Second read" );
				Assert.IsFalse( reader.NextResult(), "Trying NextResult" );
				reader.Close();

				reader = cmd.ExecuteReader( CommandBehavior.SingleRow );
				Assert.IsTrue( reader.Read(), "First read" );
				Assert.IsFalse( reader.Read(), "Second read" );
				Assert.IsFalse( reader.NextResult(), "Trying NextResult" );
				reader.Close();

				reader = cmd.ExecuteReader( CommandBehavior.SingleRow );
				Assert.IsTrue( reader.Read(), "First read" );
				Assert.IsFalse( reader.Read(), "Second read" );
				Assert.IsFalse( reader.NextResult(), "Trying NextResult" );
				reader.Close();
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		[Test()]
		public void SimpleSingleRow() 
		{
			execSQL("INSERT INTO Test(id,name) VALUES(1,'test1')");

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM Test", conn);
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader();
				Assert.IsTrue( reader.Read(), "First read" );
				Assert.AreEqual( 1, reader.GetInt32(0) );
				Assert.AreEqual( "test1", reader.GetString(1) );
				Assert.IsFalse( reader.Read(), "Second read" );
				Assert.IsFalse( reader.NextResult(), "Trying NextResult" );
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		[Test()]
		public void ConsecutiveNulls() 
		{
			execSQL("INSERT INTO Test (id, name) VALUES (1, 'Test')");
			execSQL("INSERT INTO Test (id, name) VALUES (2, NULL)");
			execSQL("INSERT INTO Test (id, name) VALUES (3, 'Test2')");

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM Test", conn);
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader();
				reader.Read();
				Assert.AreEqual( 1, reader.GetValue(0) );
				Assert.AreEqual( "Test", reader.GetValue(1) );
				Assert.AreEqual( "Test", reader.GetString(1) );
				reader.Read();
				Assert.AreEqual( 2, reader.GetValue(0) );
				Assert.AreEqual( DBNull.Value, reader.GetValue(1) );
				Assert.AreEqual( null, reader.GetString(1) );
				reader.Read();
				Assert.AreEqual( 3, reader.GetValue(0) );
				Assert.AreEqual( "Test2", reader.GetValue(1) );
				Assert.AreEqual( "Test2", reader.GetString(1) );
				Assert.IsFalse( reader.Read() );
				Assert.IsFalse( reader.NextResult() );
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}

		}

		[Test()]
		public void HungDataReader() 
		{
			MySqlCommand cmd = new MySqlCommand("USE test; SHOW TABLES", conn);
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader();
				while (reader.Read()) 
				{
					reader.GetString(0);
				}
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		/// <summary>
		/// Added test for IsDBNull from bug# 7399
		/// </summary>
		[Test()]
		public void SequentialAccessBehavior() 
		{
			execSQL("INSERT INTO Test(id,name) VALUES(1,'test1')");

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM Test", conn);
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader( CommandBehavior.SequentialAccess );
				Assert.IsTrue( reader.Read() );
				Assert.IsFalse( reader.IsDBNull(0));
				int i = reader.GetInt32(0);
				string s = reader.GetString(1);
				Assert.AreEqual(1, i);
				Assert.AreEqual("test1", s);

				// this next line should throw an exception
				i = reader.GetInt32( 0 );
				Assert.Fail( "This line should not execute" );
			}
			catch (MySqlException) { }
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}


		[Test]
		public void ReadingTextFields() 
		{
			execSQL("DROP TABLE IF EXISTS Test");
			execSQL("CREATE TABLE Test (id int, t1 TEXT)");
			execSQL("INSERT INTO Test VALUES (1, 'Text value')");

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM Test", conn);
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader();
				reader.Read();
				string s = reader["t1"].ToString();
				Assert.AreEqual( "Text value", s );
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		[Test]
		[ExpectedException( typeof(MySqlException) )]
		public void ReadingFieldsBeforeRead() 
		{
			MySqlCommand cmd = new MySqlCommand("SELECT * FROM Test", conn);
			MySqlDataReader reader = cmd.ExecuteReader();
			try 
			{
				reader.GetInt32(0);
			}
			catch (Exception) 
			{
				throw;
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		[Test]
		public void GetChar() 
		{
			execSQL("INSERT INTO Test (id, name) VALUES (1, 'a')");
			MySqlCommand cmd = new MySqlCommand("SELECT * FROM Test", conn);
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader();
				reader.Read();
				char achar = reader.GetChar( 1 );
				Assert.AreEqual( 'a', achar );
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		[Test]
		public void ReaderOnNonQuery() 
		{
			MySqlCommand cmd = new MySqlCommand("INSERT INTO Test (id,name) VALUES (1,'Test')", conn);
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader();
				Assert.IsFalse( reader.Read() );
				reader.Close();

				cmd.CommandText = "SELECT name FROM Test";
				object v = cmd.ExecuteScalar();
				Assert.AreEqual( "Test", v );
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		[Test()]
		public void TestManyDifferentResultsets()
		{
			MySqlDataReader reader =null;
			try
			{
				MySqlCommand cmd = new MySqlCommand("", conn);
				// insert 100 records
				cmd.CommandText = "INSERT INTO Test (id,name,dt,b1) VALUES (?id, 'test','2004-12-05 12:57:00','long blob data')";
				cmd.Parameters.Add( new MySqlParameter("?id", 1));
				for (int i=1; i <= 100; i++)
				{
					cmd.Parameters[0].Value = i;
					cmd.ExecuteNonQuery();
				}

				cmd = new MySqlCommand("SELECT id FROM Test WHERE id<?param1; "+
					"SELECT id,name FROM Test WHERE id = -50; "+
					"SELECT * FROM Test WHERE id >= ?param1; "+
					"SELECT id, dt, b1 FROM Test WHERE id = -50; "+
					"SELECT b1 FROM Test WHERE id = -50; "+
					"SELECT id, dt, b1 FROM Test WHERE id < ?param1; "+
					"SELECT b1 FROM Test WHERE id >= ?param1;", conn);

				cmd.Parameters.Add("?param1",50);

				reader = cmd.ExecuteReader();

				Assert.IsNotNull( reader );

				//First ResultSet, should have 49 rows.
				//SELECT id FROM test WHERE id<?param1;
				Assert.AreEqual( true, reader.HasRows );
				Assert.AreEqual( 1, reader.FieldCount );
				for (int i = 0; i < 49; i++)
				{
					Assert.IsTrue( reader.Read() );
				}
				Assert.AreEqual( false, reader.Read() );

				//Second ResultSet, should have no rows.
				//SELECT id,name FROM test WHERE id = -50;
				Assert.IsTrue( reader.NextResult() );
				Assert.AreEqual( false, reader.HasRows );
				Assert.AreEqual( 2, reader.FieldCount );
				Assert.AreEqual( false, reader.Read() );


				//Third ResultSet, should have 51 rows.
				//SELECT * FROM test WHERE id >= ?param1;
				Assert.IsTrue( reader.NextResult() );
				Assert.AreEqual( true, reader.HasRows );
				Assert.AreEqual( 5, reader.FieldCount );
				for (int i = 0; i < 51; i++)
				{
					Assert.IsTrue( reader.Read() );
				}
				Assert.AreEqual( false, reader.Read() );


				//Fourth ResultSet, should have no rows.
				//SELECT id, dt, b1 FROM test WHERE id = -50;
				Assert.IsTrue( reader.NextResult() );
				Assert.AreEqual( false, reader.HasRows );
				Assert.AreEqual( 3, reader.FieldCount ); //Will Fail if uncommented expected 3 returned 5
				Assert.AreEqual( false, reader.Read() );

				//Fifth ResultSet, should have no rows.
				//SELECT b1 FROM test WHERE id = -50;
				Assert.IsTrue( reader.NextResult() );
				Assert.AreEqual( false, reader.HasRows );
				Assert.AreEqual( 1, reader.FieldCount ); //Will Fail if uncommented expected 1 returned 5
				Assert.AreEqual( false, reader.Read() );

				//Sixth ResultSet, should have 49 rows.
				//SELECT id, dt, b1 FROM test WHERE id < ?param1;
				Assert.IsTrue( reader.NextResult() );
				Assert.AreEqual( true, reader.HasRows );
				Assert.AreEqual( 3, reader.FieldCount ); //Will Fail if uncommented expected 3 returned 5
				for (int i = 0; i < 49; i++)
				{
					Assert.IsTrue( reader.Read() );
				}
				Assert.AreEqual( false, reader.Read() );

				//Seventh ResultSet, should have 51 rows.
				//SELECT b1 FROM test WHERE id >= ?param1;
				Assert.IsTrue( reader.NextResult() );
				Assert.AreEqual( true, reader.HasRows );
				Assert.AreEqual( 1, reader.FieldCount ); //Will Fail if uncommented expected 1 returned 5
				for (int i = 0; i < 51; i++)
				{
					Assert.IsTrue( reader.Read() );
				}
				Assert.AreEqual( false, reader.Read() );
			}
			catch (Exception ex)
			{
				Assert.Fail( ex.Message );
			}
			finally
			{
				if (reader != null) reader.Close();
			}
		}


		[Test]
		public void TestMultipleResultsWithQueryCacheOn()
		{
			execSQL("SET SESSION query_cache_type = ON");
			execSQL("INSERT INTO Test (id,name) VALUES (1, 'Test')");
			execSQL("INSERT INTO Test (id,name) VALUES (51, 'Test')");


			MySqlDataReader reader =null;

			try 
			{

				// execute it one time
				MySqlCommand cmd = new MySqlCommand("SELECT id FROM Test WHERE id<50; SELECT * FROM Test	WHERE id >= 50;", conn);

				reader = cmd.ExecuteReader();

				Assert.IsNotNull( reader );
				Assert.AreEqual( true, reader.HasRows );
				Assert.IsTrue( reader.Read() );
				Assert.AreEqual( 1, reader.FieldCount );
				Assert.IsTrue( reader.NextResult() );
				Assert.AreEqual( true, reader.HasRows );
				Assert.AreEqual( 5, reader.FieldCount );

				reader.Close();

				// now do it again
				reader = cmd.ExecuteReader();
				Assert.IsNotNull( reader );
				Assert.AreEqual( true, reader.HasRows );
				Assert.IsTrue( reader.Read() );
				Assert.AreEqual( 1, reader.FieldCount );
				Assert.IsTrue( reader.NextResult() );
				Assert.AreEqual( true, reader.HasRows );
				Assert.AreEqual( 5, reader.FieldCount );

				reader.Close();
			}
			catch (Exception ex)
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		/// <summary>
		/// Bug #8630  	Executing a query with the SchemaOnly option reads the entire resultset
		/// </summary>
		[Test]
		public void SchemaOnly() 
		{
			execSQL("INSERT INTO Test (id,name) VALUES(1,'test1')");
			execSQL("INSERT INTO Test (id,name) VALUES(2,'test2')");
			execSQL("INSERT INTO Test (id,name) VALUES(3,'test3')");

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM test", conn);
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
				DataTable table = reader.GetSchemaTable();
				Assert.AreEqual(5, table.Rows.Count);
				Assert.AreEqual(22, table.Columns.Count);
				Assert.IsFalse(reader.Read());
			}
			catch (Exception ex) 
			{
				Assert.Fail(ex.Message);
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		/// <summary>
		/// Bug #9237  	MySqlDataReader.AffectedRecords not set to -1
		/// </summary>
		[Test]
		public void AffectedRows()
		{
			MySqlCommand cmd = new MySqlCommand("SHOW TABLES", conn);
			try 
			{
				using (MySqlDataReader reader = cmd.ExecuteReader()) 
				{
					reader.Read();
					reader.Close();
					Assert.AreEqual(-1, reader.RecordsAffected);
				}
			}
			catch (Exception ex) 
			{
				Assert.Fail(ex.Message);
			}
		}

		/// <summary>
		/// Bug #11873  	Invalid timestamp in query produces incorrect reader exception
		/// </summary>
		[Test]
		public void InvalidTimestamp() 
		{
			execSQL("DROP TABLE IF EXISTS test");
			execSQL("CREATE TABLE test (tm TIMESTAMP)");
			execSQL("INSERT INTO test VALUES (NULL)");

			MySqlCommand cmd = new MySqlCommand("SELECT * FROM test WHERE tm = '7/1/2005 12:00:00 AM'", conn); 
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader();
			}
			catch (Exception ex) 
			{
				Assert.Fail(ex.Message);
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

	}
}
