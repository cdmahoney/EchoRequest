using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

namespace EchoRequest.Services
{
	// Interface.IMultasSoapBinding generated with wsdl.exe from Tao1.0 Multas wsdl. Generated
	// file is modified:
	//	- Unsupported methods commented
	//	- Soap Action added to supported methods.
	// Command to generate IMultasSoapBinding (from VS development tools):
	//	wsdl.exe multas.wsdl /l:c# /serverInterface /n:EchoRequest.Interface
	/// <summary>
	/// Summary description for Multas
	/// </summary>
	//[WebService(Namespace = "http://echorequest.apphb.com//")]
	//[WebService(Namespace = "http://impl.multas.gtwin.conecta")]
	//[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	//[System.ComponentModel.ToolboxItem(false)]
	public class Multas : System.Web.Services.WebService, Interface.IMultasSoapBinding
	{
		[WebMethod]
		public string login(string user, string password)
		{
			//string datetime = DateTime.Now.ToString("yyyyMMddHHmmss"); //"2012 10 18 13 34 44";
			//string token = string.Format("500000000000000001{0}", datetime);
			string result = string.Empty;
			if (UserToPassword[user] == password)
			{
				string token = UserToToken[user];
				string datetime = DateTime.Now.ToString("yyyyMMddHHmmss"); //"2012 10 18 13 34 44";
				string entity = "100100300001409600100";
				string agent = "1";
				string c60M3OrdCode = "170008";
				string ordCode = "410044";

				string formatXml = "<XML>" +
					"<TOKEN>{0}</TOKEN>" +
					"<FECHASISTEMA>{1}</FECHASISTEMA>" +
					"<ENTITY>{2}</ENTITY>" +
					"<MULAGENTE>{3}</MULAGENTE>" +
					"<C60M3ORDCODE>{4}</C60M3ORDCODE>" +
					"<ORDCODE>{5}</ORDCODE>" +
					"</XML>";

				result = string.Format(formatXml, token, datetime, entity, agent, c60M3OrdCode, ordCode);
			}
			return result;
		}

