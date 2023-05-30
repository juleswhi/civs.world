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



    public async Task<IActionResult> CreateUser(string username, string password, string name, string country)
    {

        if (username is null) return RedirectToAction("SignIn", "SignUp", new { LoginFailure = true, Reason = "Username is null" });

        if (password is null) return RedirectToAction("SignIn", "SignUp", new { LoginFailure = true, Reason = "Password Is Null" });

        if (name is null) return RedirectToAction("SignIn", "SignUp", new { LoginFailure = true, Reason = "Name is null" });

        if (country is null) return RedirectToAction("SignIn", "SignUp", new { LoginFailure = true, Reason = "Country Is Null" });

        string firstname;
        string surname;

        try
        {
            firstname = name.Split(" ")[0];
            surname = name.Split(" ")[1];

        }
        catch(Exception err)
        {
            return RedirectToAction("SignIn", "SignUp", new { LoginFailure = true, Reason = "Firstname or Surname are null"})
        }


        if (firstname is null || surname is null) return RedirectToAction("SignIn", "SignUp", new { LoginFailure = true, Reason = "Name Is Null" });


        var availableCountries = Country.GetAllAvailableCountries();

        var Name = new Name(firstname, surname);

        var result = await Player.CreatePlayer(
            Name,
            password,
            username,
            country
        );

        if (result != Code.Ok)
        {
            return RedirectToAction("SignIn", "SignUp", new { LoginFailure = true, Reason = result.ToString() });
        }


        return RedirectToAction("Authenticate", "SignUp", new { username = username, password = password });
    }






    public IActionResult Logout()
    {


        var sessionId = _httpContextAccessor.HttpContext.Session.Id;

        _httpContextAccessor.HttpContext.Session.Remove(sessionId);

        return RedirectToAction("Index", "Home");
    }
}