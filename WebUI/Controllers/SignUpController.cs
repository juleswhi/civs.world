using SharedClasses.Models.CountryModels;
using SharedClasses.Models.UserModels;
using SharedClasses.Helpers;

namespace WebUI.Controllers;

public class SignUpController : Controller
{

    private readonly IHttpContextAccessor _httpContextAccessor;

    public SignUpController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IActionResult SignIn(bool LoginFailure, string Reason)
    {
        if (LoginFailure)
        {
            ViewBag.LoginFailure = LoginFailure;
            ViewBag.Reason = Reason;

        }
        else
            ViewBag.LoginFailure = false;

        return View();
    }





    public IActionResult Authenticate(string username, string password)
    {
        if (DataBaseClient.PlayerCollection is null)
            return RedirectToAction("Privacy", "Home");

        string hashedPassword = password.Hash(ParseExtensions.salt);

        var user = DataBaseClient.PlayerCollection.Find(
            x => x.Username == username && x.Password == hashedPassword
        ).FirstOrDefault();


        if (_httpContextAccessor.HttpContext is null)
            return RedirectToAction("Privacy", "Home");

        if (user != null)
        {
            _httpContextAccessor.HttpContext.Session.SetString("Username", user.Username);
            _httpContextAccessor.HttpContext.Session.SetString("UserId", user.Id.ToString());
            return RedirectToAction("Index", "Dashboard");
        }
        else
        {
            return RedirectToAction("SignIn", "SignUp", new { LoginFailure = true });
        }
    }



    public async Task<IActionResult> CreateUser(string username, string password, string Name, string country)
    {

        if (username is null) return RedirectToAction("Contact", "Home");

        if (password is null) return RedirectToAction("Contact", "Home");

        if(Name is null) return RedirectToAction("Contact", "Home");        

        string firstname = Name.Split(" ")[0];
        string surname = Name.Split(" ")[1];


        if (firstname is null || surname is null || country is null)
            return RedirectToAction("Contact", "Home");


        var availableCountries = Country.GetAllAvailableCountries();

        var name = new Name(firstname, surname);

        var result = await Player.CreatePlayer(
            name,
            password,
            username,
            country
        );

        if(result != Code.Ok)
        {
            return RedirectToAction("SignIn", "SignUp", new { LoginFailure = true, Reason = result.ToString() });
        }





        return RedirectToAction("Authenticate", "SignUp", new { username = username, password = password });
    }




    public IActionResult SignUp()
    {
        ViewBag.Countries = Country.GetAllAvailableCountries();

        return View();
    }


    public IActionResult Logout()
    {


        var sessionId = _httpContextAccessor.HttpContext.Session.Id;

        _httpContextAccessor.HttpContext.Session.Remove(sessionId);

        return RedirectToAction("Index", "Home");
    }
}