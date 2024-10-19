//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;

namespace iConsulting.iCXmlDbClient
{
	// INSERT [INTO] tableName (fieldList) VALUES (valueList)
	internal class ParseInsertSql
	{
		private string insertSql;
		private string tableName = string.Empty;
		private string fieldList = string.Empty;
		private string valueList = string.Empty;

		public string TableName {
			get { return this.tableName; }
		}

		public string FieldList {
			get { return this.fieldList; }
		}

		public string ValueList {
			get { return this.valueList; }
		}

		public ParseInsertSql(string insertSql) {
			this.insertSql = insertSql;

			int start = 0;
			string sql = insertSql.Replace('\r',' ').Replace('\n',' ').Replace('\t',' ').Trim(' ',';');

			start = sql.ToUpper().IndexOf(" VALUES ");
			if (start > 0) {
				this.valueList = sql.Substring(start + 8).Trim(' ','(',')');
				sql = sql.Substring(0, start);
			}
			else {
				throw new XmlDbParseSqlException("XmlDbParseInsertSql: Insert Statement must contain VALUES");
			}

			start = sql.ToUpper().IndexOf(" (");
			if (start > 0) {
				this.fieldList = sql.Substring(start + 2).Trim(' ','(',')');
				sql = sql.Substring(0, start);
			}
			else {
				throw new XmlDbParseSqlException("XmlDbParseInsertSql: Insert Statement must contain (FieldList)");
			}

			if (sql.ToUpper().StartsWith("INSERT")) {
				start = sql.ToUpper().IndexOf(" INTO ");
				if (start > 0) {
					this.tableName = sql.Substring(start + 6).Trim(' ','[',']');
				}
				else {	
					this.tableName = sql.Substring(6).Trim(' ','[',']');
				}
			}
			else {
				throw new XmlDbParseSqlException("XmlDbParseInsertSql: Insert Statement must start with INSERT");
			}

			this.tableName = this.tableName.Replace("[","").Replace("]","");
			this.fieldList = this.fieldList.Replace("[","").Replace("]","").Replace(this.tableName + ".","");
		}
	}
}
