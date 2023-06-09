namespace WebUI.Controllers;

public class DashboardController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public DashboardController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public IActionResult Index()
    {
        if(_httpContextAccessor.HttpContext.Session.GetString("Username") == "admin")
        {
            return RedirectToAction("Index", "Admin");
        }


        if(_httpContextAccessor.HttpContext.Session.GetString("Username") is null)
            RedirectToAction("Index", "Home");

        return View();
    }


    public IActionResult UserDetails()
    {
        return View();
    }
    public IActionResult Research()
    {
        return View();
    }
    public IActionResult Banking()
    {
        return View();
    }
    public IActionResult CountrySettings()
    {
        return View();
    }
}