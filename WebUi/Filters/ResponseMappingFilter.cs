using System.Net;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebUi.Filters;

public class ResponseMappingFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult && objectResult.Value is BaseResponse cqrsResponse &&
            cqrsResponse.StatusCode != HttpStatusCode.OK)
        {
            context.Result = new ObjectResult(new {cqrsResponse.ErrorMessage})
                {StatusCode = (int) cqrsResponse.StatusCode};
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}