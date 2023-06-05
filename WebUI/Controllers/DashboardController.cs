using SharedClasses.Models.ArmyModels;
using SharedClasses.Models.BankModels;
using SharedClasses.Models.CountryModels;

namespace WebUI.Controllers;

public class DashboardController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public DashboardController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public IActionResult Index()
    {
        if(_httpContextAccessor.HttpContext.Session.GetString("Username") == "admin")
        {
            return RedirectToAction("Index", "Admin");
        }


        if(_httpContextAccessor.HttpContext.Session.GetString("Username") is null)
            RedirectToAction("Index", "Home");

        return View();
    }


    public IActionResult UserDetails()
    {
        return View();
    }

    public IActionResult Research()
    {
        return View();
    }

    public IActionResult Banking()
    {
        ViewBag.Player = DataBaseClient.PlayerCollection.Find(
                x => x.Username == _httpContextAccessor.HttpContext.Session.GetString("Username")).FirstOrDefault();


        ViewBag.Banks = DataBaseClient.BankCollection.Find(
                _ => true).ToList();


        return View();
    }

    public IActionResult CountrySettings()
    {
        return View();
    }

    public IActionResult CreateBank(string BankName, string BankType) {

        var player = DataBaseClient.PlayerCollection.Find(
                x => x.Username == _httpContextAccessor.HttpContext.Session.GetString("Username"))
            .FirstOrDefault();
        var bank = new Bank(player.Id, BankName, BankType);

        DataBaseClient.BankCollection.InsertOne(bank);

        return RedirectToAction("Bank", "Dashboard");
    }




    public IActionResult Army()
    {
        Player player;
        Army army;
        (player, army) = getPlayer();
        ViewBag.Player = player;
        ViewBag.Army = army;

        return View();
    }



    public IActionResult CreateArmy() {

        if(_httpContextAccessor.HttpContext.Session.GetString("Username") is null) {
            return RedirectToAction("Index", "Home");
        }
        var player = DataBaseClient.PlayerCollection.Find(
                x => x.Username == _httpContextAccessor.HttpContext.Session.GetString("Username")
                ).FirstOrDefault();

        var army = new Army {
            PlayerId = player.Id
        };

        army.Forces = new(); 

        DataBaseClient.ArmyCollection.InsertOne(army);

        return RedirectToAction("Army", "Dashboard");
    }




    public IActionResult CreateLegion() {
        var player = DataBaseClient.PlayerCollection.Find(
                x => x.Username == _httpContextAccessor.HttpContext.Session.GetString("Username")).FirstOrDefault();

        var army = DataBaseClient.ArmyCollection.Find(
                x => x.PlayerId == player.Id).FirstOrDefault();

        List<Country> countries = new();
        foreach(var id in player.CountryIds) {
            var country = DataBaseClient.CountryCollection.Find(
                    x => x.Id == id).FirstOrDefault();

            countries.Add(country);
        }

        var rng = new Random();
   
        var chosencountry = rng.Next(0,countries.Count());

            
    int[] latitudeLangitude = { 
        Convert.ToInt32(countries[chosencountry]
                .Latitude),
        Convert.ToInt32(countries[chosencountry]
                .Longitude)
    };



    var legion = new Legion(army.Id) {
        Tier = 1,
             Marker = new LegionMarker(army.Id) {
                 Name = $"{player.Username}'s Legion ${rng.Next(0,20000)}",
                 latLng = latitudeLangitude
             }
    };
    
    // Update document
    
    army.Forces.Add(legion);
    

        
    var filter = Builders<Army>.Filter.Eq(x => x.Id, army.Id);
    var update = Builders<Army>.Update.Set(x => x.Forces, army.Forces);

    return RedirectToAction("Army", "Dashboard");

    }





    public (Player, Army) getPlayer() {
        var player = DataBaseClient.PlayerCollection.Find(
                x => x.Username == _httpContextAccessor.HttpContext.Session.GetString("Username")
                ).FirstOrDefault();

        var army = DataBaseClient.ArmyCollection.Find(x => x.PlayerId == player.Id).FirstOrDefault();

        return (player, army);
    }
}
