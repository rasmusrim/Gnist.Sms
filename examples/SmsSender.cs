namespace Gnist.Sms.examples;

public class SmsSender
{
    public void Send()
    {
        var config = new SmsGatewayConfig
        {
            Wsdl = "http://something/smssendservice.svc", // Should end with "smssendservice.svc"
            SenderApplication = "MyKickAssApp", // Can be anything but not an empty string.
            SendingUnit = "SiVHF", // Can be anything. Is "SiVHF" in our config.
            SendingCostUnit = "sp-123-12", // Can be anything but not an empty string. Follows this format in our config: "sp-123-12"
            HerId = "12" // Can be anything. Is a two digit number in our config
        };
    
        var gateway = new SmsGatewayCommunicator(config);
       
        gateway.SendSingleSms("Avsender", 12345678, "Hello, world!");
    }
}
