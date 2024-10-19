//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;

namespace iConsulting.iCXmlDbClient
{
	// DELETE [FROM] tableName [WHERE whereClause]
	internal class ParseDeleteSql
	{
		private string deleteSql;
		private string tableName = string.Empty;
		private string whereClause = string.Empty;

		public string TableName {
			get { return this.tableName; }
		}

		public string WhereClause {
			get { return this.whereClause; }
		}

		public ParseDeleteSql(string deleteSql) {
			this.deleteSql = deleteSql;

			int start = 0;
			string sql = deleteSql.Replace('\r',' ').Replace('\n',' ').Replace('\t',' ').Trim(' ',';');

			start = sql.ToUpper().IndexOf(" WHERE ");
			if (start > 0) {
				this.whereClause = sql.Substring(start + 7).Trim();
				sql = sql.Substring(0, start);
			}

			if (sql.ToUpper().StartsWith("DELETE")) {
				start = sql.ToUpper().IndexOf(" FROM ");
				if (start > 0) {
					this.tableName = sql.Substring(start + 6).Trim(' ','[',']');
				}
				else {	
					this.tableName = sql.Substring(6).Trim(' ','[',']');
				}
			}
			else {
				throw new XmlDbParseSqlException("XmlDbParseDeleteSql: Delete Statement must start with DELETE");
			}

			this.tableName = this.tableName.Replace("[","").Replace("]","");
			this.whereClause = this.whereClause.Replace("[","").Replace("]","").Replace(this.tableName + ".","");
		}
	}
}
