using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Ayo.ConverterApp.Core.Models.Config;

namespace Ayo.ConveterApp.Api.Models.Responses
{
    public class ConversionRulesResponse : ErrorResponse
    {
       public List<ConversionRule> ConversionRules { set; get; }
    }
}
