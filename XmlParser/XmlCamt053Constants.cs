using System;
using System.Collections.Generic;
using System.Text;

namespace XmlParserCamt.XmlParser
{
	public static class XmlCamt053Constants
	{
		public static string Ntry = "Ntry";
		public static string NtryRef = "NtryRef";
		public static string Amt = "Amt";
		public static string Ccy = "Ccy";
		public static string AcctSvcrRef = "AcctSvrRef";

		public static string RegexDocument = "(<Document)(.*)|(xmlns=\"(.*)\">)|</Document>";
			
		internal static class XmlDocumentSettings
		{
			public static string XmlRoot = "Document";
			public static string XmlNameSpace = "urn:iso:std:iso:20022:tech:xsd:camt.053.001.02";
		}
	}
}
