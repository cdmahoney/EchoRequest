using System;
//using System.Collections.Generic;
using System.IO;
using System.Web;

namespace EchoRequest.Code.Services
{
	public static class AppConfig
	{
		private const string ContentTypeJson = "application/json";

		public static void GetAppConfigServers(HttpResponse response, HttpRequest request)
		{
			Support.SLocalFile.StreamLocalFile("/App_Data/AppConfigServers.json", ContentTypeJson, response, request);
			//string path = "/App_Data/AppConfigServers.json";
			//string fullpath = HttpContext.Current.Server.MapPath(path);
			//string fullpath2 = request.MapPath(path);

			//// Set content type
			//response.ContentType = "application/json";

			//// Cheap and cheerful - not very efficient
			//// Write content as text to prevent having to worry about character encoding
			//string content = File.ReadAllText(fullpath);
			//response.Write(content);
		}
		public static void GetAppConfig(HttpResponse response, HttpRequest request)
		{
			Support.SLocalFile.StreamLocalFile("/App_Data/AppConfig.json", ContentTypeJson, response, request);
		}

		//public static void GetLocalJson(string filepath, HttpResponse response, HttpRequest request)
		//{
		//    string fullpath = HttpContext.Current.Server.MapPath(filepath);
		//    string fullpath2 = request.MapPath(path);

		//    // Set content type
		//    response.ContentType = "application/json";

		//    // Cheap and cheerful - not very efficient
		//    // Write content as text to prevent having to worry about character encoding
		//    string content = File.ReadAllText(fullpath);
		//    response.Write(content);
		//}
	}
}
