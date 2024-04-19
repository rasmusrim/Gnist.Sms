using System.Text;

namespace Gnist.Sms;

public class SmsGatewayCommunicator
{
    private readonly SmsGatewayConfig _config;

    public SmsGatewayCommunicator(SmsGatewayConfig config)
    {
        _config = config;

    }

    public async Task SendSingleSms(string from, int to, string message)
    {

        var payload = CreatePayload(from, to, message);
        await Send(payload);
    }

    private async Task Send(Payload payload)
    {
        using var handler = new HttpClientHandler();
        using var client = new HttpClient(handler);
        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, _config.Wsdl);
        requestMessage.Content = new StringContent(payload.Body, Encoding.UTF8, "text/xml");

        foreach (var header in payload.Headers)
        {
            requestMessage.Headers.Add(header.Key, header.Value);
        }
        var response = await client.SendAsync(requestMessage);

        var receiveStream = await response.Content.ReadAsStreamAsync();
        var readStream = new StreamReader(receiveStream, Encoding.UTF8);
        var responseString = await readStream.ReadToEndAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Response code implies not successful: " + response.StatusCode + "\nRequest: " + requestMessage + "\nResponse: " + responseString);
        }

        if (responseString == null)
        {
            throw new HttpRequestException("Response is empty");
        }


        if (
            !responseString.Contains("<StatusCode xmlns=\"\">1</StatusCode>")
        )
        {
            throw new HttpRequestException("Response does not contain succesful status code: " + responseString);
        }

    }

    private Payload CreatePayload(string from, int to, string message)
    {
        var escapedMessage = System.Security.SecurityElement.Escape(message);
        
        var body = $@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sp=""SP.Shared.Schemas.SmsSend"">
   <soapenv:Header/>
   <soapenv:Body>
      <sp:SmsRequest>
         <!--Optional:-->
         <SenderApplication>{_config.SenderApplication}</SenderApplication>
         <!--Optional:-->
         <SendingUnit>{_config.SendingUnit}</SendingUnit>
         <!--Optional:-->
         <SendingCostUnit>{_config.SendingCostUnit}</SendingCostUnit>
         <!--Optional:-->
         <DisplayName>{from}</DisplayName>
         <MessageId>{Guid.NewGuid().ToString()}</MessageId>
         <!--Optional:-->
         <RecipientNumber>{to}</RecipientNumber>
         <!--Optional:-->
         <MessageText>{escapedMessage}</MessageText>
         <HERId>{_config.HerId}</HERId>
      </sp:SmsRequest>
   </soapenv:Body>
</soapenv:Envelope>
";

        var headers = new Dictionary<string, string>
        {
            { "SOAPAction", "SmsSend" }

        };


        return new Payload
        {
            Body = body,
            Headers = headers
        };

    }

    private sealed class Payload
    {
        public required string Body { get; set; }
        public required Dictionary<string, string> Headers { get; set; }

    }

}
