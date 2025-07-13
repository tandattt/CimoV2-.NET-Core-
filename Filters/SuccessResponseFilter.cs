using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Cimo.Dtos.Common;

namespace Cimo.Filters
{
    public class SuccessResponseFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Không cần xử lý trước khi action chạy
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                // Nếu đã có ResponseApi hoặc là lỗi thì bỏ qua
                if (objectResult.Value is ResponseApi<object> || objectResult.Value is ErrorDto)
                    return;

                var wrapped = typeof(ResponseApi<>)
                    .MakeGenericType(objectResult.Value?.GetType() ?? typeof(object));

                var response = Activator.CreateInstance(wrapped);
                var successMethod = wrapped.GetMethod("Success", new[] { objectResult.Value?.GetType() });

                var responseValue = successMethod.Invoke(response, new[] { objectResult.Value });

                context.Result = new ObjectResult(responseValue)
                {
                    StatusCode = objectResult.StatusCode
                };
            }
        }
    }
}
