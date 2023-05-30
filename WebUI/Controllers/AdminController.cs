

namespace WebUI.Controllers;


public class AdminController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AdminController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IActionResult Index()
    {

        if(_httpContextAccessor.HttpContext.Session.GetString("Username") != "admin")
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }
}