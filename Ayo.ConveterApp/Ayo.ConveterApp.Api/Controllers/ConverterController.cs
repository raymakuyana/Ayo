using Ayo.ConverterApp.Core.Models.Conversion;
using Ayo.ConverterApp.Services.ConversionService;
using Ayo.ConveterApp.Api.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Ayo.ConverterApp.Core.Models;
using Ayo.ConveterApp.Api.Models.Responses;

namespace Ayo.ConveterApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class ConverterController : ControllerBase
    {
        //private readonly ILogger _logger;
        private IConversionService _conversionService;
        private Config _configs;

        public ConverterController(IConversionService conversionService)
        { 
        //_logger = logger;
        _conversionService = conversionService;
         _configs = Config.GetInstance;

        }

        [HttpGet("ConversionRules")]
        public IActionResult GetConversionRules()
        {

           var conversionRules = _conversionService.GetConversionRules(_configs.ConversionRules);

            ConversionRulesResponse conversionRulesResponse = new ConversionRulesResponse
            {
                ConversionRules = conversionRules
            };

            return Ok(conversionRulesResponse);


        }

        [HttpGet("ConversionMethods")]
        public IActionResult ConversionMethods()
        {

            var conversionRules = _conversionService.GetConversionRules(_configs.ConversionRules);

            List<ConversionMethod> conversionMethods =  _conversionService.GetConversionMethods(conversionRules);

            ConversionMethodsResponse conversionMethodsResponse = new ConversionMethodsResponse
            {
               ConversionMethods = conversionMethods

            };

            return Ok(conversionMethodsResponse);


        }

        [HttpPost("Convert")]
        public IActionResult Post([FromBody] ConversionRequest conversionRequest)
        {

           var conversionRule= _configs.ConversionRules.Where(x => x.ConversionMethodCode == conversionRequest.ConversionMethodCode).FirstOrDefault();

            if(conversionRule == null)
            {
                throw new Exception(Errors.CONVERSION_RULE_NOT_FOUND);
            }


            ConversionInput conversionInput = new ConversionInput
            {
                InputUnitOfMeasure = conversionRule.InputUnitOfMeasure,
                ConvertToUnitOfMeasure = conversionRule.OutputUnitOfMeasure,
                InputValue = conversionRequest.InputValue
            };

            var conversionOutput = _conversionService.DoConversion(conversionInput, _configs.ConversionRules);

            ConversionResponse conversionResponse = new ConversionResponse
            {
                OutputUnitOfMeasure = conversionOutput.OutputUnitOfMeasure,
                OutputValue = conversionOutput.OutputValue
            };

            return Ok(conversionResponse);

        }

    }
}
