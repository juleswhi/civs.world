using SharedClasses.Models.CountryModels;

namespace WebUI.Controllers;


public class CountryProfileController : Controller
{
    public IActionResult Index(string? CountryName)
    {
        if(CountryName is null) return RedirectToAction("Index", "Home");
        if(CountryName.Length == 2) {
            var foundCountry = DataBaseClient.CountryCollection.Find(x => x.CountryCode == CountryName).FirstOrDefault();
            if(foundCountry is null) return RedirectToAction("Index", "Map");
            
            CountryName = foundCountry.Name;
        }

        var country = DataBaseClient.CountryCollection.Find(
            Builders<Country>.Filter.Eq(x => x.Name, CountryName)
        ).FirstOrDefault();

        ViewBag.Country = country;

        return View();
    }

    public IActionResult OnGetIndex(string CountryName) {
        return RedirectToAction("Index", "CountryProfile", new { CountryName = CountryName } );
    }

}
