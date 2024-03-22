using System.Diagnostics.CodeAnalysis;

namespace Gnist.Sms;

// See README.md for information on the config fields.
public class SmsGatewayConfig
{
    private string _senderApplication;
    private string _sendingCostUnit;

    public required string Wsdl { get; set; }

    public required string SenderApplication
    {
        get => _senderApplication;
        [MemberNotNull(nameof(_senderApplication))]
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("SenderApplication cannot be empty");
            }

            _senderApplication = value;
        }

    }

    public string SendingUnit { get; set; } = "";

    public required string SendingCostUnit
    {
        get => _sendingCostUnit;
        [MemberNotNull(nameof(_sendingCostUnit))]
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("SendingCostUnit cannot be empty");
            }

            _sendingCostUnit = value;
        }
    }

    public string HerId { get; set; } = "";


}
