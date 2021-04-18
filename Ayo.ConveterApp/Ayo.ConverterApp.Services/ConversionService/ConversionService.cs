using Ayo.ConverterApp.Core.Models;
using Ayo.ConverterApp.Core.Models.Conversion;
using Ayo.ConverterApp.RulesEngine;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ayo.ConverterApp.Core.Models.Config;

namespace Ayo.ConverterApp.Services.ConversionService
{

    public class ConversionService : IConversionService
    {
        private readonly ILoggerService _loggerService;
        public ConversionService(ILoggerService loggerService )
        {
            _loggerService = loggerService;
        }

        public ConversionOutput DoConversion(ConversionInput conversionInput, List<ConversionRule> conversionRules)
        {

            _loggerService.LogToDatabase("Ayo.ConverterApp.Services.ConversionService", "DoConversion", "Started");
            ConversionRules conversionRuless = new ConversionRules(conversionRules);
            double conversionFactor = conversionRuless.GetConversionFactor(conversionInput.InputUnitOfMeasure, conversionInput.ConvertToUnitOfMeasure);

             ConversionOutput conversionOutput = new ConversionOutput
             {
                 OutputValue = conversionInput.InputValue * conversionFactor,
                 OutputUnitOfMeasure = conversionInput.ConvertToUnitOfMeasure
             };

            _loggerService.LogToDatabase("Ayo.ConverterApp.Services.ConversionService", "DoConversion", "Completed");
            return conversionOutput;
        }


        public List<ConversionRule> GetConversionRules(List<ConversionRule> conversionRules)
        {
            return conversionRules;
        }

        public List<ConversionMethod> GetConversionMethods(List<ConversionRule> conversionRules)
        {
            _loggerService.LogToDatabase("Ayo.ConverterApp.Services.ConversionService", "GetConversionMethods", "Started");
            var conversionMethods = conversionRules.Select(x => new ConversionMethod
            {
                ConversionMethodCode = x.ConversionMethodCode,
                ConversionMethodDescription = x.ConversionMethodDescription
            }).OrderBy(x=>x.ConversionMethodDescription).ToList();

            _loggerService.LogToDatabase("Ayo.ConverterApp.Services.ConversionService", "GetConversionMethods", "Completed");

            return conversionMethods;
        }




    }
}
