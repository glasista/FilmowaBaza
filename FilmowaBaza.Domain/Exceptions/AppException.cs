using System;

namespace FilmowaBaza.Domain.Exceptions
{
    public class AppException : Exception
    {
        public ErrorCode ErrorCode { get; set; }
        public AppException(ErrorCode errorCode) 
            : this(errorCode, string.Empty)
        {
        }
        public AppException(ErrorCode errorCode, string message)
            : this(errorCode, message, null)
        {
        }
        public AppException(ErrorCode errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            this.ErrorCode = errorCode;
        }
    }
}
