using SharedClasses.Models.CountryModels;
namespace WebUI.Controllers;


public class MapController : Controller
{
    public IActionResult Index()
    {
        var countries = Country.GetCountryColour();

        ViewBag.Countries = countries;

        return View();
    }

    public IActionResult Personal()
    {
        return View();
    }
}
