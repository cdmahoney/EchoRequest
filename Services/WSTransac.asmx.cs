using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace EchoRequest.Services
{
	// Interface.IMultasSoapBinding generated with wsdl.exe from Tao1.0 Multas wsdl. Generated
	// file is modified:
	//	- Unsupported methods commented
	//	- Soap Action added to supported methods.
	// Command to generate IMultasSoapBinding (from VS development tools):
	//	wsdl.exe wsdl\wstransac.wsdl /l:c# /serverInterface /n:EchoRequest.Interface
	/// <summary>
	/// Summary description for WSTransac
	/// </summary>
	public class WSTransac : System.Web.Services.WebService, Interface.IWSTransacSoapBinding
	{
		#region IWSTransacSoapBinding Members
		public string consultaExcallbyDboid(string dboid, string token, string hash)
		{
			int suffix = 0;
			if (!ExtCallOids.TryGetValue(dboid, out suffix))
			{
				ExtCallOids[dboid] = 0;
			}
			else
			{
				int index = (suffix + 1) % 3;
				ExtCallOids[dboid] = index;
			}
			string fileName = string.Format("wstransacConsultaExcallbyDboid0{0}.xml", suffix);
			string result = GetFromFile(fileName);
			return result;
		}
		#endregion
		private string GetFromFile(string fileName)
		{
			string result = string.Empty;
			result = Multas.ReadFile(Multas.XmlPath, fileName);
			return result;
		}
		private static Dictionary<string, int> _ExtCallOids;
		public static Dictionary<string, int> ExtCallOids
		{
			[System.Diagnostics.DebuggerStepThrough()]
			get
			{
				if (_ExtCallOids == null)
				{
					_ExtCallOids = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
				}
				return _ExtCallOids;
			}
		}
	}
}
