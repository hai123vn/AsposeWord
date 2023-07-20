using System.Text;
using API._Services.Interfaces;
using API._Services.Services;
using API.Extentions.Constants;
using API.Helpers.Utilities;
using AutoMapper;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API.Extentions
{
    public static class DependenceInjectionsExtentions
    {

        public static void RepositoryDI(this IServiceCollection services)
        {

        }

        public static void ServicesDI(this IServiceCollection services)
        {
            // services.AddScoped<IJwtUtility, JwtUtility>();
            services.AddScoped<IUploadFileUtility, UploadFileUtility>();
            services.AddScoped<IWordServices, WordServices>();
        }

        public static void AuthenticationDI(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(configuration.GetSection(AppSettingsConst.Tokens).Value)),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            services.AddSingleton(tokenValidationParameters);


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = tokenValidationParameters;
                });
        }
        public static void AutoMapperDI(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // services.AddScoped<IMapper>(sp =>
            // {
            //     // return new Mapper(AutoMapperConfig.RegisterMappings());
            // });
            // services.AddSingleton(AutoMapperConfig.RegisterMappings());
        }
        public static void SwaggerDI(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please insert JWT with Bearer into field",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
                    });
                });
        }
    
        public static void AsposeInstall (){
            Aspose.Words.License cellLicense = new Aspose.Words.License();
            string filePath = Directory.GetCurrentDirectory() + "\\Resource\\" + "Aspose.Total.lic";
            cellLicense.SetLicense(filePath);
        }
    
    }
}