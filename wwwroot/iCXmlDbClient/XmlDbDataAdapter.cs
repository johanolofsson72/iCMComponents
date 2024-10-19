//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;
using System.Data;

namespace iConsulting.iCXmlDbClient
{
	public class XmlDbDataAdapter : IDbDataAdapter
	{
		private XmlDbCommand selectCommand = null;

		public XmlDbDataAdapter(XmlDbCommand selectCommand) {
			this.selectCommand = selectCommand;
		}

		public int Fill(DataTable dataTable) {
			bool isFirst = true;
			XmlDbDataReader reader = null;
			IDbConnection connection = this.selectCommand.Connection;
			if (connection == null) throw new
				XmlDbException("XmlDbDataAdapter: Fill requires a valid Connection");
			bool isClosed = (connection.State == ConnectionState.Closed);

			try {
				if (isClosed) connection.Open();
				reader = (this.selectCommand.ExecuteReader() as XmlDbDataReader);
				while (reader.Read()) {
					if (isFirst) {
						if (dataTable.TableName.Length == 0) dataTable.TableName = reader.TableName;
						if (dataTable.Columns.Count == 0) {
							for (int index = 0; index < reader.FieldCount; index++) {
								dataTable.Columns.Add(reader.GetName(index), reader.GetFieldType(index));
							}
						}
						isFirst = false;
					}
					object[] values = new object[reader.FieldCount];
					reader.GetValues(values);
					dataTable.Rows.Add(values);
				}
			}
			finally {
				if (reader == null) reader.Close();
				if (isClosed) connection.Close();
			}
			return dataTable.Rows.Count;
		}

		#region IDbDataAdapter Members

		public IDbCommand SelectCommand {
			get { return this.selectCommand; }
			set { this.selectCommand = (value as XmlDbCommand); }
		}

		public IDbCommand InsertCommand {
			get { return null; }
			set { throw new XmlDbNotSupportedException("XmlDbDataAdapter: DataAdapter InsertCommand is not Supported"); }
		}

		public IDbCommand UpdateCommand {
			get { return null; }
			set { throw new XmlDbNotSupportedException("XmlDbDataAdapter: DataAdapter UpdateCommand is not Supported"); }
		}

		public IDbCommand DeleteCommand {
			get { return null; }
			set { throw new XmlDbNotSupportedException("XmlDbDataAdapter: DataAdapter DeleteCommand is not Supported"); }
		}

		#endregion

		#region IDataAdapter Members

		public int Fill(DataSet dataSet) {
			if (dataSet.DataSetName.Length == 0) {
				dataSet.DataSetName = this.selectCommand.Connection.Database;
			}
			if (dataSet.Tables.Count == 0) dataSet.Tables.Add();
			return this.Fill(dataSet.Tables[0]);
		}

		public ITableMappingCollection TableMappings {
			get { return null; }
		}

		public MissingSchemaAction MissingSchemaAction {
			get { return MissingSchemaAction.Error; }
			set { throw new XmlDbNotSupportedException("XmlDbDataAdapter: DataAdapter MissingSchemaAction must be Error"); }
		}

		public MissingMappingAction MissingMappingAction {
			get { return MissingMappingAction.Passthrough; }
			set { throw new XmlDbNotSupportedException("XmlDbDataAdapter: DataAdapter MissingMappingAction must be Passthrough"); }
		}

		public IDataParameter[] GetFillParameters() {
			throw new XmlDbNotSupportedException("XmlDbDataAdapter: DataAdapter GetFillParameters is not Supported");
		}

		public DataTable[] FillSchema(DataSet dataSet, System.Data.SchemaType schemaType) {
			throw new XmlDbNotSupportedException("XmlDbDataAdapter: DataAdapter FillSchema is not Supported");
		}

		public int Update(DataSet dataSet) {
			throw new XmlDbNotSupportedException("XmlDbDataAdapter: DataAdapter Update is not Supported");
		}

		#endregion
	}
}
