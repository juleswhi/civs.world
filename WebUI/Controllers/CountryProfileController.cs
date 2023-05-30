using SharedClasses.Models.CountryModels;
using MongoDB.Driver;

namespace WebUI.Controllers;


public class CountryProfileController : Controller
{
    public IActionResult Index(string CountryName)
    {

        var country = DataBaseClient.CountryCollection.Find(
            Builders<Country>.Filter.Eq(x => x.Name, CountryName)
        ).FirstOrDefault();

        ViewBag.Country = country;

        return View();
    }
}