using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Serilog.Sinks.MSSqlServer;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Serilog.Events;
using System.Data;

namespace MicrosoftOrnekBackendUyg
{
    public class Program
    {
        public static void Main(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //Logger logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(configuration, sectionName: "CustomSection")
            //    .CreateLogger();

            /*
             *              .Enrich.WithProperty("AppName", "Fatura Tahsilatý")
             .Enrich.WithProperty("Environment", "Development")
             .Enrich.WithProperty("Coder", "Muhammed")
             */
            var columnOptions = new ColumnOptions
            {
                AdditionalColumns = new Collection<SqlColumn>
               {
                   new SqlColumn("UserName", SqlDbType.VarChar)
               }
            };

            Log.Logger = new LoggerConfiguration()
             .WriteTo.Console()
             .WriteTo.Debug(outputTemplate: DateTime.Now.ToString())
             .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
             .Enrich.FromLogContext()
             .WriteTo
             .MSSqlServer(
                connectionString: "Data Source=DESKTOP-GA0KMBM;Initial Catalog=InvoiceCollection2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                sinkOptions: new MSSqlServerSinkOptions { TableName = "Log" },
                null, null, LogEventLevel.Information, null, null, null, null)
             .MinimumLevel.Information()
             .CreateLogger();

            Serilog.Debugging.SelfLog.Enable(msg =>
            { 
                Debug.Print(msg);
                Debugger.Break();
            });


            CreateHostBuilder(args).Build().Run();

            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(configuration)
            //    .CreateLogger();

            //try
            //{
            //    CreateHostBuilder(args).Build().Run();
            //    return;
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Host terminated unexpectedly");
            //    return;
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(config => {
                    config.ClearProviders();
                    config.AddConsole();
                    config.AddSerilog();
                })
                .UseSerilog();
        }
}
