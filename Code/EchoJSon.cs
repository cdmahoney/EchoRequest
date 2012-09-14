using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Web;
using System.Web.UI;

namespace EchoRequest.Code
{
	public class EchoJSon: Page
	{
		private const string PNService = "Service";
		public enum Service
		{
			None,
			Echo
		}

		protected override void OnInit(EventArgs e)
		{
			//ProcessRequest(Response, Request);
			string serviceName = GetSingleKvpValue(Context.Request, PNService, string.Empty);
			if (serviceName.Length == 0)
			{
				throw new InvalidOperationException(string.Format("Required parameter '{0}' missing", PNService));
			}
			Service service = (Service)Enum.Parse(typeof(Service), serviceName, true);
			switch (service)
			{
				case Service.Echo:
					ProcessEchoRequest(Response, Request);
					break;
				default:
					throw new InvalidOperationException(string.Format("Requested service '{0}' not supported", serviceName));
					break;
			}
		}
		public static string GetSingleValue(NameValueCollection nvc, string key, string @default)
		{
			if (nvc == null)
			{
				throw new ArgumentNullException("nvc");
			}

			string result = @default;
			string[] values = nvc.GetValues(key);
			if (values != null && values.Length > 0)
			{
				result = values[0];
			}
			return result;
		}
		public static string GetSingleKvpValue(HttpRequest request, string key, string @default)
		{
			string result = GetSingleValue(request.QueryString, key, null);
			if (result == null)
			{
				result = GetSingleValue(request.Form, key, @default);
			}
			return result;
		}

		public static void ProcessEchoRequest(HttpResponse response, HttpRequest request)
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
		public static void WriteKeyValue(HttpResponse response, ref string comma, string key, object value)
		{
			string json = string.Format("{0}\"{1}\": \"{2}\"", comma, key, value);
			response.Write(json);
			comma = ", ";
		}
		private const string TokenBraceOpen = "{";
		private const string TokenBraceClose = "}";
		private const string TokenBracketOpen = "[";
		private const string TokenBracketClose = "]";
		private static void OpenJson(HttpResponse response, string name, string token)
		{
			string json = token;
			if (name.Length > 0)
			{
				json = string.Format("\"{0}\": {1}", name, token);
			}
			response.Write(json);
		}
		private static void CloseJson(HttpResponse response, string token)
		{
			response.Write(token);
		}
		private static void OpenJson(HttpResponse response, string name)
		{
			OpenJson(response, name, TokenBraceOpen);
		}
		private static void CloseJson(HttpResponse response)
		{
			CloseJson(response, TokenBraceClose);
		}
		//private static void OpenJsonArray(HttpResponse response)
		//{
		//    string json = string.Format("[");
		//    response.Write(json);
		//}
		//private static void CloseJsonArray(HttpResponse response)
		//{
		//    response.Write("]");
		//}
		private static void ProcessNvc(HttpResponse response, string name, NameValueCollection nvc)
		{
			OpenJson(response, name);
			string comma = string.Empty;
			foreach (string key in nvc.AllKeys)
			{
				WriteKeyValue(response, ref comma, key, nvc[key]);
				//string json = string.Format("{0}\"{1}\": \"{2}\"", comma, key, nvc[key]);
				//comma = ", ";
				//response.Write(json);
			}
			CloseJson(response);
		}
		private static void ProcessFiles(HttpResponse response, string name, HttpFileCollection files)
		{
			OpenJson(response, name, TokenBracketOpen);
			string comma = string.Empty;
			foreach (string key in files.AllKeys)
			{
				HttpPostedFile file = files[key];

				//string base64 = string.Format("{0} bytes", file.ContentLength);
				byte[] bytes = new byte[file.ContentLength];
				file.InputStream.Read(bytes, 0, bytes.Length);
				string base64 = Convert.ToBase64String(bytes);

				OpenJson(response, string.Empty);
				var commaFile = string.Empty;
				WriteKeyValue(response, ref commaFile, "contentLength", file.ContentLength);
				WriteKeyValue(response, ref commaFile, "contentType", file.ContentType);
				WriteKeyValue(response, ref commaFile, "fileName", file.FileName);
				WriteKeyValue(response, ref commaFile, "base64Content", base64);
				CloseJson(response);
				response.Write(comma);
				comma = ", ";
			}
			CloseJson(response, TokenBracketClose);
		}
		private static ImageFormat GetImageFormat(string contentType)
		{
			ImageFormat result = null;
			switch (contentType)
			{
				case "image/gif":
					result = ImageFormat.Gif;
					break;
				case "image/jpeg":
					result = ImageFormat.Jpeg;
					break;
				case "image/png":
					result = ImageFormat.Png;
					break;
			}
			return result;
		}
		private static string GetExtension(string contentType)
		{
			string result = string.Empty;
			switch (contentType)
			{
				case "image/gif":
					result = ".gif";
					break;
				case "image/jpeg":
					result = ".jpg";
					break;
				case "image/png":
					result = ".png";
					break;
			}
			return result;
		}
		private static string SaveImageFiles(HttpFileCollection files)
		{
			StringBuilder sb = new StringBuilder("{files: [");
			string comma = string.Empty;
			foreach (string key in files.AllKeys)
			{
				HttpPostedFile file = files[key];
				ImageFormat format = GetImageFormat(file.ContentType);
				if (format != null)
				{
					string extension = GetExtension(file.ContentType);
					var path = HttpContext.Current.Server.MapPath(file.FileName + extension);
					sb.AppendFormat("{0}\"{1}\"", comma, path);
					comma = ", ";
					Image image = Image.FromStream(file.InputStream);
					if (file.InputStream.CanSeek)
					{
						file.InputStream.Seek(0, System.IO.SeekOrigin.Begin);
					}
					image.Save(path, format);
				}
			}
			sb.Append("]}");
			return sb.ToString();
		}
	}
}
