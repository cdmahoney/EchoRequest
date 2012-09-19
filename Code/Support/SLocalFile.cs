using System;
using System.IO;
using System.Web;

namespace EchoRequest.Code.Support
{
	public static class SLocalFile
	{
		public static void StreamLocalFile(string filepath, HttpResponse response, HttpRequest request)
		{
			StreamLocalFile(filepath, string.Empty, response, request);
		}
		public static void StreamLocalFile(string filepath, string contentType, HttpResponse response, HttpRequest request)
		{
			string fullpath = HttpContext.Current.Server.MapPath(filepath);
			string fullpath2 = request.MapPath(filepath);

			if (contentType.Length > 0)
			{
				// Set content type
				response.ContentType = "application/json";
			}

			// Cheap and cheerful - not very efficient
			// Write content as text to prevent having to worry about character encoding
			string content = File.ReadAllText(fullpath);
			response.Write(content);
		}
	}
}
