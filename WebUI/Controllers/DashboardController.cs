using SharedClasses.Models.ArmyModels;

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
    public IActionResult Army()
    {
        ViewBag.Details = getPlayer();
        return View();
    }

    public (Player, Army) getPlayer() {

        
        var player = DataBaseClient.PlayerCollection.Find(
                x => x.Username == _httpContextAccessor.HttpContext.Session.GetString("Username")
                ).FirstOrDefault();

        var army = DataBaseClient.ArmyCollection.Find(x => x.PlayerId == player.Id).FirstOrDefault();

        return (player, army);
    }
}
