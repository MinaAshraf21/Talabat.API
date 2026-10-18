using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.APIs.Controllers.Erros
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int code , string? message = null)
        {
            StatusCode = code;
            Message = message ?? GetStatusMessage(code);
        }

        string GetStatusMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request!",
                401 => "Unauthorized!",
                403 => "Forbidden!",
                404 => "Not Found!",
                500 => "Internal Server Error!",
                _ => "Error!"
            };
        }
    }
}
