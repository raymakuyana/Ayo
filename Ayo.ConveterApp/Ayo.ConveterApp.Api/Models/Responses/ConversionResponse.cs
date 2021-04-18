using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ayo.ConveterApp.Api.Models.Responses
{
    public class ConversionResponse : ErrorResponse 
    {
        public string OutputUnitOfMeasure { set; get; }
        public double OutputValue { set; get; }
    }
}
