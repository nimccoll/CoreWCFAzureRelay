//===============================================================================
// Microsoft Azure Customer Advisory and Resiliency
// CoreWCF Hybrid Connection Sample
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using ServiceReference1;

namespace DemoClient2
{
    internal class Program
    {
        // Make sure to use https:// here as the protocol if your WCF binding is using https. The documentation and Microsoft samples
        // use sb:// which is incorrect for WCF bindings using https.
        private static readonly string _endpointAddress = "https://{your Azure Relay name}.servicebus.windows.net/{your Hybrid Connection name}}/Service.svc";

        static void Main(string[] args)
        {
            var client = new ServiceClient(ServiceClient.EndpointConfiguration.BasicHttpBinding_IService, _endpointAddress);
            var result = client.GetDataAsync(42).Result;
            Console.WriteLine(result);
        }
    }
}
