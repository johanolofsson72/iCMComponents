//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;
using System.Data;

namespace iConsulting.iCXmlDbClient
{
	public class XmlDbCommand : IDbCommand
	{
		private string commandText;
		private XmlDbConnection connection = null;
		private XmlDbTransaction transaction = null;
		private XmlDbParameterCollection parameters = new XmlDbParameterCollection();

		public XmlDbCommand() {}

		public XmlDbCommand(string commandText) {
			this.commandText = commandText;
		}

		public XmlDbCommand(string commandText, XmlDbConnection connection) {
			this.commandText = commandText;
			this.connection = connection;
		}

		public XmlDbCommand(string commandText, XmlDbConnection connection, XmlDbTransaction transaction) {
			this.commandText = commandText;
			this.connection = connection;
			this.transaction = transaction;
		}

		#region IDbCommand Members

		public string CommandText {
			get { return this.commandText; }
			set { this.commandText = value; }
		}

		public IDbConnection Connection {
			get { return this.connection; }
			set { this.connection = (value as XmlDbConnection); }
		}

		public IDbTransaction Transaction {
			get { return this.transaction; }
			set { this.transaction = (value as XmlDbTransaction); }
		}

		public IDataReader ExecuteReader() {
			return new XmlDbDataReader(this.CommandSql, this.connection, CommandBehavior.Default);
		}

		public IDataReader ExecuteReader(CommandBehavior behavior) {
			return new XmlDbDataReader(this.CommandSql, this.connection, behavior);
		}

		public object ExecuteScalar() {
			IDataReader reader = null;
			bool isClosed = (this.connection.State == ConnectionState.Closed);
			try {
				if (isClosed) this.connection.Open();
				reader = this.ExecuteReader();
				return (reader.Read() ? reader[0] : null);
			}
			finally {
				if (reader == null) reader.Close();
				if (isClosed) this.connection.Close();
			}
		}

		public int ExecuteNonQuery() {
			bool inTransaction = true;
			if (this.transaction == null) {
				inTransaction = false;
				this.transaction = (this.connection.BeginTransaction() as XmlDbTransaction);
			}
			try {
				switch (this.commandText.Trim().Substring(0, 6).ToUpper()) {
					case "INSERT" : return this.ExecuteInsert();
					case "UPDATE" : return this.ExecuteUpdate();
					case "DELETE" : return this.ExecuteDelete();
					default :	throw new
						XmlDbNotSupportedException("XmlDbCommand: Command Text must be INSERT/UPDATE/DELETE");
				}
			}
			catch {
				if (!inTransaction) {
					this.transaction.Rollback();
					this.transaction = null;
				}
				throw;
			}
			finally {
				if (!inTransaction && this.transaction != null) {
					this.transaction.Commit();
					this.transaction = null;
				}
			}
		}

		private int ExecuteInsert() {
			ParseInsertSql sql = new ParseInsertSql(this.CommandSql);
			string[] fieldNames = sql.FieldList.Split(',');
			string[] fieldValues = sql.ValueList.Split(',');
			int fieldCount = Math.Min(fieldNames.Length, fieldValues.Length);

			DataTable table = this.connection.data.Tables[sql.TableName];
			DataRow row = table.NewRow();
			for (int index = 0; index < fieldCount; index++) {
				string fieldName = fieldNames[index].Trim();
				string fieldValue = fieldValues[index].Trim();
				if (fieldValue.ToUpper() == "NULL") {
					row[fieldName] = null;
				}
				else {
					if (fieldValue.StartsWith("'")) fieldValue = fieldValue.Remove(0, 1);
					if (fieldValue.EndsWith("'")) fieldValue = fieldValue.Remove(fieldValue.Length - 1, 1);
					fieldValue = fieldValue.Replace("''", "'");
					row[fieldName] = Convert.ChangeType(fieldValue, table.Columns[fieldName].DataType);
				}
			}
			table.Rows.Add(row);

			this.connection.identity = int.MinValue;
			for (int index = 0; index < table.Columns.Count; index++) {
				if (table.Columns[index].AutoIncrement) {
					this.connection.identity = Convert.ToInt32(row[index]);
					break;
				}
			}
			return 1;
		}

		private int ExecuteUpdate() {
			ParseUpdateSql sql = new ParseUpdateSql(this.CommandSql);
			string[] expressions = sql.UpdateList.Split(',');
			DataTable table = this.connection.data.Tables[sql.TableName];
			DataRow[] rows = table.Select(sql.WhereClause);
			foreach (DataRow row in rows) {
				foreach (string expression in expressions) {
					int position = expression.IndexOf("=");
					if (position > 0) {
						string fieldName = expression.Substring(0, position).Trim();
						string fieldValue = expression.Substring(position + 1).Trim();
						if (fieldValue.ToUpper() == "NULL") {
							row[fieldName] = null;
						}
						else {
							if (fieldValue.StartsWith("'")) fieldValue = fieldValue.Remove(0, 1);
							if (fieldValue.EndsWith("'")) fieldValue = fieldValue.Remove(fieldValue.Length - 1, 1);
							fieldValue = fieldValue.Replace("''", "'");
							row[fieldName] = Convert.ChangeType(fieldValue, table.Columns[fieldName].DataType);
						}
					}
				}
			}
			return rows.Length;
		}

		private int ExecuteDelete() {
			ParseDeleteSql sql = new ParseDeleteSql(this.CommandSql);
			DataTable table = this.connection.data.Tables[sql.TableName];
			DataRow[] rows = table.Select(sql.WhereClause);
			foreach (DataRow row in rows) row.Delete();
			return rows.Length;
		}

		private string CommandSql {
			get {
				string sql = this.commandText;
				foreach (XmlDbParameter parameter in this.parameters) {
					sql = sql.Replace(parameter.ParameterName, parameter.Value.ToString());
				}
				return sql;
			}
		}

		public IDbDataParameter CreateParameter() {
			return new XmlDbParameter();
		}

		public IDataParameterCollection Parameters {
			get { return this.parameters; }
		}

		public void Cancel() {
			// Do Nothing
		}

		public void Prepare() {
			// Do Nothing
		}

		public CommandType CommandType {
			get { return CommandType.Text; }
			set {} // TODO throw new XmlDbNotSupportedException("XmlDbCommand: Command Type is not Supported"); }
		}

		public UpdateRowSource UpdatedRowSource {
			get { return UpdateRowSource.None; }
			set { throw new XmlDbNotSupportedException("XmlDbCommand: Command UpdatedRowSource is not Supported"); }
		}

		public int CommandTimeout {
			get { return 0;	}
			set {} // TODO throw new XmlDbNotSupportedException("XmlDbCommand: Command Timeout is not Supported"); }
		}

		#endregion

		#region IDisposable Members

		public void Dispose() {
			// Do Nothing
		}

		#endregion
	}
}
