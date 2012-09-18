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
		}
		public static void GetAppConfig(HttpResponse response, HttpRequest request)
		{
			string file = "AppData\\AppConfigServers.json";
			// Cheap and cheerful
			byte[] content = File.ReadAllBytes(file);
			response.OutputStream.Write(content, 0, content.Length);
		}
	}
}
