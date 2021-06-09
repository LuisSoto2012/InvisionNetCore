using Autofac;
using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Seguridad;
using Ino_InvisionCore.Infraestructura.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.Bases
{
    public class AppStartupBase : AppStartupAbstract
    {
        public IContainer ApplicationContainer { get; private set; }

        public IConfiguration Configuration { get; }

        protected Type[] serviceTypes;

        public AppStartupBase(IHostingEnvironment env, string moduleName, IConfiguration configuration)
            : base(env, moduleName)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            LogModuleAction("STARTING", true);

            Log.Information("** ConfigureCORS...");
            services.AddCors();
            services.AddSession();

            Log.Information("** RegisterDataBaseContext...");
            RegisterDataBaseContext(services);

            Log.Information("** ConfigureAutoMapper...");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(AutoMapperProfile));

            Log.Information("** ConfigureLogginJWTBearer...");
            RegisterLogginJWTBearer(services);

            Log.Information("** ConfigureConsoleLogger...");
            services.ConfigureConsoleLogger();

            Log.Information("** AddMemoryCache...");
            services.AddMemoryCache();
            Log.Information("** AddOptions...");
            services.AddOptions();

            Log.Information("** RestClientSettings...");
            IDictionary<string, string> defaultHeader = new ConcurrentDictionary<string, string>();
            defaultHeader.Add("SOURCE_MODULE_CODE", ModuleName.ToUpper());

            //Func<IServiceProvider, RestClientSettings> supplier = p => RestClientSettings.NewInstance(defaultHeader);
            //services.AddSingleton<RestClientSettings>(supplier);

            //services.AddFactory<RestClient, RestClientFactory>();

            //services.AddTransient<ISecurityService, SecurityService>();
            //services.AddTransient<IUserResolverService, UserResolverService>();


            Log.Information("** RegisterDependecyModule...");
            IServiceProvider registerDependecyModule = RegisterDependecyModule(services);
            Log.Information("** ConfigureServices done " + registerDependecyModule);
            return registerDependecyModule;
        }

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            ConfigureBase(app, env, loggerFactory, appLifetime);

            Log.Information("** InitializerDataBaseContext...");
            InitializerDataBaseContext(app.ApplicationServices);
            Log.Information("   InitializerDataBaseContext done");

            Log.Information("** TestDataBaseContext...");
            TestDataBaseContext(app.ApplicationServices);
            Log.Information("   TestDataBaseContext done");


            LogModuleAction("Configuration Ready", false);
        }

        protected virtual void RegisterLogginJWTBearer (IServiceCollection services)
        {
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IServicioDeUsuarios>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.ObtenerUsuario(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        protected virtual IServiceProvider RegisterDependecyModule(IServiceCollection services)
        {
            //return null;
            return services.BuildServiceProvider();
        }

        protected virtual void RegisterDataBaseContext(IServiceCollection services)
        {
            Log.Information("   RegisterDataBaseContext skip");
        }

        protected virtual void InitializerDataBaseContext(IServiceProvider serviceProvider)
        {
            Log.Information("   InitializerDataBaseContext skip");
        }
        private void TestDataBaseContext(IServiceProvider serviceProvider)
        {
            for (int i = 0; serviceTypes != null && i < serviceTypes.Length; i++)
            {
                Type type = serviceTypes[i];
                DbContext dbContext = (DbContext)serviceProvider.GetService(type);
                Log.Information("   TestDataBaseContext {0}", dbContext);

            }
        }
    }
}
