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
    [System.Web.Services.WebServiceBindingAttribute(Name="TAOWebServiceSoapBinding", Namespace="http://generic.services.conecta.es")]
    public interface ITAOWebServiceSoapBinding {
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://dto.commons.conecta.es/login", RequestNamespace = "http://generic.services.conecta.es", ResponseNamespace = "http://generic.services.conecta.es", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("loginReturn")]
        string login(string user, string password);
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://dto.commons.conecta.es/doOperationTAO", RequestNamespace = "http://generic.services.conecta.es", ResponseNamespace = "http://generic.services.conecta.es", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("doOperationTAOReturn")]
        string doOperationTAO(string xmlIn, string token);
    }
}
