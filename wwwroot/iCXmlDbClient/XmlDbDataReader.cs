//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;
using System.Collections;
using System.Data;

namespace iConsulting.iCXmlDbClient
{
	public class XmlDbDataReader : IDataReader, IEnumerable, IEnumerator
	{
		private string commandText;
		private XmlDbConnection connection;
		private CommandBehavior behavior;

		private int current = -1;
		private ParseSelectSql sql = null;
		private DataRow[] rows = null;

		internal XmlDbDataReader(string commandText, XmlDbConnection connection, CommandBehavior behavior) {
			this.commandText = commandText;
			this.connection = connection;
			this.behavior = behavior;

			this.sql = new ParseSelectSql(commandText);

			DataTable table = null;
			if (this.sql.IsIdentity) {
				if (this.connection.identity == int.MinValue) throw new
					XmlDbException("XmlDbDataReader: No Identity was Current in the Connection");
				table = new DataTable(this.connection.Database + "_Identity");
				table.Columns.Add("Identity", typeof(int));
				table.Rows.Add(new object[] {this.connection.identity});
			}
			else {
				table = this.connection.data.Tables[sql.TableName];
			}
			this.rows = table.Select(sql.WhereClause, sql.SortClause);
			this.current = this.sql.SkipRows - 1;
		}

		public bool HasRows {
			get { return (this.rows.Length > this.sql.SkipRows); }
		}

		internal string TableName {
			get { return this.sql.TableName; }
		}

		#region IDataReader Members

		public bool Read() {
			this.current++;
			if (this.sql.PageSize == 0) {
				return (this.current < this.rows.Length);
			}
			else {
				return (this.current < Math.Min(this.sql.PageSize + this.sql.SkipRows, this.rows.Length));
			}
		}

		public void Close() {
			this.rows = null;
			if (this.behavior == CommandBehavior.CloseConnection) {
				this.connection.Close();
			}
		}

		public bool IsClosed {
			get { return (this.rows == null); }
		}

		public int RecordsAffected {
			get { return -1;	}
		}

		public int Depth {
			get { return 0;	}
		}

		public bool NextResult() {
			return false;
		}

		public DataTable GetSchemaTable() {
			return null;
		}

		#endregion

		#region IDataRecord Members

		public object this[string name] {
			get { return this.rows[this.current][name]; }
		}

		object IDataRecord.this[int i] {
			get { return this.GetValue(i); }
		}

		public string GetName(int i) {
			DataRow row = this.rows[this.current];
			string fieldName = null;
			if (this.sql.FieldList == "*") {
				fieldName = row.Table.Columns[i].ColumnName;
			}
			else {
				fieldName = this.sql.FieldList.Split(',')[i].Trim();
			}
			return fieldName;
		}

		public int GetOrdinal(string name) {
			DataRow row = this.rows[this.current];
			if (this.sql.FieldList == "*") {
				return row.Table.Columns[name].Ordinal;
			}
			else {
				string[] fieldNames = this.sql.FieldList.Split(',');
				for (int index = 0; index < fieldNames.Length; index++) {
					string fieldName = fieldNames[index].Trim();
					fieldName = fieldName.Replace("[","").Replace("]","");
					if (fieldName.ToUpper() == name.ToUpper()) return index;
				}
				return -1;
			}
		}

		public Type GetFieldType(int i) {
			return this.rows[this.current].Table.Columns[this.GetName(i)].DataType;
		}

		public string GetDataTypeName(int i) {
			return this.GetFieldType(i).ToString();
		}

		public int FieldCount {
			get {
				if (this.sql.FieldList == "*") {
					return this.rows[this.current].Table.Columns.Count;
				}
				else {
					return this.sql.FieldList.Split(',').Length;
				}
			}
		}

		public int GetValues(object[] values) {
			int count = Math.Min(values.Length, this.FieldCount);
			for (int index = 0; index < count; index++) {
				values[index] = this.GetValue(index);
			}
			return count;
		}

		public object GetValue(int i) {
			DataRow row = this.rows[this.current];
			return row[this.GetName(i)];
		}

		public bool GetBoolean(int i) {
			return Convert.ToBoolean(this.GetValue(i));
		}

		public byte GetByte(int i) {
			return Convert.ToByte(this.GetValue(i));
		}

		public char GetChar(int i) {
			return Convert.ToChar(this.GetValue(i));
		}

		public DateTime GetDateTime(int i) {
			return Convert.ToDateTime(this.GetValue(i));
		}

		public decimal GetDecimal(int i) {
			return Convert.ToDecimal(this.GetValue(i));
		}

		public double GetDouble(int i) {
			return Convert.ToDouble(this.GetValue(i));
		}

		public float GetFloat(int i) {
			return (float) Convert.ChangeType(this.GetValue(i), typeof(float));
		}

		public Guid GetGuid(int i) {
			return (Guid) Convert.ChangeType(this.GetValue(i), typeof(Guid));
		}

		public short GetInt16(int i) {
			return Convert.ToInt16(this.GetValue(i));
		}

		public int GetInt32(int i) {
			return Convert.ToInt32(this.GetValue(i));
		}

		public long GetInt64(int i) {
			return Convert.ToInt64(this.GetValue(i));
		}

		public string GetString(int i) {
			return Convert.ToString(this.GetValue(i));
		}

		public bool IsDBNull(int i) {
			return Convert.IsDBNull(this.GetValue(i));
		}

		public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferOffset, int length) {
			byte[] values = (byte[]) this.GetValue(i);
			int size = Math.Min(values.Length - (int)fieldOffset, length);
			Buffer.BlockCopy(values, (int)fieldOffset, buffer, bufferOffset, size);
			return (long) size;
		}

		public long GetChars(int i, long fieldOffset, char[] buffer, int bufferOffset, int length) {
			string chars = (string) this.GetValue(i);
			int size = Math.Min(chars.Length - (int)fieldOffset, length);
			chars.CopyTo((int)fieldOffset, buffer, bufferOffset, size);
			return (long) size;
		}

		public IDataReader GetData(int i) {
			return null;
		}

		#endregion

		#region IDisposable Members

		public void Dispose() {
			this.Close();
		}

		#endregion

		#region IEnumerable Members

		public System.Collections.IEnumerator GetEnumerator() {
			return (IEnumerator) this;
		}

		#endregion

		#region IEnumerator Members

		public void Reset() {
			throw new XmlDbNotSupportedException("XmlDbDataReader: DataReader Reset is not Supported");
		}

		public object Current {
			get { return (IDataRecord) this; }
		}

		public bool MoveNext() {
			return this.Read();
		}

		#endregion
	}
}
