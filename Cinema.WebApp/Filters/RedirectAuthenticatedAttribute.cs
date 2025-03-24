using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApp.Filters;

public class RedirectAuthenticatedAttribute : ActionFilterAttribute
{
    public string RedirectAction { get; set; } = "Index";
    public string RedirectController { get; set; } = "Home";

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var user = context.HttpContext.User;
        if (user?.Identity?.IsAuthenticated == true)
        {
            context.Result = new RedirectToActionResult(RedirectAction, RedirectController, null);
        }
    }
}