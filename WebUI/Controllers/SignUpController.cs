using SharedClasses.Models.CountryModels;

namespace WebUI.Controllers;

public class SignUpController : Controller
{
    public IActionResult SignIn()
    {
        return View();
    }
    public IActionResult SignUp()
    {
        ViewBag.Countries = Country.GetAllAvailableCountries();

        return View();
    }
}