using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using Start.Services;
using Start.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Start
{
    public class Startup
    {
        private IConfiguration _configuration;
       
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            _configuration = configuration;
            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(options=>
            {
                _configuration.Bind("AzureAd", options);
            })
            .AddCookie();
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            services.AddDbContext<OdeToFoodDbContext>(options=>options.UseSqlServer(_configuration["OdeToFoodConnectionString"]));
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());

            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        logger.LogInformation("Request incoming");
            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            await context.Response.WriteAsync("Hit");
            //            logger.LogInformation("Request handled");
            //        }
            //       else
            //        {
            //            await next(context);
            //            logger.LogInformation("Response outgoing");
            //        }
            //    };
            //});
            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/wp"
            //});
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc((IRouteBuilder routeBuilder) =>
             {
                 routeBuilder.MapRoute("Default",
                  "{controller=Home}/{action=Index}/{id?}");
             });
         
        
            //app.Run(async (context) =>
            //{
                
            //    var greeting = greeter.GetMessageOfTheDay();
            //    context.Response.ContentType = "text/plain";
            //    await context.Response.WriteAsync($"{greeting}:{env.EnvironmentName}");
            //});
        }

//        private void ConfigureRoutes(IRouteBuilder routeBuilder) => routeBuilder.MapRoute("Default",
//"controller}/{action}");
    }
}
