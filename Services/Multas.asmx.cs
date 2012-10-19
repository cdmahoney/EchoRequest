using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace EchoRequest.Services
{
	/// <summary>
	/// Summary description for Multas
	/// </summary>
	[WebService(Namespace = "http://echorequest.apphb.com//")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	public class Multas : System.Web.Services.WebService
	{

		[WebMethod]
		public string Login(string user, string password)
		{
			string datetime = DateTime.Now.ToString("yyyyMMddHHmmss"); //"2012 10 18 13 34 44";
			string token = string.Format("500000000000000001{0}", datetime);
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

			string result = string.Format(formatXml, token, datetime, entity, agent, c60M3OrdCode, ordCode);
			return result;
		}
	}
}
