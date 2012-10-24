using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace EchoRequest.Services
{
	/// <summary>
	/// Summary description for Multas
	/// </summary>
	//[WebService(Namespace = "http://echorequest.apphb.com//")]
	[WebService(Namespace = "http://impl.multas.gtwin.conecta")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	public class Multas : System.Web.Services.WebService
	{

		[WebMethod]
		public string login(string user, string password)
		{
			//string datetime = DateTime.Now.ToString("yyyyMMddHHmmss"); //"2012 10 18 13 34 44";
			//string token = string.Format("500000000000000001{0}", datetime);
			string result = string.Empty;
			if (UserToPassword[user] == password)
			{
				string token = UserToToken[user];
				string datetime = DateTime.Now.ToString("yyyyMMddHHmmss"); //"2012 10 18 13 34 44";
				string entity = "100100300001409600100";
				string agent = "1";
				string c60M3OrdCode = "170008";
				string ordCode = "410044";

				string formatXml = "<XML>" +
					"<TOKEN>{0}</TOKEN>" +
					"<FECHASISTEMA>{1}</FECHASISTEMA>" +
					"<ENTITY>{2}</ENTITY>" +
					"<MULAGENTE>{3}</MULAGENTE>" +
					"<C60M3ORDCODE>{4}</C60M3ORDCODE>" +
					"<ORDCODE>{5}</ORDCODE>" +
					"</XML>";

				result = string.Format(formatXml, token, datetime, entity, agent, c60M3OrdCode, ordCode);
			}
			return result;
		}

		[WebMethod]
		public string getLegislacionCode(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = "<XML><MULIDLEGI><LEGCODLEG>AMS</LEGCODLEG><LEGDESLEG>Legislación de AMS&amp;</LEGDESLEG></MULIDLEGI><MULIDLEGI><LEGCODLEG>LSV</LEGCODLEG><LEGDESLEG>Ley &apos; de Seguridad Vial&amp;</LEGDESLEG></MULIDLEGI><MULIDLEGI><LEGCODLEG>OMC</LEGCODLEG><LEGDESLEG>Ordenanza Municipal de Circulación</LEGDESLEG></MULIDLEGI><MULIDLEGI><LEGCODLEG>RGC</LEGCODLEG><LEGDESLEG>Reglamento General de Circulación</LEGDESLEG></MULIDLEGI></XML>";
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}

		public static Dictionary<string, string> UserToPassword
		{
			[System.Diagnostics.DebuggerStepThrough()]
			get
			{
				if (_UserToPassword == null)
				{
					_UserToPassword = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
					_UserToPassword["TAO"] = "";
				}
				return _UserToPassword;
			}
		}
		private static Dictionary<string, string> _UserToPassword;
		public static Dictionary<string, string> UserToToken
		{
			[System.Diagnostics.DebuggerStepThrough()]
			get
			{
				if (_UserToToken == null)
				{
					_UserToToken = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
					_UserToToken["TAO"] = "50000000000000000120121024054524";
				}
				return _UserToToken;
			}
		}
		private static Dictionary<string, string> _UserToToken;
		public static Dictionary<string, string> TokenToHash
		{
			[System.Diagnostics.DebuggerStepThrough()]
			get
			{
				if (_TokenToHash == null)
				{
					_TokenToHash = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
					_TokenToHash["50000000000000000120121024054524"] = "f452289656f9c3117269a0480a0c190d";
				}
				return _TokenToHash;
			}
		}
		private static Dictionary<string, string> _TokenToHash;
	}
}
