namespace Company.Talabat.APIs.Controllers.Erros
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public IEnumerable<ValidationError> Errors { get; set; }
        public ApiValidationErrorResponse(string? message = null) : base(400,message)
        {
            
        }

        public class ValidationError
        {
            public string Field { get; set; }
            public IEnumerable<string> Errors { get; set; }
        }
    }
}
