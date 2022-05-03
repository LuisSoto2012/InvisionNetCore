using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Seguridad;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.IoC;
using Ino_InvisionCore.Infraestructura.Mapping;
using Ino_InvisionCore.Presentacion.Bases;
using Ino_InvisionCore.Presentacion.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Ino_InvisionCore.Presentacion
{
    public class Startup //: AppStartupBase
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }

        //public Startup(IHostingEnvironment env, IConfiguration configuration)
        //: base(env, "InvisionCore", configuration)
        //{
        //    Configuration = configuration;
        //    serviceTypes = new Type[] { typeof(InoContext), typeof(GalenPlusContext) };
        //}

        //protected override void RegisterDataBaseContext(IServiceCollection services)
        //{
        //    services.AddDbContext<GalenPlusContext>(options =>
        //    options.UseSqlServer(Configuration.GetConnectionString("GalenPlusDB")));
        //    services.AddDbContext<InoContext>(options =>
        //    options.UseSqlServer(Configuration.GetConnectionString("InoDB")));
        //}

        //protected override IServiceProvider RegisterDependecyModule(IServiceCollection services)
        //{
        //    return services.InjectDependencyModule<DependencyRegistrationModule>(ApplicationContainer);
        //}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSession();

            services.AddDbContext<GalenPlusContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("GalenPlusDB")));
            services.AddDbContext<InoContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("InoDB")));
            services.AddDbContext<EvaluacionEscritaContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EvaluacionDB")));
            services.AddDbContext<Ino_FacturacionContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("FacturacionDB")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // signalR
            //services.AddSignalRCore();

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

            //Now register our services with Autofac container

            var builder = new ContainerBuilder();

            builder.RegisterModule(new DependencyRegistrationModule());
            builder.Populate(services);

            var container = builder.Build();

            // Create the IServiceProvider based on the container.

            return new AutofacServiceProvider(container);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error?.Error != null)
                        {
                            //Log.Error(error.Error.Message, error.Error);

                            StatusResponse response = new StatusResponse("ERROR", error.Error.Message);

                            string jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(response);

                            await context.Response.WriteAsync(jsonResponse).ConfigureAwait(false);
                        }
                    });
            });

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            //app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseMvc();

            //app.UseSignalR(hub =>
            //{
            //    //hub.MapHub<>();
            //});
        }
    }
}
