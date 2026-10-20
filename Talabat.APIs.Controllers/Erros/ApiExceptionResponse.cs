using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Talabat.APIs.Controllers.Erros
{
    public class ApiExceptionResponse : ApiResponse
    {
        public string? Details { get; set; }
        public ApiExceptionResponse(int code, string? message = null, string? details = null)
            :base(code,message)
        {
            Details = details;
        }
    }
}
