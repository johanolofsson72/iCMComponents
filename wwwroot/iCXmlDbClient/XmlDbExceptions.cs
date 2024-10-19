//**************************************************************//
// Paul Wilson -- www.WilsonDotNet.com -- Paul@WilsonDotNet.com //
// Feel free to use and modify -- just leave these credit lines //
// I also always appreciate any other public credit you provide //
//**************************************************************//
using System;

namespace iConsulting.iCXmlDbClient
{
	public class XmlDbException : System.Exception
	{
		internal XmlDbException(string message) : base(message) {}
		internal XmlDbException(string message, Exception inner) : base(message, inner) {}
	}

	public class XmlDbParseSqlException : XmlDbException {
		internal XmlDbParseSqlException(string message) : base(message) {}
		internal XmlDbParseSqlException(string message, Exception inner) : base(message, inner) {}
	}

	public class XmlDbNotSupportedException : XmlDbException {
		internal XmlDbNotSupportedException(string message) : base(message) {}
		internal XmlDbNotSupportedException(string message, Exception inner) : base(message, inner) {}
	}
}
