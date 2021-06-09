using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ino_InvisionCore.Infraestructura.IoC;
using Ino_InvisionCore.Presentacion.ConfigurationProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.RollingFileAlternate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.Bases
{
    public static class StartUpConfig
    {
        public static string K_APP_SETTINGS_JSON = "appsettings.json";
        static string K_DEV_SETTINGS_JSON = "devsettings.json";

        /// <summary>
        /// Gets the common configuration
        /// </summary>
        /// <param name="env">The env.</param>
        /// <param name="appSettingsJsonConfiguration"></param>
        /// <returns></returns>
        public static InvisionConfigurationRoot GetCommonConfigurationRoot(IHostingEnvironment env,
            IConfigurationRoot appSettingsJsonConfiguration, string componentName)
        {
            bool sinConfiguracionBase = appSettingsJsonConfiguration == null;
            if (sinConfiguracionBase)
            {
                appSettingsJsonConfiguration = GetAppSettingsJsonAsConfiguration(env);
                Log.Logger = new LoggerConfiguration().ConfigureLogger(appSettingsJsonConfiguration, componentName);
                Log.Information(
                    "*******************************************************************************************");
                Log.Information(
                    "************************************ APP_STARTUP LOG  *************************************");
            }
            //var appSettingsJsonConfiguration = GetAppSettingsJsonAsConfiguration(env);
            string coreBackendUrl = appSettingsJsonConfiguration["CORE_URL"];
            string corePwdMode = appSettingsJsonConfiguration["CORE_PWDMODE"];
            Log.Information("** env.ContentRootPath:" + env.ContentRootPath);
            Log.Information("**            CORE_URL:" + coreBackendUrl);

            //las variables se buscan en en orden inverso
            // Mejora la prioridad al buscar los parametros
            // 1) devsettings.json
            // 2) appsettings.json
            // 3) EnviromentVariables
            // 4) CORE_URL

            InvisionConfigurationBuilder config = new InvisionConfigurationBuilder();
            config
                .SetBasePath(env.ContentRootPath)
                //.AddCoreServiceConfig(coreBackendUrl, componentName, corePwdMode) //Cargamos la configuración por CORE-BE
                .AddEnvironmentVariables() //Cargamos las variables de entorno                
                .AddJsonFile(K_APP_SETTINGS_JSON, optional: false, reloadOnChange: true) //APP SETTINGS REQUIRED
                .AddJsonFile(K_DEV_SETTINGS_JSON, optional: true, reloadOnChange: true); //DEV SETTINGS OPTIONAL

            InvisionConfigurationRoot configurationRoot = config.BuildInvision(componentName);
            return configurationRoot;
        }

        public static IConfigurationRoot GetCommonConfigurationRoot(IHostingEnvironment env, string componentName)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddEnvironmentVariables()
                 // Necesitamos como mínimo el appsettings con el connectionString de Core que lo llamaremos "CoreConnectionString"
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var appSettingsConfig = builder.Build();

            var config = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                // Cargamos las variables de entorno
                .AddEnvironmentVariables()
                // Cargamos la configuración por base de datos
                //.AddCoreServiceConfig(appSettingsConfig["CORE_URL"], componentName, appSettingsConfig["CORE_PWDMODE"])
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                // Esto sobreescribira la configuración cargada por el servicio de Core
                //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("devsettings.json", optional: true, reloadOnChange: true);

            return config.Build();
        }

        public static IConfigurationRoot GetAppSettingsJsonAsConfiguration(IHostingEnvironment env)
        {

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                // Necesitamos como mínimo el appsettings con el connectionString de Core que lo llamaremos "CoreConnectionString"
                .AddJsonFile(K_APP_SETTINGS_JSON, optional: false, reloadOnChange: true);

            IConfigurationRoot appSettingsConfig = builder.Build();
            return appSettingsConfig;
        }

        /// <summary>
        /// Configures the log factory.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="config">The configuration.</param>
        public static void ConfigureLogFactory(this IApplicationBuilder app, ILoggerFactory loggerFactory,
            IConfigurationRoot config)
        {
            loggerFactory.AddConsole(config.GetSection("Logging"));
            loggerFactory.AddDebug();
        }

        /// <summary>
        /// Configures the basic applications.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="isSubApplication">if set to <c>true</c> [is sub application].</param>
        public static void ConfigureBasicApplications(this IApplicationBuilder app, IConfigurationRoot config,
            bool isSubApplication = true)
        {
            
        }

        /// <summary>
        /// Gets the security service URL.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>

        private static string GetSecurityServiceUrl(IConfigurationRoot config)
        {
            return config["ServerSSOIdentity"] ?? config["SECURITY_SERVICE_URL"];
        }

        /// <summary>
        /// Configures the applications.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="config">The configuration.</param>
        public static void ConfigureApplications(this IApplicationBuilder app, IHostingEnvironment env,
            IConfigurationRoot config)
        {
            app.ConfigureBasicApplications(config);
            app.UseSession();
            app.ConfigureEnviroment(env);
            app.ConfigureRouting();
        }

        /// <summary>
        /// Gets the log path.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="componentName">Name of the component.</param>
        /// <returns></returns>
        public static string GetLogPath(IConfigurationRoot config, string componentName)
        {
            string path = config["LogPath"];

            if (string.IsNullOrEmpty(path))
            {
                path = config["Logging:LogPath"];
            }

            if (string.IsNullOrEmpty(path))
            {
                path = config["Data:Logging:LogPath"];
            }

            if (string.IsNullOrEmpty(path))
            {
                path = "C:\\InvisionCore\\Publico\\Logs2\\{SiteName}";
            }


            return path.Replace("{SiteName}", componentName);
        }

        /// <summary>
        /// Configures the logger.
        /// </summary>
        /// <param name="loggerConfig">The logger configuration.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="componentName">Name of the component.</param>
        /// <returns></returns>
        public static Serilog.ILogger ConfigureLogger(this LoggerConfiguration loggerConfig, IConfigurationRoot config,
            string componentName)
        {
            string logPath = GetLogPath(config, componentName);
            return loggerConfig
                .MinimumLevel.Debug()
                .Enrich.WithProperty("SourceContext", "")
                .Enrich.WithThreadId()
                .Enrich.WithProcessId()
                .Enrich.FromLogContext()
                //.WriteTo.RollingFile(GetLogPath(config["LogPath"], componentName), retainedFileCountLimit: 20, fileSizeLimitBytes: 100492928,
                .WriteTo.RollingFileAlternate(logPath, retainedFileCountLimit: 20,
                    fileSizeLimitBytes: 10485760, // 10MB
                    outputTemplate:
                    "{Timestamp:yyyy-MM-dd HH:mm:ss} [{ThreadId,4}] {Level:u3} [{ProcessId,6}] [{ContextID,15}]  : {Message} {SourceContext:l} {NewLine}{Exception}")
                .WriteTo.ColoredConsole(
                    outputTemplate:
                    "{Timestamp:yyyy-MM-dd HH:mm:ss} [{ThreadId,4}] {Level:u3} [{ProcessId,}] [{ContextID,15}] : {Message} {SourceContext:l} {NewLine}{Exception}")
                .CreateLogger();
        }

        /// <summary>
        /// Configures the common services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        //public static void ConfigureCommonServices(this IServiceCollection services, IConfigurationRoot config)
        //{
        //    string value = config[ApmtConfigKeys.Comun.IS_SUB_APPLICATION];// "IsSubApplication"
        //    Constantes.IsSubApplication = !string.IsNullOrEmpty(value) && Convert.ToBoolean(value);
        //    value = config[ApmtConfigKeys.Comun.IS_HTTPS];

        //    Constantes.IsSsl = !string.IsNullOrEmpty(value) && Convert.ToBoolean(value);
        //    Log.Information("** IsSubApplication:{0}", Constantes.IsSubApplication);
        //    services.AddSingleton<IConfiguration>(config);
        //    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        //    services.AddCors();
        //    services.AddSession();
        //    //services.AddMvc()
        //    //    .AddJsonOptions(
        //    //        opts =>
        //    //        {
        //    //            opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        //    //            // Force Camel Case to JSON
        //    //        });

        //    if (Constantes.IsSubApplication)
        //    {
        //        services.AddMvc()
        //            .AddJsonOptions(
        //                opts =>
        //                {
        //                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        //                // Force Camel Case to JSON
        //            });

        //        Log.Information("** Es SubApplication (Portal): configurando Autorizacion ...");
        //        services.AddAuthorization();
        //        services.AddTransient<IAuthorizationRequirement, ApmtPermissionsAuthorizationRequirement>();
        //        services.AddTransient<IAuthorizationService, AuthorizationServiceImpl<ApmtPermissionsAuthorizationRequirement>>();
        //    }
        //    else
        //    {
        //        //ESTO ES SOLO PARA DESARROLLO
        //        services.AddMvc(opts =>
        //        {

        //            opts.Filters.Add(new AllowAnonymousFilter());
        //        }).AddJsonOptions(
        //                opts =>
        //                {
        //                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        //                    // Force Camel Case to JSON
        //                });
        //        //services.AddAuthorization();
        //        services.AddTransient<IAuthorizationRequirement, DevPermissionsAuthorizationRequirement>();
        //        services.AddTransient<IAuthorizationService, AuthorizationServiceImpl<DevPermissionsAuthorizationRequirement>>();
        //        Log.Information("** No es SubApplication (Standalone): no se configura Autorizacion ...");
        //    }
        //    services.AddTransient<IDataProtectionService, DataProtectionService>();


        //    if (Constantes.IsSsl)
        //    {
        //        //    var options = new RewriteOptions()
        //        //    .AddRedirectToHttps();
        //        //    app.UseRewriter(options);
        //        //services.Configure<MvcOptions>(options =>
        //        //{
        //        //    options.Filters.Add(new RequireHttpsAttribute());
        //        //});
        //    }


        //    //services.AddSingleton<ICachingService, ApmtCachingService>();
        //    //services.AddTransient<ISecurityService, SecurityService>();
        //    //services.AddTransient<IUserResolverService, UserResolverService>();
        //}

        /// <summary>
        /// Configures the console logger.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureConsoleLogger(this IServiceCollection services)
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddConsole();

            services.AddSingleton<ILoggerFactory>(loggerFactory);
        }

        /// <summary>
        /// Configures the enviroment.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="defaultAction">The default action.</param>
        public static void ConfigureEnviroment(this IApplicationBuilder app, IHostingEnvironment env)
        {
            
            
            //app.UseExceptionHandler(builder =>
            //{
            //    builder.Run(
            //        async context =>
            //        {
            //            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            //            var error = context.Features.Get<IExceptionHandlerFeature>();
            //            if (error?.Error != null)
            //            {
            //                //Log.Error(error.Error.Message, error.Error);
            //                Log.Error(error.Error.Message, error.Error);

            //                StatusResponse response = new StatusResponse("ERROR", error.Error.Message);

            //                string jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(response);

            //                await context.Response.WriteAsync(jsonResponse).ConfigureAwait(false);
            //            }
            //        });
            //});
        }

        /// <summary>
        /// Injects the dependency module.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <param name="applicationContainer">The application container.</param>
        /// <returns></returns>
        public static IServiceProvider InjectDependencyModule<T>(this IServiceCollection services,
            IContainer applicationContainer) where T : Module, new()
        {
            var objectBuilder = new ContainerBuilder();
            objectBuilder.RegisterModule<T>();

            objectBuilder.Populate(services);

            applicationContainer = objectBuilder.Build();

            IoCResolver.Initialize(applicationContainer);

            return applicationContainer.Resolve<IServiceProvider>();
        }

        /// <summary>
        /// Configures the routing.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="defaultActionTemplate">The default action template.</param>
        public static void ConfigureRouting(this IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
