using System;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoRequest
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.Write("<h2>Query params</h2>");
			foreach (string paramKey in Request.QueryString.AllKeys)
			{
				Response.Write(paramKey + " = " + Request.QueryString[paramKey] + "<br>");
			}

			Response.Write("<h2>Files</h2>");
			HttpFileCollection files = Request.Files;
			foreach (string key in files.AllKeys)
			{
				Response.Write("File: " + Server.HtmlEncode(key) + "<br>");
				HttpPostedFile file = files[key];
				byte[] bytes = new byte[file.ContentLength];
				file.InputStream.Read(bytes, 0, bytes.Length);
				string base64 = Convert.ToBase64String(bytes);
				Response.Write("Content: " + base64 + "<br>");
			}
		}
	}
}
