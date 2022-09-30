using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Extensions;

namespace Shop.Filters
{
    public class UserLogindedFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.IsUserLogined())
            {
                context.Result = new RedirectToActionResult("Login", "Users", null);
            }
        }
    }
}
