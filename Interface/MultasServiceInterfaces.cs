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
    [System.Web.Services.WebServiceBindingAttribute(Name="MultasSoapBinding", Namespace="http://impl.multas.gtwin.conecta")]
    public interface IMultasSoapBinding {
        
        /// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getDetail", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getDetailReturn")]
		string getDetail(string boletinId, string token, string hash);
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/login", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("loginReturn")]
        string login(string user, string password);
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getLegislacionCode", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("getLegislacionCodeReturn")]
        string getLegislacionCode(string token, string hash);
        
        /// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getInfraccionXml", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getInfraccionXmlReturn")]
		string getInfraccionXml(string token, string hash);
        
        /// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getInfoFromMatricula", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getInfoFromMatriculaReturn")]
		string getInfoFromMatricula(string xmlIn, string token, string hash);
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getTipoVehiculos", RequestNamespace="http://impl.multas.gtwin.conecta", ResponseNamespace="http://impl.multas.gtwin.conecta", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getTipoVehiculosReturn")]
		string getTipoVehiculos(string token, string hash);

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getMotivosNoNotificacion", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getMotivosNoNotificacionReturn")]
		string getMotivosNoNotificacion(string token, string hash);

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getPerson", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getPersonReturn")]
		string getPerson(string dni, string token, string hash);

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getStreets", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getStreetsReturn")]
		string getStreets(string token, string hash);

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getEnCalidadDe", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getEnCalidadDeReturn")]
		string getEnCalidadDe(string token, string hash);
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getBrowseExp", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("getBrowseExpReturn")]
        string getBrowseExp(string xmlIn, string token, string hash);
        
        /// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/saveMulta", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("saveMultaReturn")]
		string saveMulta(string xmlIn, string token, string hash);

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/anularMulta", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("anularMultaReturn")]
		string anularMulta(string boletinId, string motivo, string token, string hash);
        
		///// <remarks/>
		//[System.Web.Services.WebMethodAttribute()]
		//[System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://impl.multas.gtwin.conecta", ResponseNamespace="http://impl.multas.gtwin.conecta", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		//[return: System.Xml.Serialization.XmlElementAttribute("grabarDocumentoEnExpedienteReturn")]
		//string grabarDocumentoEnExpediente(string boletinId, string extension, string serializado, string token, string hash);

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getMarcas", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getMarcasReturn")]
		string getMarcas(string token, string hash);

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getGruas", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getGruasReturn")]
		string getGruas(string token, string hash);

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getInstrumentoMedida", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getInstrumentoMedidaReturn")]
		string getInstrumentoMedida(string token, string hash);

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getAgente", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getAgenteReturn")]
		string getAgente(string token, string hash);
        
		///// <remarks/>
		//[System.Web.Services.WebMethodAttribute()]
		//[System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://impl.multas.gtwin.conecta", ResponseNamespace="http://impl.multas.gtwin.conecta", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		//[return: System.Xml.Serialization.XmlElementAttribute("getAppVersionReturn")]
		//string getAppVersion();
        
		///// <remarks/>
		//[System.Web.Services.WebMethodAttribute()]
		//[System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://impl.multas.gtwin.conecta", ResponseNamespace="http://impl.multas.gtwin.conecta", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		//[return: System.Xml.Serialization.XmlElementAttribute("getUltimaSincronizacionReturn")]
		//string getUltimaSincronizacion();

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getUltimaSincronizacionByEntity", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getUltimaSincronizacionByEntityReturn")]
		string getUltimaSincronizacionByEntity(string token, string hash);
        
		///// <remarks/>
		//[System.Web.Services.WebMethodAttribute()]
		//[System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://impl.multas.gtwin.conecta", ResponseNamespace="http://impl.multas.gtwin.conecta", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		//[return: System.Xml.Serialization.XmlElementAttribute("getFineBookMarkReturn")]
		//string getFineBookMark(string token, string hash);
        
		///// <remarks/>
		//[System.Web.Services.WebMethodAttribute()]
		//[System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://impl.multas.gtwin.conecta", ResponseNamespace="http://impl.multas.gtwin.conecta", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		//[return: System.Xml.Serialization.XmlElementAttribute("setFineBookMarkReturn")]
		//string setFineBookMark(string xmlIn, string token, string hash);
        
		///// <remarks/>
		//[System.Web.Services.WebMethodAttribute()]
		//[System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://impl.multas.gtwin.conecta", ResponseNamespace="http://impl.multas.gtwin.conecta", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		//[return: System.Xml.Serialization.XmlElementAttribute("getTalCounterReturn")]
		//string getTalCounter(string xmlIn, string token, string hash);
        
		///// <remarks/>
		//[System.Web.Services.WebMethodAttribute()]
		//[System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://impl.multas.gtwin.conecta", ResponseNamespace="http://impl.multas.gtwin.conecta", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		//[return: System.Xml.Serialization.XmlElementAttribute("setTalCounterReturn")]
		//string setTalCounter(string xmlIn, string token, string hash);

		/// <remarks/>
		[System.Web.Services.WebMethodAttribute()]
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://impl.multas.gtwin.conecta/getRangosVelocidad", RequestNamespace = "http://impl.multas.gtwin.conecta", ResponseNamespace = "http://impl.multas.gtwin.conecta", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("getRangosVelocidadReturn")]
		string getRangosVelocidad(string xmlIn, string token, string hash);
    }
}
