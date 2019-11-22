﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace SimpleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Debug);
                })
                .ConfigureServices(services =>
                {
                    services.AddMqttClient(options =>
                    {
                        options.Host = "47.107.40.15";
                    });
                    services.AddHostedService<Services>();
                });

            await host.RunConsoleAsync();
        }
    }
}
