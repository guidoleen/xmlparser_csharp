using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlParserCamt.XmlParser
{
	public class XmlSerializerDeserializer<T>
	{
		public object Deserializer(string xml, string? xmlRootName, string? xmlNameSpace)
		{
			XmlRootAttribute xmlRoot = new XmlRootAttribute();
			XmlSerializer serializer;
			if (xmlRootName != "" || xmlNameSpace != "")
			{
				// Create Rootattribute for the xml settings if there is any
				xmlRoot.ElementName = xmlRootName;
				xmlRoot.Namespace = xmlNameSpace;
				xmlRoot.IsNullable = true;

				serializer = new XmlSerializer(typeof(T), xmlRoot);
			}
			else
				serializer = new XmlSerializer(typeof(T));

			T parsedXml;

			try
			{
				using (TextReader reader = new StringReader(xml))
				{
					parsedXml = (T)serializer.Deserialize(reader);
				}
			}
			catch (Exception ee)
			{
				return  ee.ToString();
			}

			return parsedXml;
		}
	}
}
