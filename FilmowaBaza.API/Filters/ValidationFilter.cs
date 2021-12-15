using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace FilmowaBaza.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var errors = new Dictionary<string, string[]>();
                var result = new ContentResult();

                foreach(var item in context.ModelState)
                { 
                    errors.Add(item.Key, item.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                }

                context.Result = new BadRequestObjectResult(errors);
            }
        }
    }
}
