using System;
using System.Reflection;
using System.Xml;

namespace XmlParserCamt.XmlParser
{
	public class XmlParserFromCamtDocumentXML : IXmlParser
	{
		public Object ParseXml(string xml)
		{
			XmlCamt053 xmlCamt053File = new XmlCamt053();
			XmlDocument xmlDocument = new XmlDocument();
			string parsedXml = "";

			try
			{
				xmlDocument.LoadXml(xml);
				// var singleNode = xmlDocument.SelectSingleNode("BkToCstmrStmt/Ntry/NtryDtls/Btch/NbOfTxs");

				var ntrtyList = xmlDocument.GetElementsByTagName(XmlCamt053Constants.Ntry);
				for (int i = 0; i < ntrtyList.Count; i++)
				{
					xmlCamt053File.Ntry.Add(
						this.FillNtryFromXml(ntrtyList.Item(i))
						);

					parsedXml += xmlCamt053File.Ntry[i].ToString() + @"\r\n"; // This can be a json serializer or parser
				}
			}
			catch(Exception ee)
			{
				Console.WriteLine(ee.ToString());
			}
			return parsedXml;
		}

		private XmlCamt053Entry FillNtryFromXml(XmlNode xmlNodeNtry)
		{
			XmlCamt053Entry xmlCamt053Entry = new XmlCamt053Entry();

				GetValuesFromNtryList(xmlNodeNtry, xmlCamt053Entry); // Recursive call

			return xmlCamt053Entry;
		}

		// Recursive iteration with a XmlNode over begin xml file or node eg root node
		private static void GetValuesFromNtryList(XmlNode xmlNode, XmlCamt053Entry xmlCamt053Entry)
		{
			if(xmlNode.HasChildNodes)
			{
				for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
				{
					GetValuesFromNtryList(xmlNode.ChildNodes[i], xmlCamt053Entry); // Recursive call
				}
			}
			if (xmlNode.Value != null || xmlNode.InnerText != "")
			{
				// Console.WriteLine($"{xmlNode.Name} - {xmlNode.InnerText}");
				GetValueFromXmlNode(xmlNode, xmlCamt053Entry);
			}
		}

		private static void GetValueFromXmlNode(XmlNode xmlNode, XmlCamt053Entry xmlCamt053Entry)
		{
			Type xmlCamt053EntryType = xmlCamt053Entry.GetType();
			PropertyInfo[] propertyInfos = xmlCamt053EntryType.GetProperties();

			foreach(var propertyInfo in propertyInfos)
			{
				if(propertyInfo.Name.Equals(xmlNode.Name))
				{
					var nodeValue = xmlNode.InnerText;
					propertyInfo.SetValue(xmlCamt053Entry, nodeValue);
				}
			}
		}
	}
}
