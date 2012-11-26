using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace EchoRequest.Services
{
	/// <summary>
	/// Summary description for TaoWebService
	/// </summary>
	public class TaoWebService : System.Web.Services.WebService, Interface.ITAOWebServiceSoapBinding
	{
		#region ITAOWebServiceSoapBinding Members
		public string login(string user, string password)
		{
			string result = string.Empty;
			if (Multas.UserToPassword[user] == password)
			{
				result = GetFromFile("taoLogin.xml");
			}
			return result;
		}
		public string doOperationTAO(string xmlIn, string token)
		{
			string result = string.Empty;
			System.Diagnostics.Debug.WriteLine(xmlIn);
			XmlDocument xmldoc = new XmlDocument();
			xmldoc.LoadXml(xmlIn);
			XmlNode operation = xmldoc.SelectSingleNode("//operationName");
			XmlNode data = xmldoc.SelectSingleNode("//data");
			XmlDocument xmlData = new XmlDocument();
			xmlData.LoadXml(data.InnerText);

			switch (operation.InnerText)
			{
				case "InfoFromMatricula":
					{
						string matricula = xmlData.SelectSingleNode("//MATPROV").InnerText +
							xmlData.SelectSingleNode("//MATCODIGO").InnerText +
							xmlData.SelectSingleNode("//MATLETRA").InnerText;
						string fileName = "taoMultasInfoFromMatricula" + matricula + ".xml";
						if (Multas.FileExists(Multas.XmlPath, fileName))
						{
							result = GetFromFile(fileName);
						}
						else
						{
							result = GetFromFile("taoMultasInfoFromMatriculaError.xml");
						}
					}
					break;
				default:
					result = GetFromFile("taoMultas" + operation.InnerText + ".xml");
					break;
			}

			return result;
		}
		#endregion
		private string GetFromFile(/*string token, string hash,*/ string fileName)
		{
			string result = string.Empty;
			//string serverHash;
			//if (Multas.TokenToHash.TryGetValue(token, out serverHash) && serverHash == hash)
			//{
			result = Multas.ReadFile(Multas.XmlPath, fileName);
			//}
			//else
			//{
			//    result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			//}
			return result;
		}
	}
}
