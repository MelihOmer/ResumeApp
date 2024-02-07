using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ResumeApp.Web.ActionFilters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ModelStateFilter<T> : ActionFilterAttribute
    {
        private readonly IValidator<T> _validator;

        public ModelStateFilter(IValidator<T> validator)
        {
            _validator = validator;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var resultValidate = _validator.Validate((T)context.ActionArguments.Values.FirstOrDefault());

            if (!resultValidate.IsValid)
            {
                string? action = context.ActionDescriptor.RouteValues["action"];
                foreach (var item in resultValidate.Errors)
                {
                    context.ModelState.AddModelError(item.ErrorCode, item.ErrorMessage);
                }

                context.Result = new ViewResult
                {

                    ViewName = action,
                    
                };
            }
            base.OnActionExecuting(context);
        }
    }
}
