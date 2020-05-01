using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace XmlParserCamt.XmlParser
{
	public class XmlParserFromCamt053Serializer : IXmlParser
	{
		private string regexDocument = XmlCamt053Constants.RegexDocument;
		public object ParseXml(string xml)
		{
			XmlSerializerDeserializer<XmlCamt053> xmlSerializer = new XmlSerializerDeserializer<XmlCamt053>();
			return xmlSerializer.Deserializer(ParseXmlWithoutDocument(xml), "", "");
		}

		private string ParseXmlWithoutDocument(string xml)
		{
			return Regex.Replace(xml, XmlCamt053Constants.RegexDocument, "");
		}
	}
}
