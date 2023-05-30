namespace WebUI.Controllers;


public class CountryProfileController : Controller
{
    public IActionResult Index(string CountryName)
    {

        var country = DataBaseClient.CountryCollection.Find(x => x.Name == CountryName);

        ViewBag.Country = country;

        return View();
    }
}