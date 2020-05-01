using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlParserCamt.XmlParser
{
	[Serializable]
	// [XmlRoot("Ntry")]
	public class XmlCamt053Entry
	{
		public string NtryRef { get; set; }
		public string Amt { get; set; }
		[XmlIgnore]
		public string Ccy { get; set; }
		public string AcctSvcrRef { get; set; }
		public string MsgId { get; set; }

		public override string ToString()
		{
			return $"Amt: {Amt} - Ccy: {Ccy} - AcctSvcrRef: {AcctSvcrRef}";
		}
	}
}
