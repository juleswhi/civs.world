

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
        return View();
    }

    public IActionResult Login()
    {

        return RedirectToAction("Authenticate", "SignUp", new { username = "JohnDoe", password = "doe"});

    }

    public IActionResult DeleteAllUsers() {
        DataBaseClient.PlayerCollection.DeleteMany(x => x.Username != "admin");
        DataBaseClient.ArmyCollection.DeleteMany(_ => true);
        DataBaseClient.AccountCollection.DeleteMany(_ => true);
        DataBaseClient.BankCollection.DeleteMany(_ => true);
        return RedirectToAction("Index", "Admin");
    }
}
