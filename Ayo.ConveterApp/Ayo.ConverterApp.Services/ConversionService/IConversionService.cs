using Ayo.ConverterApp.Core.Models.Conversion;
using System;
using System.Collections.Generic;
using System.Text;
using static Ayo.ConverterApp.Core.Models.Config;

namespace Ayo.ConverterApp.Services.ConversionService
{
   public  interface  IConversionService
    { 
         public ConversionOutput DoConversion(ConversionInput conversionInput, List<ConversionRule> conversionRules);
         public List<ConversionRule> GetConversionRules(List<ConversionRule> conversionRules);
         public List<ConversionMethod> GetConversionMethods(List<ConversionRule> conversionRules);
    }
}
