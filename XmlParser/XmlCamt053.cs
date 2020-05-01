using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlParserCamt.XmlParser
{
	[Serializable]
	[XmlRoot("BkToCstmrStmt")]
	public class XmlCamt053
	{
		[XmlElement("Ntry")]
		public List<XmlCamt053Entry> Ntry = new List<XmlCamt053Entry>();
		public string ErrorMessage { get; set; }
		public object Ntries { get; set; }

		public override string ToString()
		{
			string result = string.Empty;
			if (this.ErrorMessage != "")
			{
				result = this.ErrorMessage;
			}
			else
			{
				foreach (var item in Ntry)
				{
					result += $"{item.ToString()}";
				}
			}
			return result;
		}
	}
}
