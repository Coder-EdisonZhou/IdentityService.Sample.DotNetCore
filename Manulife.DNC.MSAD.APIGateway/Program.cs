using Manulife.DNC.MSAD.Common;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

/// <summary>
/// This APIGateway is based on Ocelot
/// </summary>
namespace Manulife.DNC.MSAD.APIGateway
{
    public class Program
    {
        public static string IP;
        public static int Port;

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            IP = config["ip"];
            Port = Convert.ToInt32(config["port"]);

            if (string.IsNullOrEmpty(IP))
            {
                IP = NetworkHelper.LocalIPAddress;
            }

            if (Port == 0)
            {
                Port = NetworkHelper.GetRandomAvaliablePort();
            }

            return WebHost.CreateDefaultBuilder(args)
                            .UseStartup<Startup>()
                            //.UseUrls($"http://{IP}:{Port}")
                            .ConfigureAppConfiguration((hostingContext, builder) =>
                            {
                                //builder.AddJsonFile("configuration.json", false, true);
                                //builder.AddJsonFile("appsettings.json", false, true);
                                builder.AddJsonFile("configuration.Development.json", false, true);
                                builder.AddJsonFile("appsettings.Development.json", false, true);
                            })
                            .Build();
        }
    }
}
