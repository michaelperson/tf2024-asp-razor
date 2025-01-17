using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tf2024_asp_razor.Models;

namespace tf2024_asp_razor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("")]
    [Route("Home")]
    [Route("Home/Index")]
    public IActionResult Index()
    {
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

    [HttpGet()] //httpverbs
                // [Route("zorba/legrec")] //le chemin pour atteindre le fonction c#
    
    public IActionResult Infos()
    {
        Zorro i = new Zorro() { Nom = "Le barbare", Description = "Relire le nom" };

        // return View("toto",i);
        return View("Privacy");
    }
}