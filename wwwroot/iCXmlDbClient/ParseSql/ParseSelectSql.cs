//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;

namespace iConsulting.iCXmlDbClient
{
	// SELECT *|fieldList FROM tableName [WHERE whereClause]
	//   [ORDER BY sortClause] [LIMIT pageSize] [OFFSET skipRows]
	// or SELECT @@Identity
	internal class ParseSelectSql
	{
		private string selectSql;
		private bool isIdentity = false;
		private string fieldList = string.Empty;
		private string tableName = string.Empty;
		private string whereClause = string.Empty;
		private string sortClause = string.Empty;
		private int pageSize = 0;
		private int skipRows = 0;

		public bool IsIdentity {
			get { return this.isIdentity; }
		}

		public string FieldList {
			get { return this.fieldList; }
		}

		public string TableName {
			get { return this.tableName; }
		}

		public string WhereClause {
			get { return this.whereClause; }
		}

		public string SortClause {
			get { return this.sortClause; }
		}

		public int PageSize {
			get { return this.pageSize; }
		}

		public int SkipRows {
			get { return this.skipRows; }
		}

		public ParseSelectSql(string selectSql) {
			this.selectSql = selectSql;

			int start = 0;
			string sql = selectSql.Replace('\r',' ').Replace('\n',' ').Replace('\t',' ').Trim(' ',';');

			if (sql.Replace(" ", "").ToUpper() == "SELECT@@IDENTITY") {
				this.isIdentity = true;
				this.fieldList = "Identity";
				return;
			}

			start = sql.ToUpper().IndexOf(" OFFSET ");
			if (start > 0) {
				try {
					this.skipRows = int.Parse(sql.Substring(start + 8));
					if (this.skipRows < 0) this.skipRows = 0;
				}
				catch {
					this.skipRows = 0;
				}
				sql = sql.Substring(0, start);
			}

			start = sql.ToUpper().IndexOf(" LIMIT ");
			if (start > 0) {
				try {
					this.pageSize = int.Parse(sql.Substring(start + 7));
					if (this.pageSize < 0) this.pageSize = 0;
				}
				catch {
					this.pageSize = 0;
				}
				sql = sql.Substring(0, start);
			}
			
			start = sql.ToUpper().IndexOf(" ORDER BY ");
			if (start > 0) {
				this.sortClause = sql.Substring(start + 10).Trim();
				sql = sql.Substring(0, start);
			}

			start = sql.ToUpper().IndexOf(" WHERE ");
			if (start > 0) {
				this.whereClause = sql.Substring(start + 7).Trim();
				sql = sql.Substring(0, start);
			}

			start = sql.ToUpper().IndexOf(" FROM ");
			if (start > 0) {
				this.tableName = sql.Substring(start + 6).Trim();
				sql = sql.Substring(0, start);
			}
			else {
				throw new XmlDbParseSqlException("XmlDbParseSelectSql: Select Statement must contain FROM");
			}

			if (sql.ToUpper().StartsWith("SELECT")) {
				this.fieldList = sql.Substring(6).Trim();
			}
			else {
				throw new XmlDbParseSqlException("XmlDbParseSelectSql: Select Statement must start with SELECT");
			}

			this.tableName = this.tableName.Replace("[","").Replace("]","");
			this.fieldList = this.fieldList.Replace("[","").Replace("]","").Replace(this.tableName + ".","");
			this.whereClause = this.whereClause.Replace("[","").Replace("]","").Replace(this.tableName + ".","");
			this.sortClause = this.sortClause.Replace("[","").Replace("]","").Replace(this.tableName + ".","");
		}
	}
}
