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
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Relay;
using Microsoft.Azure.Relay.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace DemoServer2
{
    public class Program
    {
        private static readonly string _sharedAccessKey = "{your RootManageSharedAccessKey value}";
        // Make sure to use https:// here as the protocol if your WCF binding is using https. The documentation and Microsoft samples
        // use sb:// which is incorrect for WCF bindings using https.
        private static readonly string _connectionString = "https://{your Azure Relay name}.servicebus.windows.net/{your hybrid connection name}";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    // Override the default Kestrel endpoint with the Azure Relay endpoint
                    webBuilder.UseAzureRelay(
                        options =>
                        {
                            options.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", _sharedAccessKey);
                            options.UrlPrefixes.Add(_connectionString);
                        });
                });
    }
}
