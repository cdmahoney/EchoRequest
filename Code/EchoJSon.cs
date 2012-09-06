using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;

namespace EchoRequest.Code
{
	public class EchoJSon: Page
	{
		protected override void OnInit(EventArgs e)
		{
			ProcessRequest(Response, Request);
			//Response.ContentType = "application/json";

			//Response.Write("{");
			//ProcessNvc("headers", Request.Headers);

			////Response.Write(", ");
			////ProcessNvc("cookies", Request.Cookies);

			//Response.Write(", ");
			//ProcessNvc("queryString", Request.QueryString);

			//Response.Write(", ");
			//ProcessNvc("form", Request.Form);

			////Response.Write(", ");
			////ProcessNvc("serverVariables", Request.ServerVariables);

			//Response.Write(", ");
			//ProcessFiles("files", Request.Files);

			//Response.Write("}");

			//Context.Response.End();
		}
		public static void ProcessRequest(HttpResponse response, HttpRequest request)
		{
			response.ContentType = "application/json";

			response.Write("{");
			ProcessNvc(response, "headers", request.Headers);

			//Response.Write(", ");
			//ProcessNvc("cookies", Request.Cookies);

			WriteSeparator(response);
			ProcessNvc(response, "queryString", request.QueryString);

			WriteSeparator(response);
			ProcessNvc(response, "form", request.Form);

			WriteSeparator(response);
			ProcessFiles(response, "files", request.Files);

			response.Write("}");

			response.End();
		}
		public static void WriteSeparator(HttpResponse response)
		{
			response.Write(", " + Environment.NewLine);
		}
		private static void OpenJson(HttpResponse response, string name)
		{
			string json = string.Format("\"{0}\": {{", name);
			response.Write(json);
		}
		private static void CloseJson(HttpResponse response)
		{
			response.Write("}");
		}
		private static void ProcessNvc(HttpResponse response, string name, NameValueCollection nvc)
		{
			OpenJson(response, name);
			string comma = string.Empty;
			foreach (string key in nvc.AllKeys)
			{
				string json = string.Format("{0}\"{1}\": \"{2}\"", comma, key, nvc[key]);
				comma = ", ";
				response.Write(json);
			}
			CloseJson(response);
		}
		private static void ProcessFiles(HttpResponse response, string name, HttpFileCollection files)
		{
			OpenJson(response, name);
			string comma = string.Empty;
			foreach (string key in files.AllKeys)
			{
				HttpPostedFile file = files[key];
				byte[] bytes = new byte[file.ContentLength];
				file.InputStream.Read(bytes, 0, bytes.Length);
				string base64 = Convert.ToBase64String(bytes);
				string json = string.Format("{0}\"{1}\": \"{2}\"", comma, key, base64);
				comma = ", ";
				response.Write(json);
			}
			CloseJson(response);
		}
	}
}
