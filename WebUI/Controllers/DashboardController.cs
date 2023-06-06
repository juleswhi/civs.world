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
    
    public IActionResult BankSettings(string BankName) {

        var bank = DataBaseClient.BankCollection.Find(_ => true)
            .FirstOrDefault();
        ViewBag.Bank = bank;
        return View();
    }

    public IActionResult CreateBank(string BankName, string BankType) {

        var bankSearch = DataBaseClient.BankCollection.Find(
                x => x.BankName == BankName).FirstOrDefault();

        if(bankSearch is null) {
            return RedirectToAction("Banking", "Dashboard");
        }

        var player = DataBaseClient.PlayerCollection.Find(
                x => x.Username == _httpContextAccessor.HttpContext.Session.GetString("Username"))
            .FirstOrDefault();
        var bank = new Bank(player.Id, BankName, BankType);

        DataBaseClient.BankCollection.InsertOne(bank);

        return RedirectToAction("Banking", "Dashboard");
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




    public IActionResult CreateLegion(string LegionType, string LegionName) {
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
        SoldierType legionType = SoldierType.FootSoldier;

        switch(LegionType) {
            case "FootSoldier":
                legionType = SoldierType.FootSoldier;
                break;
            case "Cavalry":
                legionType = SoldierType.Cavalry;
                break;
            case "Tank":
                legionType = SoldierType.Tank;
                break;
            default:
                break;
        }



    var legion = new Legion(army.Id) {
        Tier = 1,
             Marker = new LegionMarker(army.Id, player.Colour) {
                 Name = LegionName,
                 LegionType = legionType,
                 latLng = latitudeLangitude
             }
    };

    army.Forces.Add(legion);



    var filter = Builders<Army>.Filter.Eq(x => x.Id, army.Id);
    var update = Builders<Army>.Update.Set(x => x.Forces, army.Forces);

    DataBaseClient.ArmyCollection.UpdateOne(filter, update);
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
