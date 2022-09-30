using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Extensions;

namespace Shop.Filters
{
    public class UserAdminFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.IsUserAdmin())
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
