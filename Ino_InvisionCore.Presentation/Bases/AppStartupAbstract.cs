using Autofac;
using Ino_InvisionCore.Presentacion.ConfigurationProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.Bases
{
    public class AppStartupAbstract
    {
        public string ModuleName { get; }
        public InvisionConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; set; }

        public static IDictionary<int, string> ErrorPages { get; } = new ConcurrentDictionary<int, string>();

        public AppStartupAbstract(IHostingEnvironment env, string moduleName)
        {
            ModuleName = moduleName;

            IConfigurationRoot appSettingsJsonConfiguration = StartUpConfig.GetAppSettingsJsonAsConfiguration(env);
            Log.Logger = new LoggerConfiguration().ConfigureLogger(appSettingsJsonConfiguration, ModuleName);
            LogModuleAction("APP_STARTUP", true);

            //esta configuracion ya 
            //Configuration = StartUpConfig.GetCommonConfigurationRoot(env, appSettingsJsonConfiguration, ModuleName);
        }

        protected void ConfigureBase(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            Log.Information("** ConfigureApplications...");
            app.ConfigureApplications(env, Configuration); 

            if (env.IsDevelopment())
            {
                Log.Information("** UseDeveloperExceptionPage=TRUE");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                Log.Information("** UseDeveloperExceptionPage=FALSE");
            }
            Log.Information("** ConfigureApplicationLifetime OnStarted OnStopping OnStop...");
            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStop);
        }

        protected void OnStarted()
        {
            LogModuleAction("STARTED", false);
        }

        protected void OnStopping()
        {
            LogModuleAction("STOPPING", false);

            ApplicationContainer?.Dispose();
            // Do your cleanup here
        }

        protected void OnStop()
        {
            LogModuleAction("STOPPED", false);

            ApplicationContainer?.Dispose();
            // Do your cleanup here
        }

        protected void LogModuleAction(string action, bool start)
        {
            if (start)
                Log.Warning("***************************************************************************************************");
            Log.Warning("**************************************  {0} {1}***************************************", ModuleName, action);
            if (!start)
                Log.Warning("***************************************************************************************************");
        }
    }
}
