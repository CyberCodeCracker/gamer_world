namespace gamer_world.API.Helper
{
    public class ResponseAPI
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetMessageFromStatusCode(int statuscode)
        {
            return statuscode switch
            {
                200 => "Done",
                400 => "Bad Request",
                401 => "Unauthorized",
                404 => "Not Found",
                500 => "Server Error",
                _=> null,
            };
        }

        public ResponseAPI(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            // If the message is null then it's value is retrieved from the function
            Message = message ?? GetMessageFromStatusCode(StatusCode); 
        }
    }
}
