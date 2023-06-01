using Newtonsoft.Json;
using SharedClasses.Models.CountryModels;
namespace WebUI.Controllers;


public class MapController : Controller
{
    public IActionResult Index()
    {
        var countries = Country.GetCountryColour();

        string JsonValues = JsonConvert.SerializeObject(countries, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        ViewBag.Countries = JsonValues;


        return View();
    }

    public IActionResult Personal()
    {
        return View();
    }
}