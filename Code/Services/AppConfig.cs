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

			// Set content type
			response.ContentType = "application/json";
			//response.ContentType = "application/json; charset=utf-8";

			// Cheap and cheerful
			// Write content as text to prevent having to worry about character encoding
			string content = File.ReadAllText(fullpath);
			response.Write(content);
		}
		public static void GetAppConfig(HttpResponse response, HttpRequest request)
		{
		}
	}
}
