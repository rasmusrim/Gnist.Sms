# Gnist.Sms

## Introduction

A library to send SMS via the Telenor Gateway described
here: https://gnist.sykehuspartner.no/apis/c4220ae1-a0e4-431d-bb9f-8f67f376b9bd

The library was first written by The hospital in Vestfold (SiV) by Rasmus Rimestad (rasmus.rimestad@cloudberries.no)

## How to use

I have no idea what most of the config values mean, and I am able to send SMS with almost any value in most of them. So
The only really required config value, is Wsdl. The other values are probably used for logging and billing purposes, so
you should probably try to find correct and meaningful values for them.

```csharp
namespace Gnist.SendSms.Examples;

public class SendSingleSms
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
       
        gateway.SendSingleSms("Avsender", 12345678, "Hello, world!").Wait();
    }
}
```

## Developing

The version of this library is found in the file `version.txt`. If you run the script `increment-version.sh` it will
increase the revision version by one. After that, you can run `build-and-pack.sh` to build and pack the library. If you
ruin this script from your local machine, the nuget package will be put into the `~/nuget` folder, and you can include
it into your other project from there.

There is a github actions file which will push the nuget package to the repo once your changes have been merged. 




 