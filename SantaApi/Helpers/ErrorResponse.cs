using System.ComponentModel;

namespace SantaApi.Helpers
{
    public class ErrorResponse
    {
        public ErrorResponse(){}

        public ErrorResponse(ErrorCode errorCode, string message, string description=null)
        {
            ErrorCode = errorCode;
            Message = message;
            Description = description;
        }

        public ErrorCode ErrorCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }

    public enum ErrorCode
    {
        [Description("Сущность не найдена")]
        EntityNotFound = 1,

        [Description("Невалидны поля")]
        ValidationError = 2,
    }
}