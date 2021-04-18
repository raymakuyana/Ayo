using Ayo.ConverterApp.Core.Models.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ayo.ConveterApp.Api.Models.Responses
{
    public class ConversionMethodsResponse: ErrorResponse
    {
        public List<ConversionMethod> ConversionMethods { set; get; }
  
    }
}
