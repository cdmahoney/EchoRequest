﻿using System;
using System.Text;


namespace EchoRequest.Code.Support
{
	public class SJavaScript
	{
		/// <summary>
		/// Encodes a string to be represented as a string literal. The format
		/// is essentially a JSON string.
		/// 
		/// The string returned includes outer quotes 
		/// Example Output: "Hello \"Rick\"!\r\nRock on"
		/// 
		/// See:
		///		http://www.west-wind.com/weblog/posts/2007/Jul/14/Embedding-JavaScript-Strings-from-an-ASPNET-Page
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string EncodeJsString(string s)
		{
			StringBuilder sb = new StringBuilder();
			//sb.Append("\"");
			foreach (char c in s)
			{
				switch (c)
				{
					case '\"':
						sb.Append("\\\"");
						break;
					//case '\'':
					//    // Added CDM 19/09/2012
					//    sb.Append("\\'");
					//    break;
					case '\\':
						sb.Append("\\\\");
						break;
					case '\b':
						sb.Append("\\b");
						break;
					case '\f':
						sb.Append("\\f");
						break;
					case '\n':
						sb.Append("\\n");
						break;
					case '\r':
						sb.Append("\\r");
						break;
					case '\t':
						sb.Append("\\t");
						break;
					default:
						int i = (int)c;
						if (i < 32 || i > 127)
						{
							sb.AppendFormat("\\u{0:X04}", i);
						}
						else
						{
							sb.Append(c);
						}
						break;
				}
			}
			//sb.Append("\"");

			return sb.ToString();
		}
	}
}
