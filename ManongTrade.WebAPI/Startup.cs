using System;
using System.Net;
using AutoMapper;
using ManongTrade.Repository;
using ManongTrade.WebAPI.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ManongTrade.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Manong customs
            services.AddCors();
            //services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            //{
            //    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            //}));
            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
            //    options.HttpsPort = 44339;
            //});

            services.Configure<ManongSettingModel>(Configuration.GetSection("ManongSettings"));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<ManongTradeContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.JWTConfigure(new ManongSettingModel()
            {
                AuthKey = Configuration["ManongSettings:AuthKey"],
                AuthIssuer = Configuration["ManongSettings:AuthIssuer"],
                AuthAudience = Configuration["ManongSettings:AuthAudience"]
            });
            services.AddAuthorization(option =>
            {
                option.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // Manong customs
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            //app.UseCors(builder => builder.WithOrigins("https://localhost:44339/"));

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}