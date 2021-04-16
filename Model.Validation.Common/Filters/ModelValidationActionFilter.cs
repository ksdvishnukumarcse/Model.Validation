using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Model.Validation.Common.Filters
{
    public class ModelValidationActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var res = context.ModelState.ErrorCount;
                context.Result = new BadRequestObjectResult(res);
            }
            base.OnActionExecuting(context);
        }

        //public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    if (!context.ModelState.IsValid)
        //    {
        //        var res = context.ModelState.ErrorCount;
        //        context.Result = new BadRequestObjectResult(res);
        //    }
        //    next();
        //    return base.OnActionExecutionAsync(context, next);
        //}
    }
}
