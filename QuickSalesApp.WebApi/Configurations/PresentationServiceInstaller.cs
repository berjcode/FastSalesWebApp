using DecimalJsonConverterNuget.Utilites;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using QuickSalesApp.WebApi.MiddleWare;


namespace QuickSalesApp.WebApi.Configurations
{
    public class PresentationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ExceptionMiddleware>();
            services.AddCors(options => options.AddDefaultPolicy(options =>
            {
                options.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(options => true);
            }));

            services.AddControllers()
             .AddNewtonsoftJson(options =>
             {
                 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                
             });
            services.AddApiVersioning(opt=>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);

            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setup =>
            {
                var jwtSecuritySheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "test işlemi",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);
                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwtSecuritySheme,Array.Empty<string>() }
    });
            });

        }
    }
}
