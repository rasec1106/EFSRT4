using System;


namespace ApiComment.Dtos
{
    public class ResponseDto
    {
        public bool IsSucceed { get; set; }
        public object? Result { get; set; }
        public string DisplayMessage { get; set; } = "";
    }
}
