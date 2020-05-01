using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace XmlParserCamt.XmlParser
{
	public class FileXmlManager
	{
		private IXmlParser _xmlparser;

		public FileXmlManager(IXmlParser xmlparser)
		{
			this._xmlparser = xmlparser;
		}
		public async Task ReadFile(string fileName, string destFileName)
		{
			await Task.Run(() => this.ReadFileFromFileName(fileName, destFileName));
		}
		private void ReadFileFromFileName(string fileName, string destFileName)
		{
			try
			{
				using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
				{
					long streamLength = stream.Length;
					byte[] buffer = new byte[streamLength];

					stream.Read(buffer, 0, (int) streamLength);

					Object parsedObject = _xmlparser.ParseXml(Encoding.UTF8.GetString(buffer));

					this.SaveFile(destFileName, parsedObject);
				}
			}
			catch(Exception ee)
			{
				Console.WriteLine($"{ee.ToString()}");
			}
			
		}

		private void SaveFile(string fileName, Object parsedObject)
		{
			try
			{
				using (Stream stream = File.Create(fileName))
				{
					string parsedString = (string)parsedObject.ToString();
					long parsedObjectLength = parsedString.Length;

					byte[] buffer = Encoding.UTF8.GetBytes(parsedString);

					stream.Write(buffer, 0, (int)parsedObjectLength);
				}
			}
			catch(Exception ee)
			{
				Console.WriteLine($"{ee.ToString()}");
			}
		}
	}
}
