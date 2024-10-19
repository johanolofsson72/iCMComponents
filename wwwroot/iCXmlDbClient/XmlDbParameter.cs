//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;
using System.Data;

namespace iConsulting.iCXmlDbClient
{
	public class XmlDbParameter : IDbDataParameter
	{
		private string name;
		private object value;
		private DbType dbType = DbType.String;
		private string source = string.Empty;

		public XmlDbParameter() {}

		public XmlDbParameter(string name, object value) {
			if (!name.StartsWith("@")) throw new
				XmlDbParseSqlException("XmlDbParameter: Parameter Names must start with @");
			this.name = name;
			this.value = value;
		}

		#region IDataParameter Members

		public string ParameterName {
			get { return this.name; }
			set {
				if (!value.StartsWith("@")) throw new
					XmlDbParseSqlException("XmlDbParameter: Parameter Names must start with @");
				this.name = value;
			}
		}

		public object Value {
			get { return this.value; }
			set { this.value = value; }
		}

		public DbType DbType {
			get { return this.dbType; }
			set { this.dbType = value; }
		}

		public string SourceColumn {
			get { return this.source; }
			set { this.source = value; }
		}

		public bool IsNullable {
			get { return true; }
		}

		public ParameterDirection Direction {
			get { return ParameterDirection.Input; }
			set { throw new XmlDbNotSupportedException("XmlDbParameter: Parameter Direction must be Input"); }
		}

		public DataRowVersion SourceVersion {
			get { return DataRowVersion.Default; }
			set { throw new XmlDbNotSupportedException("XmlDbParameter: Parameter SourceVersion must be Default"); }
		}

		#endregion

		#region IDbDataParameter Members

		public byte Precision {
			get { return 0; }
			set { throw new XmlDbNotSupportedException("XmlDbParameter: Parameter Precision is not Supported"); }
		}

		public byte Scale {
			get { return 0; }
			set { throw new XmlDbNotSupportedException("XmlDbParameter: Parameter Scale is not Supported"); }
		}

		public int Size {
			get { return 0; }
			set { throw new XmlDbNotSupportedException("XmlDbParameter: Parameter Size is not Supported"); }
		}

		#endregion
	}
}
