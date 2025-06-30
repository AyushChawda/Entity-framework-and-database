using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Entity_framework.Models;
using Microsoft.EntityFrameworkCore;

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

    // Home page Show student List 
    public IActionResult Index()
    {
        var std = studentDb.Students_Details.ToList();
        return View(std);
    }


    // Add the new Student 
    public IActionResult Create()
    {
        
        return View();
    }

    [HttpPost]
    public async Task <IActionResult> Create(Student std)
    {
        if (ModelState.IsValid)
        {
            await studentDb.Students_Details.AddAsync(std);
            await studentDb.SaveChangesAsync();
            TempData["insert_sucess"] = "Student Add Succesfully";
            return RedirectToAction("Index", "Home");
        }

        return View(std);
    }

    // View the student details 

    public async Task <IActionResult> Details(int? id)
    {
        if(id==null || studentDb.Students_Details == null)
        {
            return NotFound();
        }
        var std = await studentDb.Students_Details.FirstOrDefaultAsync(x => x.Id == id);
        if (std == null)
        {
            NotFound();
        }
        return View(std);
    }

    // Edit the student details 

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || studentDb.Students_Details == null)
        {
            return NotFound();
        }
        var std = await studentDb.Students_Details.FindAsync(id);
        if (std == null)
        {
            NotFound();
        }
        return View(std);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int? id ,Student std)
    {
        if (id != std.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            studentDb.Students_Details.Update(std);
            await studentDb.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        return View(std);
    }


    // Removing the Student from the table 

    public async Task<IActionResult> Delete(int? id )
    {
      

        if (id == null || studentDb.Students_Details == null )
        {
            return NotFound();
        }
        var std = await studentDb.Students_Details.FirstOrDefaultAsync(x => x.Id == id);
        
        return View(std);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteStudent(int? id)
    {

        var std = await studentDb.Students_Details.FindAsync(id);
        if (std != null)
        {
            studentDb.Students_Details.Remove(std);
            await studentDb.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return NotFound();
        }

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
