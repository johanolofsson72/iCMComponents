//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;
using System.Data;

namespace iConsulting.iCXmlDbClient
{
	public class XmlDbTransaction : IDbTransaction
	{
		private XmlDbConnection connection;

		internal XmlDbTransaction(XmlDbConnection connection) {
			this.connection = connection;
		}

		#region IDbTransaction Members

		public IDbConnection Connection {
			get { return this.connection; }
		}

		public void Commit() {
			this.connection.data.AcceptChanges();
			this.connection.data.WriteXml(this.connection.ConnectionString, XmlWriteMode.WriteSchema);
		}

		public void Rollback() {
			this.connection.data.RejectChanges();
		}

		public System.Data.IsolationLevel IsolationLevel {
			get { return IsolationLevel.Unspecified; }
		}

		#endregion

		#region IDisposable Members

		public void Dispose() {
			this.Rollback();
		}

		#endregion
	}
}
