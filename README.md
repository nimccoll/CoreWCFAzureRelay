# CoreWCFAzureRelay
Contains a sample CoreWCF client and server project that demonstrate how to make a call over a hybrid connection of an Azure Relay namespace

## Prerequisites
An Azure Relay namespace with a Hybrid Connection configured with no client authentication. See the documentation [here](https://learn.microsoft.com/en-us/azure/azure-relay/relay-hybrid-connections-http-requests-dotnet-get-started#create-a-namespace) for a walkthrough on how to create an Azure Relay namespace and Hybrid Connection using the Azure Portal.

## Projects
1. DemoServer2 contains a CoreWCF project created from the default CoreWCF server project template in Visual Studio. It uses the UseAzureRelay extension found in package [Microsoft.Azure.Relay.AspNetCore](https://www.nuget.org/packages/Microsoft.Azure.Relay.AspNetCore) to allow the CoreWCF server to listen for requests over the Hybrid Connection.
1. DemoClient2 is a simple console application that sends requests over the Hybrid Connection to the CoreWCF server.

## References
[Receiving and handling HTTP requests anywhere with Azure Relay](https://azure.microsoft.com/en-us/blog/receiving-and-handling-http-requests-anywhere-with-the-azure-relay/?msockid=17c9d6473408694c3954c3ef358e68b2)

[Get Started with Relay Hybrid Connections HTTP Requests in .Net](https://learn.microsoft.com/en-us/azure/azure-relay/relay-hybrid-connections-http-requests-dotnet-get-started)

[CoreWCF Walkthrough](https://github.com/CoreWCF/CoreWCF/blob/main/Documentation/Walkthrough.md)

[Azure Relay AspNetServer](https://github.com/Azure/azure-relay-aspnetserver)