		public string getDetail(string boletinId, string token, string hash)
		{
			string result = string.Empty;
			if (CheckLogin(token, hash))
			{
				string detail;
				if (FineIdToDetail.TryGetValue(boletinId, out detail))
				{
					result = detail;
				}
				else
				{
					result = "<XML> <ERROR> <CODE>13</CODE> <DESCRIPTION>No se ha encontrado el expediente de multas</DESCRIPTION> <TYPE>W</TYPE> </ERROR> </XML>";
				}
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}

		[WebMethod]
		public string getLegislacionCode(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = "<XML><MULIDLEGI><LEGCODLEG>AMS</LEGCODLEG><LEGDESLEG>Legislación de AMS&amp;</LEGDESLEG></MULIDLEGI><MULIDLEGI><LEGCODLEG>LSV</LEGCODLEG><LEGDESLEG>Ley &apos; de Seguridad Vial&amp;</LEGDESLEG></MULIDLEGI><MULIDLEGI><LEGCODLEG>OMC</LEGCODLEG><LEGDESLEG>Ordenanza Municipal de Circulación</LEGDESLEG></MULIDLEGI><MULIDLEGI><LEGCODLEG>RGC</LEGCODLEG><LEGDESLEG>Reglamento General de Circulación</LEGDESLEG></MULIDLEGI></XML>";
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}

		[WebMethod]
		public string getBrowseExp(string xmlIn, string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = "<XML><MULEXPMUL><MULFECINF>20091028144300</MULFECINF><MULIDEBOL>2009-Z-00000123</MULIDEBOL><MULMATRIC>A -3432  -B</MULMATRIC><ARCHIVADO>T</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091029143300</MULFECINF><MULIDEBOL>2009-Z-00000124</MULIDEBOL><MULMATRIC>  -7239  -DVP</MULMATRIC><ARCHIVADO>T</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091102161200</MULFECINF><MULIDEBOL>2009-Z-00000125</MULIDEBOL><MULMATRIC>B -3500  -FU</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091103121600</MULFECINF><MULIDEBOL>2009-Z-00000126</MULIDEBOL><MULMATRIC>B -3500  -FU</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091103125100</MULFECINF><MULIDEBOL>2009-Z-00000127</MULIDEBOL><MULMATRIC>B -3500  -FU</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091118154100</MULFECINF><MULIDEBOL>2009-Z-00000128</MULIDEBOL><MULMATRIC>B -3500  -FU</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091124103700</MULFECINF><MULIDEBOL>2009-Z-00000129</MULIDEBOL><MULMATRIC>B -3500  -FU</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091124114700</MULFECINF><MULIDEBOL>2009-Z-00000130</MULIDEBOL><MULMATRIC>B -3500  -FU</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091124121800</MULFECINF><MULIDEBOL>2009-Z-00000131</MULIDEBOL><MULMATRIC>B -3500  -FU</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091130112800</MULFECINF><MULIDEBOL>2009-Z-00000132</MULIDEBOL><MULMATRIC>B -3500  -FU</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091209101700</MULFECINF><MULIDEBOL>2009-Z-00000133</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215114200</MULFECINF><MULIDEBOL>2009-Z-00000134</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215115100</MULFECINF><MULIDEBOL>2009-Z-00000135</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215115300</MULFECINF><MULIDEBOL>2009-Z-00000136</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215121900</MULFECINF><MULIDEBOL>2009-Z-00000137</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215122300</MULFECINF><MULIDEBOL>2009-Z-00000138</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215122900</MULFECINF><MULIDEBOL>2009-Z-00000139</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215125900</MULFECINF><MULIDEBOL>2009-Z-00000140</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215130500</MULFECINF><MULIDEBOL>2009-Z-00000141</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215130700</MULFECINF><MULIDEBOL>2009-Z-00000142</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215130900</MULFECINF><MULIDEBOL>2009-Z-00000143</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215133600</MULFECINF><MULIDEBOL>2009-Z-00000144</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215133900</MULFECINF><MULIDEBOL>2009-Z-00000145</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215155900</MULFECINF><MULIDEBOL>2009-Z-00000146</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215160800</MULFECINF><MULIDEBOL>2009-Z-00000147</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215161200</MULFECINF><MULIDEBOL>2009-Z-00000148</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215163300</MULFECINF><MULIDEBOL>2009-Z-00000149</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215164700</MULFECINF><MULIDEBOL>2009-Z-00000150</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215165000</MULFECINF><MULIDEBOL>2009-Z-00000151</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215165100</MULFECINF><MULIDEBOL>2009-Z-00000152</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215165400</MULFECINF><MULIDEBOL>2009-Z-00000153</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215172700</MULFECINF><MULIDEBOL>2009-Z-00000154</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091215173200</MULFECINF><MULIDEBOL>2009-Z-00000155</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20091228175600</MULFECINF><MULIDEBOL>2009-Z-00000156</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100105191800</MULFECINF><MULIDEBOL>2010-Z-00000162</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100113113900</MULFECINF><MULIDEBOL>2010-Z-00000163</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100113115000</MULFECINF><MULIDEBOL>2010-Z-00000164</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100118115000</MULFECINF><MULIDEBOL>2010-Z-00000165</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>T</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100118120100</MULFECINF><MULIDEBOL>2010-Z-00000166</MULIDEBOL><MULMATRIC>  -1743  -DSV</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100125102100</MULFECINF><MULIDEBOL>2010-Z-00000168</MULIDEBOL><MULMATRIC>  -1743  -DSV</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100203161700</MULFECINF><MULIDEBOL>2010-Z-00000172</MULIDEBOL><MULMATRIC>  -1743  -DSV</MULMATRIC><ARCHIVADO>T</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100203162600</MULFECINF><MULIDEBOL>2010-Z-00000173</MULIDEBOL><MULMATRIC>  -1743  -DSV</MULMATRIC><ARCHIVADO>T</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100203164500</MULFECINF><MULIDEBOL>2010-Z-00000174</MULIDEBOL><MULMATRIC>  -1743  -DSV</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100423120100</MULFECINF><MULIDEBOL>2010-Z-00000175</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100423120500</MULFECINF><MULIDEBOL>2010-Z-00000176</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100423121500</MULFECINF><MULIDEBOL>2010-Z-00000178</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100423121900</MULFECINF><MULIDEBOL>2010-Z-00000179</MULIDEBOL><MULMATRIC>M -0010  -AD</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100815120000</MULFECINF><MULIDEBOL>0641100000004</MULIDEBOL><MULMATRIC>  -1743  -DSA</MULMATRIC><ARCHIVADO>T</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20100106090000</MULFECINF><MULIDEBOL>2010-A-00000001</MULIDEBOL><MULMATRIC>  -3932  -DTC</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20110930132700</MULFECINF><MULIDEBOL>2011-Z-00000180</MULIDEBOL><MULMATRIC>  -7239  -DVP</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL><MULEXPMUL><MULFECINF>20120601100000</MULFECINF><MULIDEBOL>2012-0-11111111</MULIDEBOL><MULMATRIC>  -1743  -DSV</MULMATRIC><ARCHIVADO>F</ARCHIVADO></MULEXPMUL></XML>";
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}

		[System.Web.Services.WebMethodAttribute()]
		public string getInfraccionXml(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = ReadFile(XmlPath, "multasInfraccionXml.xml");
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}
		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		public string getUltimaSincronizacionByEntity(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = ReadFile(XmlPath, "multasUltimaSincronizacionByEntity.xml");
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}
		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		public string getEnCalidadDe(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = ReadFile(XmlPath, "multasEnCalidadDe.xml");
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}
		[System.Web.Services.WebMethodAttribute()]
		public string getGruas(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = ReadFile(XmlPath, "multasGruas.xml");
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}
		[System.Web.Services.WebMethodAttribute()]
		public string getInstrumentoMedida(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = ReadFile(XmlPath, "multasInstrumentoMedida.xml");
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}
		[System.Web.Services.WebMethodAttribute()]
		public string getAgente(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = ReadFile(XmlPath, "multasAgente.xml");
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}
		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		public string getStreets(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = ReadFile(XmlPath, "multasStreet.xml");
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}
		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		public string getMarcas(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = ReadFile(XmlPath, "multasMarcas.xml");
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}
		[System.Web.Services.WebMethodAttribute()]
		public string getTipoVehiculos(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = ReadFile(XmlPath, "multasTipoVehiculos.xml");
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}
		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		public string getMotivosNoNotificacion(string token, string hash)
		{
			string result = string.Empty;
			if (TokenToHash[token] == hash)
			{
				result = ReadFile(XmlPath, "multasMotivosNoNotificacion.xml");
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}
		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		public string getInfoFromMatricula(string xmlIn, string token, string hash)
		{
			string fileName;
			if(!XmlToInfoMatriculaFile.TryGetValue(RemoveWhitespace(xmlIn), out fileName))
			{
				fileName = "multasInfoMatriculaNotFound.xml";
			}
			string result = GetFromFile(token, hash, fileName);
			return result;
		}


		private string RemoveWhitespace(string s)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];
				if(!Char.IsWhiteSpace(c))
				{
					sb.Append(c);
				}
			}
			string result = sb.ToString();
			return result;
		}
		private string GetFromFile(string token, string hash, string fileName)
		{
			string result = string.Empty;
			string serverHash;
			if (TokenToHash.TryGetValue(token, out serverHash) && serverHash == hash)
			{
				result = ReadFile(XmlPath, fileName);
			}
			else
			{
				result = "<XML><ERROR><DESCRIPTION>ERROR: Error de Seguridad. No se ha podido encontar el algoritmo de seguridad.Error de Seguridad. No se ha podido validar el usuario</DESCRIPTION><TYPE>E</TYPE></ERROR></XML>";
			}
			return result;
		}
		private static bool CheckLogin(string token, string hash)
		{
			string storedHash;
			bool result = TokenToHash.TryGetValue(token, out storedHash) && hash == storedHash;
			return result;
		}
		private static string ReadFile(string path, string name)
		{
			string fullPath = Path.Combine(path, name);
			fullPath = HttpContext.Current.Server.MapPath(fullPath);
			string result = File.ReadAllText(fullPath);
			return result;
		}
		public static string XmlPath { [System.Diagnostics.DebuggerStepThrough()] get { return "..\\Xml"; } }
		public static Dictionary<string, string> UserToPassword
		{
			[System.Diagnostics.DebuggerStepThrough()]
			get
			{
				if (_UserToPassword == null)
				{
					_UserToPassword = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
					_UserToPassword["TAO"] = "";
				}
				return _UserToPassword;
			}
		}
		private static Dictionary<string, string> _UserToPassword;
		public static Dictionary<string, string> UserToToken
		{
			[System.Diagnostics.DebuggerStepThrough()]
			get
			{
				if (_UserToToken == null)
				{
					_UserToToken = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
					_UserToToken["TAO"] = "50000000000000000120121024054524";
				}
				return _UserToToken;
			}
		}
		private static Dictionary<string, string> _UserToToken;
		public static Dictionary<string, string> TokenToHash
		{
			[System.Diagnostics.DebuggerStepThrough()]
			get
			{
				if (_TokenToHash == null)
				{
					_TokenToHash = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
					_TokenToHash["50000000000000000120121024054524"] = "f452289656f9c3117269a0480a0c190d";
				}
				return _TokenToHash;
			}
		}
		private static Dictionary<string, string> _TokenToHash;
		public static Dictionary<string, string> FineIdToDetail
		{
			[System.Diagnostics.DebuggerStepThrough()]
			get
			{
				if (_FineIdToDetail == null)
				{
					_FineIdToDetail = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
					_FineIdToDetail["2012-0-11111111"] = "<XML><MULFECINF>20120601100000</MULFECINF><MULOIDIPR>210330400976374806402</MULOIDIPR><MULOIDEXI>101604200424061309900</MULOIDEXI><MULNOTMAN>F</MULNOTMAN><MULNONOTI>1</MULNONOTI><MULOIDVIA>101800000002011908000</MULOIDVIA><MULNUMVI1>12</MULNUMVI1><MULOIDEXV></MULOIDEXV><MULTITNOM>RODRIGUEZ*IBAÑEZ,ROLO</MULTITNOM><MULTITACR>ES</MULTITACR><MULTITIDE>033500866</MULTITIDE><MULTITCON>D</MULTITCON><MULTITOID>2000504200201238209900</MULTITOID><MULTITDIR>PZ JAZMIN,    1 Esc 1 1º A</MULTITDIR><MULTITMUN>ALCALA DE HENARES</MULTITMUN><MULTITPRO>MADRID</MULTITPRO><MULTITPAI>ESPAÑA</MULTITPAI><MULINFNOM>RODRIGUEZ*IBAÑEZ,ROLO</MULINFNOM><MULINFACR>ES</MULINFACR><MULINFIDE>033500866</MULINFIDE><MULINFCON>D</MULINFCON><MULINFOID>2000504200201238209900</MULINFOID><MULINFDIR>PZ JAZMIN,    1 Esc 1 1º A</MULINFDIR><MULINFMUN>ALCALA DE HENARES</MULINFMUN><MULINFPRO>MADRID</MULINFPRO><MULINFPAI>ESPAÑA</MULINFPAI><MULCODAG1>1</MULCODAG1><MULCODAG2></MULCODAG2><MULCODGRU></MULCODGRU><MULCODAPA></MULCODAPA><MULMATRIC>  -1743  -DSV</MULMATRIC><MULTIPVEH>1</MULTIPVEH><MULMARVEH></MULMARVEH><MULMARCA>0</MULMARCA><MULCOLVEH></MULCOLVEH><MULOIDCOM></MULOIDCOM><MULINSTIC>100100300001409600100</MULINSTIC><MULCREDAT>20120703174526</MULCREDAT><MULIDEBOL>2012-0-11111111</MULIDEBOL><MULTINFOVIAEXTEND></MULTINFOVIAEXTEND><MULTITPERSON>2000404200184022709900</MULTITPERSON><MULTITADDRESS>100900400010598400100</MULTITADDRESS><MULINFPERSON>2000404200184022709900</MULINFPERSON><MULINFADDRESS>100900400010598400100</MULINFADDRESS></XML>";
				}
				return _FineIdToDetail;
			}
		}
		private static Dictionary<string, string> _FineIdToDetail;

		public static Dictionary<string, string> XmlToInfoMatriculaFile
		{
			[System.Diagnostics.DebuggerStepThrough()]
			get
			{
				if (_XmlToInfoMatricula == null)
				{
					_XmlToInfoMatricula = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
					_XmlToInfoMatricula["<XML><MATPROV>B</MATPROV><MATCODIGO>3500</MATCODIGO><MATLETRA>FU</MATLETRA><MATEXTRA></MATEXTRA><FECINFRA></FECINFRA></XML>"] = 
						"multasInfoMatriculaB3500FU.xml";
					_XmlToInfoMatricula["<XML><MATPROV></MATPROV><MATCODIGO>1743</MATCODIGO><MATLETRA>DSA</MATLETRA><MATEXTRA></MATEXTRA><FECINFRA></FECINFRA></XML>"] =
						"multasInfoMatricula1743DSA.xml";
				}
				return _XmlToInfoMatricula;
			}
		}
		private static Dictionary<string, string> _XmlToInfoMatricula;
	}
}
