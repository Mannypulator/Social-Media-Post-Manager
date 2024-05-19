using Application.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.ActionFilter;

public class ValidationModelFilterAttribute<TModel>(IValidator<TModel> validator) : IAsyncActionFilter
    where TModel : class
{
    private readonly IValidator<TModel> _validator = validator ?? throw new ArgumentNullException(nameof(validator));

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (context.ActionArguments.TryGetValue("request", out var request) && request is TModel model)
        {
            var validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                var response = new GenericResponse<string>
                {
                    ResponseCode = "99",
                    ResponseMsg = validationResult.Errors.Select(x => x.ErrorMessage).FirstOrDefault(),
                };

                context.Result = new BadRequestObjectResult(response);
                return;
            }
        }

        await next();
    }
}