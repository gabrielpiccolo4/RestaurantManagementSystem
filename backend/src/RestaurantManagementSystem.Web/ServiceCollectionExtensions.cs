using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestaurantManagementSystem.Infrastructure.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RestaurantManagementSystem.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureMvc(this IServiceCollection services)
        {
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.Filters.Add(new ProducesAttribute("application/json"));
            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSecret = configuration.GetSection("App").Get<AppSettings>().JwtSecret;
            var key = Encoding.ASCII.GetBytes(jwtSecret);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void ConfigureSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("RestaurantManagementSystemOpenAPISpecification", new OpenApiInfo()
                {
                    Title = "Restaurant Management System API",
                    Version = "1",
                    Description = "Through this API you can access all functionalities of the Restaurant Management System.",
                    Contact = new OpenApiContact()
                    {
                        Email = "gabriel.piccolo@outlook.com",
                        Name = "Gabriel Piccolo",
                    }
                });

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement() 
                {
                    {
                        new OpenApiSecurityScheme {
                            Name = "Bearer",
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            In = ParameterLocation.Header,
                            Scheme = "oauth2",
                        },
                        new List<string>()
                    }
                });

                SwaggerGenIncludeXmlComments(setupAction);
            });
        }

        /// <summary>
        /// Looks for .xml files located in assemblies that ends with "Api" or "Application"
        /// </summary>
        /// <param name="setupAction">Instance of <see cref="SwaggerGenOptions"/></param>
        private static void SwaggerGenIncludeXmlComments(SwaggerGenOptions setupAction)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies.Where(x => x.GetName().Name.StartsWith("RestaurantManagementSystem")
                && (x.GetName().Name.EndsWith("Api") || x.GetName().Name.EndsWith("Application"))))
            {
                var assemblyName = assembly.GetName().Name;
                var xmlCommentsFile = $"{assemblyName}.xml";
                var xmlCommentsFullPath = Path.Combine(@"..\", assemblyName, xmlCommentsFile);

                if (File.Exists(xmlCommentsFullPath))
                    setupAction.IncludeXmlComments(xmlCommentsFullPath);
            }
        }
    }
}
