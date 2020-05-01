using System;
using XmlParserCamt.XmlParser;
using System.Threading.Tasks;

namespace XmlParserCamt
{
	class Program
	{
		static void Main(string[] args)
		{
			string inputFile = @"C:\Users\g.leen\Desktop\CAMT053_weg.xml"; // @"C:\Users\g.leen\Desktop\Issues\bfs-114\CAMT053_BUCKAROO_Deutschebank_voorbeeld.xml";
			string outputFile = @"C:\weg.txt";
			FileXmlManager mngr = new FileXmlManager(new XmlParserFromCamtDocumentXML()); // XmlParserFromCamt053Serializer());

			Task task = Task.Run(() => mngr.ReadFile(inputFile, outputFile));

			while (true) { }
		}
	}
}
