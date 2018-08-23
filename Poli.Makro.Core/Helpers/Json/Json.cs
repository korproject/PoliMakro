using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace Poli.Makro.Core.Helpers.Json
{
	public class Json
	{
		#region Constructors

		/// <summary>
		/// Json validation error string content
		/// </summary>
		public static string JsonValidationError { get; set; }

		#endregion

		#region Methods
		
		/// <summary>
		/// Json string data re formatter
		/// </summary>
		/// <param name="jsonString"></param>
		/// <returns></returns>
		public static string ReFormatJsonString(string jsonString)
		{
			return JsonConvert.SerializeObject(JsonConvert.DeserializeObject(jsonString), Formatting.Indented);
		}

		/// <summary>
		/// Json string parse and returns TreeView
		/// </summary>
		/// <param name="jsonString"></param>
		/// <returns></returns>
		public static List<JToken> JsonStringToList(string jsonString)
		{
			var children = new List<JToken>();
			var token = JToken.Parse(jsonString);

			if (token != null)
			{
				children.Add(token);
			}

			return children;
		}

		/// <summary>
		/// Validating json string data
		/// </summary>
		/// <param name="jsonString"></param>
		/// <returns></returns>
		public static bool IsValidJson(string jsonString)
		{
			jsonString = jsonString.Trim();
			if ((!jsonString.StartsWith("{") || !jsonString.EndsWith("}")) && (!jsonString.StartsWith("[") || !jsonString.EndsWith("]")))
				return false;

			try
			{
				JToken.Parse(jsonString);
				return true;
			}
			catch (JsonReaderException jex)
			{
				JsonValidationError = jex.Message;
				return false;
			}
		}

		/// <summary>
		/// Json to Xml converter
		/// </summary>
		/// <param name="jsonString"></param>
		/// <returns></returns>
		public static string Json2Xml(string jsonString)
		{
			return JsonConvert.DeserializeXmlNode(jsonString, "root").ToString();
		}
		#endregion
	}
}
