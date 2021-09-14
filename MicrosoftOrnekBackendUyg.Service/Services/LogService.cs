using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrosoftOrnekBackendUyg.Core.Services;
using Serilog;

namespace MicrosoftOrnekBackendUyg.Service.Services
{
    public class LogService
    {

        private readonly ILogger _logger;

        public LogService(ILogger logger)
        {
            _logger = logger;
            //Log.Logger = new LoggerConfiguration()
            //     .WriteTo.Console()
            //     .WriteTo.Debug(outputTemplate: DateTime.Now.ToString())
            //     .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            //     //.WriteTo.Seq("http:// localhost:5341/")
            //     .MinimumLevel.Information()
            //     .Enrich.WithProperty("AppName", "Fatura Tahsilatı")
            //     .Enrich.WithProperty("Environment", "Development")
            //     .Enrich.WithProperty("Coder", "Muhammed")
            //     .CreateLogger();
        }

        public void LogCiktiBas()
        {
            //_logger.Information("Deneme Çktı");
        }

    }
}
