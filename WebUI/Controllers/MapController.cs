
namespace WebUI.Controllers;


public class MapController : Controller
{
    public IActionResult Index()
    {
        (ViewBag.Players, ViewBag.Countries) = GetData.GetPlayersAndCountries();

        return View();
    }

    public IActionResult Personal()
    {
        return View();
    }
}