using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using SharedClasses.Helpers.CountryMapSerialisation;
using SharedClasses.Helpers;
using MongoDB.Driver;
using SharedClasses.Models.UserModels;

namespace WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public IActionResult Index()
    {
        if(_httpContextAccessor.HttpContext.Session.GetString("Username") is null)
        {
            return RedirectToAction("NewUserIndex", "Home");
        }

        return View();
    }

    public IActionResult NewUserIndex()
    {
        if(_httpContextAccessor.HttpContext.Session.GetString("Username") is null)
        {
            return View();
        }

        return RedirectToAction("Index", "Home");
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
