using System.Net;
using Microsoft.Extensions.Logging;
using MinimalAPI_Application.Enums;
using MinimalAPI_Application.Extensions;
using MinimalAPI_Application.Models.Domains;

namespace MinimalAPI_Application.Helpers.Sql;

public static class ErrorHelper
{
    private delegate void LogDelegate(ILogger logger, Exception exception, string message, params object[] args);

    public static ExceptionContext GetExceptionContext(Exception ex)
    {
        ExceptionContext exceptionContext = new()
        {
            Exception = ex,
        };
        switch (ex)
        {
            case DomainException:
                DomainException domainEx = (DomainException)ex;
                exceptionContext.ErrorLevel = ErrorLevelEnum.Error;
                exceptionContext.ObjectResult =
                    new ErrorResult(domainEx.Code, domainEx.Message, HttpStatusCode.BadRequest)
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                    };
                break;
            default:
                exceptionContext.ErrorLevel = ErrorLevelEnum.Critical;
                exceptionContext.ObjectResult = new ErrorResult((int)ErrorCodeEnum.GeneralError,
                    ErrorCodeEnum.GeneralError.GetDescription())
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
                break;
        }

        return exceptionContext;
    }
}