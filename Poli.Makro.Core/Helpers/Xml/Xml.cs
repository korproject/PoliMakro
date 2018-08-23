using System.Windows.Data;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Poli.Makro.Core.Helpers.Xml
{
	public class Xml
	{
		/// <summary>
		/// Xml to Json converter
		/// </summary>
		/// <param name="xmlString"></param>
		/// <returns></returns>
		public static string Xml2Json(string xmlString)
		{
			// create xml document
			var xmldoc = new XmlDocument();
			// parse xml data
			var xdoc = XDocument.Parse(xmlString).ToString().Trim();
			// load parsed xml data to xml doc
			xmldoc.LoadXml(xdoc);
			return JsonConvert.SerializeXmlNode(xmldoc);
		}

		/// <summary>
		/// Xml reformatter
		/// </summary>
		/// <param name="xmlString"></param>
		/// <returns></returns>
		public static string ReFormatXmlString(string xmlString)
		{
			 return XDocument.Parse(xmlString).ToString();
		}

		/// <summary>
		/// Xml bind builder
		/// </summary>
		/// <param name="xmlDocument"></param>
		/// <returns></returns>
		public static Binding BindXmlDocument(XmlDocument xmlDocument)
		{
			if (xmlDocument == null)
			{
				return null;
			}

			var provider = new XmlDataProvider
			{
				Document = xmlDocument
			};

			var binding = new Binding
			{
				Source = provider,
				XPath = "child::node()"
			};

			return binding;
		}
	}
}
