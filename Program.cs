using System;
using System.Collections.Generic;
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

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
