//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;
using System.Data;

namespace iConsulting.iCXmlDbClient
{
	public class XmlDbConnection : System.Data.IDbConnection
	{
		private string connectionString;
		private ConnectionState state = ConnectionState.Closed;
		internal DataSet data = new DataSet();
		internal int identity = int.MinValue;

		public XmlDbConnection() {}

		public XmlDbConnection(string connectionString) {
			this.connectionString = connectionString;
		}

		#region IDbConnection Members

		public string ConnectionString {
			get { return this.connectionString; }
			set {
				if (this.state != ConnectionState.Closed) {
					throw new XmlDbException("XmlDbConnection: Connection is currently Open");
				}
				this.connectionString = value;
			}
		}

		public ConnectionState State {
			get { return this.state; }
		}

		public void Open() {
			try {
				if (this.state != ConnectionState.Closed) {
					throw new XmlDbException("XmlDbConnection: Connection is already Open");
				}
				this.data.ReadXml(this.connectionString);
				this.state = ConnectionState.Open;

#if DEBUG
				Console.WriteLine("DataSet: " + this.data.DataSetName);
				foreach (DataTable table in this.data.Tables) {
					Console.WriteLine("Table: " + table.TableName);
					foreach (DataColumn column in table.Columns) {
						Console.WriteLine(" - Column: " + column.ColumnName);
					}
				}
#endif
			}
			catch (Exception exception) {
				this.Close();
				throw exception;
			}
		}

		public void Close() {
			this.data.Clear();
			this.state = ConnectionState.Closed;
		}

		public IDbCommand CreateCommand() {
			return new XmlDbCommand(string.Empty, this);
		}

		public IDbTransaction BeginTransaction(IsolationLevel isolationLevel) {
			return new XmlDbTransaction(this);
		}

		public IDbTransaction BeginTransaction() {
			return new XmlDbTransaction(this);
		}

		public string Database {
			get { return this.data.DataSetName; }
		}

		public int ConnectionTimeout {
			get { return 0;	}
		}

		public void ChangeDatabase(string databaseName) {
			throw new XmlDbNotSupportedException("XmlDbConnection: Connection ChangeDatabase is not Supported");
		}

		#endregion

		#region IDisposable Members

		public void Dispose() {
			this.Close();
		}

		#endregion
	}
}
