using System;
using System.Collections.Generic;
using static Ayo.ConverterApp.Core.Models.Config;
using AyoCoreNs = Ayo.ConverterApp.Core;
using System.Linq;

namespace Ayo.ConverterApp.RulesEngine
{
    public class ConversionRules
    {
        private readonly List<ConversionRule> _conversionRules;
        public ConversionRules(List<ConversionRule> conversionRules)
        {
            _conversionRules = conversionRules;
        }

        public double GetConversionFactor(string inputUnitMeasure, string outputUnitMeasure)
        {

           var converionRule= _conversionRules.Where(x => x.InputUnitOfMeasure == inputUnitMeasure
            && x.OutputUnitOfMeasure == outputUnitMeasure).FirstOrDefault();


           // var converionRule = _conversionRules.Where(x => String.Equals(x.InputUnitOfMeasure == inputUnitMeasure, StringComparison.CurrentCultureIgnoreCase)
           //   && String.Equals(x.OnputUnitOfMeasure == outputUnitMeasure, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (converionRule == null)
            {
                throw new Exception(AyoCoreNs.Models.Errors.CONVERSION_RULE_NOT_FOUND);
            }
            return converionRule.ConversionFactor;
        }
        
    }
}
