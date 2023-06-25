namespace ApiUser.DTOs
{
    public class ResponseDto
    {
        public int statusCode { get; set; }
        public string? message { get; set; }
        public bool isError { get; set; }
        public Object? data { get; set; }
    }
}
