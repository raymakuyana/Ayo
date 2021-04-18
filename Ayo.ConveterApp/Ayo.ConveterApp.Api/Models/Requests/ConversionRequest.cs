using Ayo.ConverterApp.Core.Models.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreModels = Ayo.ConverterApp.Core.Models.Conversion;

namespace Ayo.ConveterApp.Api.Models.Requests
{
    public class ConversionRequest 
    {
       public string ConversionMethodCode { set; get; }
       public double InputValue { set; get; }
    }
}
