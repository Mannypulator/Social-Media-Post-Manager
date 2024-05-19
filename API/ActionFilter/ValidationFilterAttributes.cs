using Application;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.ActionFilter;

public class ValidationFilterAttributes(ILogger<ValidationFilterAttributes> logger) : IActionFilter
{
    void IActionFilter.OnActionExecuted(ActionExecutedContext context)
    {

    }

    void IActionFilter.OnActionExecuting(ActionExecutingContext context)
    {
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];



        var param = context.ActionArguments.SingleOrDefault(x => x.Value!.ToString()!.Contains("Dto"))
            .Value ?? throw new ObjectRequestBadRequestException($"Object is null. Controller:{controller}, action:{action}");

        LoggerMessages.LogObjectGotten(logger, $"Request send for {action}:", param);



        if (!context.ModelState.IsValid) 
        {
            LoggerMessages.LogObjectGotten(logger, $"Request send for {action}:", param);
            throw new ObjectRequestBadRequestException($"Object is not valid. Controller:{controller}, action:{action}");
        }
    }
}