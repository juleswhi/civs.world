using Microsoft.AspNetCore.CookiePolicy;

using SharedClasses.Models.CountryModels;

namespace WebUI.Controllers;

public class SignUpController : Controller
{

    private readonly IHttpContextAccessor _httpContextAccessor;


    public IActionResult SignIn(bool LoginFailure)
    {
        if(LoginFailure)
            ViewBag.LoginFailure = LoginFailure;
        else
            ViewBag.LoginFailure = false;
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

            _httpContextAccessor.HttpContext.Session.SetString("Username", user.Username);
            _httpContextAccessor.HttpContext.Session.SetString("UserId", user.Id.ToString());
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return RedirectToAction("SignIn", "SignUp", new { LoginFailure = true });
        }
    }




    public IActionResult SignUp()
    {
        ViewBag.Countries = Country.GetAllAvailableCountries();

        return View();
    }
}