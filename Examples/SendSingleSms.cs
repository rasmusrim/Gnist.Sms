namespace Gnist.SendSms.Examples;

public class SendSingleSms
{
    public void Send()
    {
        var config = new SmsGatewayConfig
        {
            Wsdl = "http://something/smssendservice.svc",
            SenderApplication = "",
            SendingUnit = "",
            SendingCostUnit = "",
            HerId = ""
        };

        var gateway = new SmsGatewayCommunicator(config);
        
        gateway.SendSingleSms("Avsender", 12345678, "Hello, world!").Wait();
    }
}
