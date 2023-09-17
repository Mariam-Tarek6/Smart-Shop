// Startup.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApplication19.Model;
using Microsoft.EntityFrameworkCore;
using WebApplication19.Controller;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Google;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace WebApplication19
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<IJwtTokenManager, JwtTokenManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"))
                };
            });

            services.AddDbContext<SmartShopContext>();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Version 1", Version = "v1" });
            });
            //services.Configure<JWT>(Configuration.GetSection("JWT"));

            //services.AddIdentity<Client, IdentityRole>().AddEntityFrameworkStores<SmartShopContext>();

            //services.AddScoped<IAuthService, AuthService>();



            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(o =>
            //    {
            //        o.RequireHttpsMetadata = false;
            //        o.SaveToken = false;
            //        o.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidIssuer = Configuration["JWT:Issuer"],
            //            ValidAudience = Configuration["JWT:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
            //            ClockSkew = TimeSpan.Zero
            //        };
            //    });

            services.AddDbContext<SmartShopContext>();
            services.AddControllers();

          
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });
         app.UseHttpsRedirection();

       
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                     Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/Images"
            });
        }
    }
}

            //services.AddIdentity<IdentityUser, IdentityRole>(
            //    options =>
            //    {
            //        // Password settings
            //        options.Password.RequireDigit = true;
            //        options.Password.RequiredLength = 8;
            //        options.Password.RequireNonAlphanumeric = false;
            //        options.Password.RequireUppercase = true;
            //        options.Password.RequireLowercase = true;

            //        // Lockout settings
            //        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //        options.Lockout.MaxFailedAccessAttempts = 5;
            //        options.Lockout.AllowedForNewUsers = true;

            //        // User settings
            //        options.User.RequireUniqueEmail = true;

            //        // SignIn settings
            //        options.SignIn.RequireConfirmedEmail = false;
            //        options.SignIn.RequireConfirmedPhoneNumber = false;
            //    }
            //    ) // Configure Identity options elsewhere if needed
            //    .AddEntityFrameworkStores<SmartShopContext>()
            //    .AddDefaultTokenProviders();


            //.AddCookie(options =>
                //.AddJwtBearer(jwtoption =>
                //{
                //    var key = Configuration.GetValue<string>("JwrConfig:Key");
                //    var keyBytes = Encoding.ASCII.GetBytes(key);
                //    jwtoption.SaveToken = true;
                //    jwtoption.TokenValidationParameters = new TokenValidationParameters
                //    {
                //        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                //        ValidateLifetime = true,
                //        ValidateAudience = false,
                //        ValidateIssuer = false
                //    };
            //{
            //    options.LoginPath = "/account/google-login";
            //})
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = "1036875143793-ot029kcaej4tm2gjdd3tu2a4fefhckba.apps.googleusercontent.com";
            //        options.ClientSecret = "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";
            //    });
            ////}).AddGoogle(option =>
            //{
            //    option.ClientId = "1036875143793-ot029kcaej4tm2gjdd3tu2a4fefhckba.apps.googleusercontent.com";
            //    option.ClientSecret = "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";

            //});