using OnlineStore.Web.Helper;
using OnlineStore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers;
public class UserController : Controller
{
    private readonly IApiHelper _apiHelper;
    public UserController(IApiHelper apiHelper)
    {
        _apiHelper = apiHelper;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<APIResponse<UserModel>> SignIn([FromBody] LoginModel model)
    {
        var responseMessage = await _apiHelper.MakeApiCallAsync("User/Login", HttpMethod.Post, model);
        var responseAsync = await BaseMethod.DeserializeApiResponseAsync<UserModel>(responseMessage);
        if (responseAsync.IsSuccess)
        {
            HttpContext.Session.SetString("_SessionToken", responseAsync.Data.Token);
            HttpContext.Session.SetString("_SessionUsername", responseAsync.Data.Username);
            HttpContext.Session.SetInt32("_SessionUserId", responseAsync.Data.Id);
            HttpContext.Session.SetInt32("_SessionIsAdmin", responseAsync.Data.IsAdmin ? 1 : 0);
        }
        return responseAsync;
    }

    [HttpPost]
    public async Task<APIResponse<string>> SignUp([FromBody] RegisterModel model)
    {
        var responseMessage = await _apiHelper.MakeApiCallAsync("User/Register", HttpMethod.Post, model);
        var responseAsync = await BaseMethod.DeserializeApiResponseAsync<string>(responseMessage);
        return responseAsync;
    }

    [HttpGet]
    public async Task<string> Logout()
    {

        HttpContext.Session.Remove("_SessionToken");
        HttpContext.Session.Remove("_SessionUsername");
        HttpContext.Session.Remove("_SessionIsAdmin");
        HttpContext.Session.Remove("_SessionUserId");
        HttpContext.Session.Clear();
        var expiredCookie = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(-1),
            IsEssential = true,
            HttpOnly = true,
        };
        Response.Cookies.Append("_OnlineStoreCookie", "", expiredCookie);

        return "Logout succcessfully.";
    }
}
