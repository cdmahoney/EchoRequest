// Launch from VS tools command prompt

::wsdl.exe wsdl\multas.wsdl /l:c# /serverInterface /n:EchoRequest.Interface
::wsdl.exe wsdl\taoWebService.wsdl /l:c# /serverInterface /n:EchoRequest.Interface
wsdl.exe wsdl\wstransac.wsdl /l:c# /serverInterface /n:EchoRequest.Interface