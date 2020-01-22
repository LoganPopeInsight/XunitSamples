using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DemoWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((context, config) =>
             {
                 //var keyvaultendpoint = getkeyvaultendpoint();
                 //if (!string.isnullorempty(keyvaultendpoint))
                 //{
                 //    var azureservicetokenprovider = new azureservicetokenprovider();
                 //    var keyvaultclient = new keyvaultclient(
                 //        new keyvaultclient.authenticationcallback(
                 //            azureservicetokenprovider.keyvaulttokencallback));
                 //    config.addazurekeyvault(keyvaultendpoint, keyvaultclient, new defaultkeyvaultsecretmanager());
                 //}
             })
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();
             });
        //private static string GetKeyVaultEndpoint() => "https://demo-keyvault.vault.azure.net";
    }
}
