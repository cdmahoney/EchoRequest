using System;
//using System.Collections.Generic;
using System.IO;
using System.Web;

namespace EchoRequest.Code.Services
{
	public static class AppConfig
	{
		public static void GetAppConfigServers(HttpResponse response, HttpRequest request)
		{
			string path = "/App_Data/AppConfigServers.json";
			string fullpath = HttpContext.Current.Server.MapPath(path);
			string fullpath2 = request.MapPath(path);


			// Cheap and cheerful
			byte[] content = File.ReadAllBytes(fullpath);
			response.OutputStream.Write(content, 0, content.Length);
		}
		public static void GetAppConfig(HttpResponse response, HttpRequest request)
		{
		}
	}
}
