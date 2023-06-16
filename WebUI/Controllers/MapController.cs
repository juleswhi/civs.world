using SharedClasses.Models.CountryModels;
namespace WebUI.Controllers;


public class MapController : Controller
{
    public enum MapType {
        Global,
        Army
    }
    public IActionResult Index(MapType mapType)
    {
        var countries = Country.GetCountryColour();

        ViewBag.Countries = countries;
        ViewBag.mapType = mapType;


        return View();
    }

}
