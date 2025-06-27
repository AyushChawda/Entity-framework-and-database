using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Entity_framework.Models;

namespace Entity_framework.Controllers;

public class HomeController : Controller
{
    private readonly StudentDbContext studentDb;

    //private readonly ILogger<HomeController> _logger;

    //public HomeController(ILogger<HomeController> logger)
    //{
    //    _logger = logger;
    //}

    public HomeController(StudentDbContext studentDb)
    {
        this.studentDb = studentDb;
    }
    public IActionResult Index()
    {
        var std = studentDb.Students_Details.ToList();
        return View(std);
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
