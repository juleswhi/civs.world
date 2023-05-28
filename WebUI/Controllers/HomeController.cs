using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using SharedClasses.Helpers.CountryMapSerialisation;


namespace WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var dictCreate = new PopulateMapDictionary();
        var valuesDictionary = dictCreate.PopulateDictionary();


        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
