﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.5446
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=2.0.50727.3038.
// 
namespace EchoRequest.Interface {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WSTransacSoapBinding", Namespace="http://impl.transac.gtwin.conecta")]
    public interface IWSTransacSoapBinding {
        
		///// <remarks/>
		//[System.Web.Services.WebMethodAttribute()]
		//[System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://impl.transac.gtwin.conecta", ResponseNamespace="http://impl.transac.gtwin.conecta", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		//[return: System.Xml.Serialization.XmlElementAttribute("createAsyncCallReturn")]
		//string createAsyncCall(string xmlIn, string operacion, string token, string hash);

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.transac.gtwin.conecta/consultaExcallbyDboid", RequestNamespace = "http://impl.transac.gtwin.conecta", ResponseNamespace = "http://impl.transac.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("consultaExcallbyDboidReturn")]
		string consultaExcallbyDboid(string dboid, string token, string hash);
	}
}
