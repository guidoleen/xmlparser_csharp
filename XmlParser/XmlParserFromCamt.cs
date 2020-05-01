using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;

namespace XmlParserCamt.XmlParser
{
	public class XmlParserFromCamt : IXmlParser
	{
		public object ParseXml(string xml)
		{
			XmlCamt053 xmlCamt053 = new XmlCamt053();
		
			this.SetEntriesFromCamt(xmlCamt053, xml);

			Console.WriteLine($"{xmlCamt053.ToString()}");

			return xmlCamt053;
		}

		private string SetEntriesFromCamt(XmlCamt053 xmlCamt, string xml)
		{
			string ntryTagName = "Ntry";
			string beginTag = $"<{ntryTagName}>";
			string endTag = $"</{ntryTagName}>";

			string[] xmlTags = xml.Split(@"<");
			string xmlResult = "";
			bool isMatch = false;

			for (int i = 0; i < xmlTags.Length; i++)
			{
				if (Regex.IsMatch(@"<" + xmlTags[i], beginTag))
				{
					isMatch = true;
					i++;
				}
				if (Regex.IsMatch(@"<" + xmlTags[i], endTag))
				{
					isMatch = false;
					XmlCamt053Entry xmlCamt053Entry = this.CreateXmlCamt053Entry(xmlResult);

					// xmlCamt.Ntry.Add(xmlCamt053Entry.NtryRef, xmlCamt053Entry);
				}

				if (isMatch)
				{
					xmlResult += $"<{xmlTags[i]}";
				}
				if(!isMatch)
				{
					xmlResult = string.Empty;
				}
				
			}
			return "";
		}

		private XmlCamt053Entry CreateXmlCamt053Entry(string xmlResult)
		{
			var xmlCamt053Entry =  new XmlCamt053Entry();
			Type xmlCamtTagsType = xmlCamt053Entry.GetType();
			PropertyInfo[] xmlTagsProperties =  xmlCamtTagsType.GetProperties();

			foreach (var xmlTagsPropertie in xmlTagsProperties)
			{
				var valueFromXml = this.GetValueBetweenTags(xmlTagsPropertie.Name, xmlResult);

				xmlCamt053Entry.GetType()
					.GetProperty(xmlTagsPropertie.Name)
					.SetValue(xmlCamt053Entry, valueFromXml);
			
			}
			return xmlCamt053Entry;
		}

		private string GetValueBetweenTags(string fieldInfo, string xmlResult)
		{
			// /(<th>|<TH>)(.*)(<\/th>|<\/TH>)/gms
			string pattern = @$"(<{fieldInfo}>)(.*?)(</{fieldInfo}>)";

			Regex regex = new Regex(pattern, RegexOptions.Singleline);
			Match match = regex.Match(xmlResult);
			GroupCollection? group = match.Groups;

			if (group == null) return "";

			return group[2].ToString();
		}
	}
}
