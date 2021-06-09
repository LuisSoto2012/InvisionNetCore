using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Ino_InvisionCore.Presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseUrls("http://*:5000")//to avoid trouble publishing in IIS, this line must be before the next line. It dont override port in IIS Site
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build();

            //host.Run();

            //Works
            CreateWebHostBuilder(args).Build().Run();

            //Log.Logger = new LoggerConfiguration()
            //   .Enrich.FromLogContext()
            //   .MinimumLevel.Debug()
            //   .WriteTo.File("log.txt",
            //        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            //   .WriteTo.ColoredConsole(
            //       LogEventLevel.Verbose,
            //       "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
            //       .CreateLogger();

            //try
            //{
            //    CreateWebHostBuilder(args).Build().Run();
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseSerilog()
                //.UseKestrel()
                //.UseContentRoot(Directory.GetCurrentDirectory())
                //.UseUrls("http://*:5000")//to avoid trouble publishing in IIS, this line must be before the next line. It dont override port in IIS Site
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
