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
			Response.ContentType = "application/json";


			Response.Write("{");
			ProcessNvc("queryString", Request.QueryString);

			Response.Write(", ");
			ProcessFiles("files", Request.Files);

			Response.Write("}");

			Context.Response.End();
		}
		private void OpenJson(string name)
		{
			string json = string.Format("\"{0}\": {{", name);
			Response.Write(json);
		}
		private void CloseJson()
		{
			Response.Write("}");
		}
		private void ProcessNvc(string name, NameValueCollection nvc)
		{
			OpenJson(name);
			string comma = string.Empty;
			foreach (string key in nvc.AllKeys)
			{
				string json = string.Format("{0}\"{1}\": \"{2}\"", comma, key, nvc[key]);
				comma = ", ";
				Response.Write(json);
			}
			CloseJson();
		}
		private void ProcessFiles(string name, HttpFileCollection files)
		{
			OpenJson(name);
			string comma = string.Empty;
			foreach (string key in files.AllKeys)
			{
				HttpPostedFile file = files[key];
				byte[] bytes = new byte[file.ContentLength];
				file.InputStream.Read(bytes, 0, bytes.Length);
				string base64 = Convert.ToBase64String(bytes);
				string json = string.Format("{0}\"{1}\": \"{2}\"", comma, key, base64);
				comma = ", ";
			}
			CloseJson();
		}
	}
}
