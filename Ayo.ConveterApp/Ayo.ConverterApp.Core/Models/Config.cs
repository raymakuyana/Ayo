using System;
using System.Collections.Generic;
using System.Text;

namespace Ayo.ConverterApp.Core.Models
{
    public class Config
    {

        public static Config config { set; get; }
        public static Config GetInstance
        {
            get
            {
                if (config == null)
                {
                    config = new Config();
                }
                return config;
            }


        }

        public List<ConversionRule> ConversionRules { set; get; }

        public class ConversionRule
        {
            public string InputUnitOfMeasure { set; get; }
            public string OutputUnitOfMeasure { set; get; }
            public double ConversionFactor { set; get; }
            public string ConversionMethodCode { set; get; }
            public string ConversionMethodDescription { set; get; }

        }

    }
}
