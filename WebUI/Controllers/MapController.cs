
namespace WebUI.Controllers;


public class MapController : Controller
{
    public IActionResult Index()
    {
        var valuesDictionary = PopulateMapDictionary.PopulateDictionary();

        ViewBag.valuesDictionary = valuesDictionary;

        return View();
    }
}