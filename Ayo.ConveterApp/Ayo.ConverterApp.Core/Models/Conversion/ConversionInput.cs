using System;
using System.Collections.Generic;
using System.Text;

namespace Ayo.ConverterApp.Core.Models.Conversion

{
    public class ConversionInput 
    {
        public string InputUnitOfMeasure { set; get; }
        public string ConvertToUnitOfMeasure { set; get; }
        public double InputValue { set; get; }

    }
}
