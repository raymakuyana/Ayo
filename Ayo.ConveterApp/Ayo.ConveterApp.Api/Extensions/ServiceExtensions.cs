using Ayo.ConverterApp.Services.ConversionService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AyoCoreNs= Ayo.ConverterApp.Core;

namespace Ayo.ConveterApp.Api.Extensions
{
    public static class ServiceExtensions
    {




        public static void ReadAppSettings(this IServiceCollection services, IConfiguration config)
        {
            AyoCoreNs.Models.Config.GetInstance.ConversionRules = new List<AyoCoreNs.Models.Config.ConversionRule>();

            const string APP_SETTINGS_SECTION = "ConversionSettings";
            const string APP_SETTINGS_KEY = "ConversionRules";

            var section = config.GetSection($"{APP_SETTINGS_SECTION}:{APP_SETTINGS_KEY}");
            var conversionRules = section.Get<List<AyoCoreNs.Models.Config.ConversionRule>>();

            AyoCoreNs.Models.Config.GetInstance.ConversionRules.AddRange(conversionRules);


        } 


        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
             services.AddScoped<IConversionService, ConversionService>();
            services.AddScoped<ILoggerService, LoggerService>();

        }
    }
}
