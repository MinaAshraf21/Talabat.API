using Company.Talabat.APIs.Controllers.Controllers.Base;
using Company.Talabat.APIs.Controllers.Erros;
using Company.Talabat.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Company.Talabat.APIs.Controllers.Controllers.Buggy
{
    public class BuggyController() : BaseApiController
    {

        [HttpGet("not-found")] //GET: /api/buggy/not-found
        public IActionResult GetNotFoundResult()
        {
            // Simulate a not found scenario

            //return a NotFoundResult object , which has 4 properties :
            //StatusCode = 404
            //title that represents a Message about not found error
            //type that represents an anchor for navigating to the error documentation
            //traceId that represents a unique identifier for the request
            return NotFound(); // 404

            //return a NotFoundObjectResult object , which we can customize its content
            //return NotFound(new {StatusCode = 404 , Message = "Not Found!"});
            
        }

        [HttpGet("server-error")]
        public IActionResult GetServerError()
        {
            throw new Exception("This is a server error!"); // 500
        }

        [HttpGet("bad-request")]
        public IActionResult GetBadRequestResult()
        {
            //return a BadRequestResult object , which has 4 properties including StatusCode = 400 & Message about bad request
            return BadRequest(); // 400

            //return a BadRequestObjectResult object , which we can customize its content
            //return BadRequest(new { StatusCode = 400, Message = "Bad Request!" }); // 400

            // Or we can return a ModelStateDictionary object to provide more details about the bad request
            // this dictionary contains a collection of key/value pairs that represent the state of the model and any validation errors
            // the model here means the data that is being sent to the endpoint
            // if one or more errors occured : the model state will be invalid
            //return BadRequest(new ModelStateDictionary());
        }

        [HttpGet("bad-request/{id}")]
        public IActionResult GetValidationErrorResult(int id)
        {

            // Or we can return a ModelStateDictionary object to provide more details about the bad request
            // this dictionary contains a collection of key/value pairs that represent the state of the model and any validation errors
            // the model here means the data that is being sent to the endpoint
            // if one or more errors occured : the model state will be invalid
            //return BadRequest(new ModelStateDictionary());

            return Ok();
        }

        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorizedResult()
        {
            var unauth = Unauthorized();
            return unauth; //401
        }

        [HttpGet("forbid")]
        public IActionResult GetForbiddenResult()
        {
            return Forbid(); //403
        }

    }
}
