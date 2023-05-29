using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using SharedClasses.Helpers.CountryMapSerialisation;
using SharedClasses.Helpers;
using MongoDB.Driver;
using SharedClasses.Models.UserModels;


namespace WebUI.Controllers;


public class SignUpController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }
 
    public IActionResult SignIn()
    {
        return View();
    }
}