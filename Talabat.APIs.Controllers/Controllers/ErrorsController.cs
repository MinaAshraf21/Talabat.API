using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Erros;
using Microsoft.AspNetCore.Diagnostics;


namespace Talabat.APIs.Controllers.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : BaseApiController
    {
        [HttpGet("{code}")]
        public IActionResult Error(int code)
        {
            if (code == StatusCodes.Status404NotFound)
            {
                return NotFound(new ApiResponse(code, $"the requested endpoint was not found."));
            }
            return StatusCode(code);
        }
    }
}
