namespace Gnist.SendSms;

public class SmsGatewayConfig
{
    // SHould be something like http://sds-sftpsiv-01.sikt.sykehuspartner.no/regiis4321prod/SP.REG.Services.sms/smssendservice.svc
    public required string Wsdl { get; set; }
    public required string SenderApplication { get; set; }
    public required string SendingUnit { get; set; }
    public required string SendingCostUnit { get; set; }
    public required string HerId { get; set; }
    
    
}
