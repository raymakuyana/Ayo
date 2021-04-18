using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ayo.ConveterApp.Api.Models.Responses
{
    public class ErrorResponse
    {
        public List<Error> Errors { set; get; }
    }
}
