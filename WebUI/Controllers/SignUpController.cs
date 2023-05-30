using SharedClasses.Models.CountryModels;

namespace WebUI.Controllers;

public class SignUpController : Controller
{
    public IActionResult SignIn()
    {
        return View();
    }
    public IActionResult Authenticate(string username, string password)
    {
        string hashedPassword = password.Hash(ParseExtensions.salt);

        var user = DataBaseClient.PlayerCollection.Find(
            x => x.Username == username && x.Password == hashedPassword
        ).FirstOrDefault();

        if(user != null)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View("Error", "UserNotFound");
        }
    }
    public IActionResult SignUp()
    {
        ViewBag.Countries = Country.GetAllAvailableCountries();

        return View();
    }
}