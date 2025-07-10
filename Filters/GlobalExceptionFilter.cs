using Cimo.Dtos;
using Hotel_Management.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Cimo.Exceptions;

namespace Cimo.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;

            if (ex is NotFoundException)
            {
                context.Result = new NotFoundObjectResult(
                    ResponseApi<ErrorDto>.Fail(new ErrorDto { Message = ex.Message }));
            }
            else if (ex is UnauthorizedException)
            {
                context.Result = new UnauthorizedObjectResult(
                    ResponseApi<ErrorDto>.Fail(new ErrorDto { Message = ex.Message }));
            }
            else if (ex is ForBidenException)
            {
                context.Result = new ObjectResult(
                    ResponseApi<ErrorDto>.Fail(new ErrorDto { Message = ex.Message })
                )
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
            else
            {
                _logger.LogError(ex, "Unhandled exception");
                context.Result = new ObjectResult(
                    ResponseApi<SystemErrorDto>.Fail(new SystemErrorDto
                    {
                        Message = "Lỗi hệ thống",
                        Detail = ex.Message
                    }))
                {
                    StatusCode = 500
                };
            }

            context.ExceptionHandled = true;
        }
    }

}
