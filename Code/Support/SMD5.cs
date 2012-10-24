using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EchoRequest.Code.Support
{
	public class SMD5
	{
		// ms-help://MS.MSDNQTR.v80.en/MS.MSDN.v80/MS.NETDEVFX.v20.en/cpref11/html/T_System_Security_Cryptography_MD5.htm
		// Hash an input string and return the hash as
		// a 32 character hexadecimal string.
		public static string GetMd5Hash(string token)
		{
			// Create a new instance of the MD5CryptoServiceProvider object.
			MD5 md5 = MD5.Create();

			// Convert the input string to a byte array and compute the hash.
			byte[] hash_valueAnt = md5.ComputeHash(Encoding.Default.GetBytes(token));

			byte[] codigo = new byte[] { 57, 51, 50, 57, 52, 52 };

			List<byte> tokenList = new List<byte>(hash_valueAnt.Length + codigo.Length);
			tokenList.AddRange(hash_valueAnt);
			tokenList.AddRange(codigo);
			byte[] token2 = tokenList.ToArray();

			byte[] hash_value = md5.ComputeHash(token2);
			
			char[] chash_value = new char[hash_value.Length];
			for (int i = 0; i < hash_value.Length; i++)
			{
				if (hash_value[i] < 0)
				{
					chash_value[i] = (char)(hash_value[i] + 256);
				}
				else
				{
					chash_value[i] = (char)(hash_value[i]);
				}
			}

			// Get Hex Hash
			StringBuilder sb = new StringBuilder(chash_value.Length * 2);
			for (int x = 0; x < chash_value.Length; x++)
			{
				String sAux = "00" + (0xff & chash_value[x]).ToString("x2"); //Integer.toHexString(0xff & chash_value[x]);
				sb.Append(sAux.Substring(sAux.Length - 2,sAux.Length));
			}

			string result = sb.ToString();
			return result;

			//// Create a new Stringbuilder to collect the bytes
			//// and create a string.
			//StringBuilder sBuilder = new StringBuilder();

			//// Loop through each byte of the hashed data 
			//// and format each one as a hexadecimal string.
			//for (int i = 0; i < data.Length; i++)
			//{
			//    sBuilder.Append(data[i].ToString("x2"));
			//}

			//// Return the hexadecimal string.
			//return sBuilder.ToString();
		}

	}
}
