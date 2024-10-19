//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;

namespace iConsulting.iCXmlDbClient
{
	// UPDATE tableName SET updateList [WHERE whereClause]
	internal class ParseUpdateSql
	{
		private string updateSql;
		private string tableName = string.Empty;
		private string updateList = string.Empty;
		private string whereClause = string.Empty;

		public string TableName {
			get { return this.tableName; }
		}

		public string UpdateList {
			get { return this.updateList; }
		}

		public string WhereClause {
			get { return this.whereClause; }
		}

		public ParseUpdateSql(string updateSql) {
			this.updateSql = updateSql;

			int start = 0;
			string sql = updateSql.Replace('\r',' ').Replace('\n',' ').Replace('\t',' ').Trim(' ',';');

			start = sql.ToUpper().IndexOf(" WHERE ");
			if (start > 0) {
				this.whereClause = sql.Substring(start + 7).Trim();
				sql = sql.Substring(0, start);
			}

			start = sql.ToUpper().IndexOf(" SET ");
			if (start > 0) {
				this.updateList = sql.Substring(start + 5).Trim();
				sql = sql.Substring(0, start);
			}
			else {
				throw new XmlDbParseSqlException("XmlDbParseUpdateSql: Update Statement must contain SET");
			}

			if (sql.ToUpper().StartsWith("UPDATE")) {
				this.tableName = sql.Substring(6).Trim(' ','[',']');
			}
			else {
				throw new XmlDbParseSqlException("XmlDbParseUpdateSql: Update Statement must start with UPDATE");
			}

			this.tableName = this.tableName.Replace("[","").Replace("]","");
			this.updateList = this.updateList.Replace("[","").Replace("]","").Replace(this.tableName + ".","");
			this.whereClause = this.whereClause.Replace("[","").Replace("]","").Replace(this.tableName + ".","");
		}
	}
}
