using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChantemerleApi.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ChantemerleApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigFileInDocumetsFolderUtililities directoryUtilitiescs = new ConfigFileInDocumetsFolderUtililities("config.json");
            directoryUtilitiescs.writeDataModelToJsonFileInDocumetsFolder();
            string address = "http://localhost:4003/";
            if (args.Length != 0)
            {
                address = args[0];

            }


            var host = new WebHostBuilder()
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .UseIISIntegration()
    .UseStartup<Startup>()
    .UseUrls(address)
    .Build();

            host.Run();


            // CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
