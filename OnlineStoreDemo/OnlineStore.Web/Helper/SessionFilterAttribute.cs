using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace OnlineStore.Web.Helper;

public class SessionAttribute : ActionFilterAttribute
{
    private readonly string _loginPath = "/";

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Cookies.Keys.Contains("_OnlineStoreCookie") && !context.HttpContext.Session.Keys.Contains("_SessionUserId"))
        {
            var isAjax = context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                var jsonResult = new
                {
                    statusCode = StatusCodes.Status401Unauthorized,
                    redirectUrl = _loginPath
                };

                var jsonString = JsonConvert.SerializeObject(jsonResult);

                context.Result = new ContentResult
                {
                    Content = jsonString,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return;
            }
            context.Result = new RedirectResult(_loginPath);
            return;
        }
        base.OnActionExecuting(context);
    }
}
