using AspcoreBll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tf2024_asp_razor.Database;
using tf2024_asp_razor.entities.Interfaces;
using tf2024_asp_razor.Models.Entities;
using tf2024_asp_razor.Models.Entities.Taxable;
using tf2024_asp_razor.Models.Plane;

namespace tf2024_asp_razor.Controllers;

public class PlaneController(ILogger<PlaneController> logger ,IPlaneService ps) : Controller
{
   

    [Route("/Plane")]
    [Route("/Plane/List")]
    public IActionResult Index()
    {
        return View(new PlaneListVM(ps.GetAll(p=>(p as PlaneEntity).Type, T=>(T as PlaneEntity).Owner)));
    }

    public IActionResult Create()
    {
        var model = new PlaneCreateVM();
        model.Form = new FPlaneCreate();
        //model.Persons = new db.Taxables;
        //model.Types = db.Types;

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(FPlaneCreate form)
    {
        if (!ModelState.IsValid)
        {
            var model = new PlaneCreateVM();
            model.Form = form;
            //model.Persons = db.Taxables;
            //model.Types = db.Types;

            return View(model);
        }

        
        
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        logger.LogInformation($"Delete plane with id: {id}");
        if (ps.Delete(id))
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
        
    }
}