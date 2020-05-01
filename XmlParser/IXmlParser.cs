using System;
using System.Collections.Generic;
using System.Text;

namespace XmlParserCamt.XmlParser
{
	public interface IXmlParser
	{
		object ParseXml(string xml);
	}
}
