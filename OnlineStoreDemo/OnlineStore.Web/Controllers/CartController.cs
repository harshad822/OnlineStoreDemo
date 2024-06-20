using OnlineStore.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Controllers;

[Session]
public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
