using System;
using System.Collections.Generic;
using System.Text;

namespace Ayo.ConverterApp.Services.ConversionService
{
    public interface ILoggerService
    {
        public void LogToDatabase(string source, string action, string message);
    }
}
