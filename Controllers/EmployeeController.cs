using ImplementationForm.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationForm.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {

            var data = context.Employees.ToList();
            return View(data);
           
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
         {
            var Name = model.Name;
            var users = (from x in context.Employees where x.Name == Name select x).ToList();
            if (ModelState.IsValid)
            {
                if (users.Count > 0)
                {
                    ViewBag.Duplicate = "* Enter Name" + " "  + Name +" "+  "is already exists in Database!";
                    //TempData["error"] = "Record Already in Databse!";
                    ModelState.Clear();
                    return View(model);
                }
                else
                {
                    var emp = new Employee()
                    {
                        Name = model.Name,
                        City = model.City
                    };
                    context.Employees.Add(emp);
                    context.SaveChanges();
                    TempData["error"] = "Data Saved";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            TempData["error"] = "Deleted";
            return RedirectToAction("Index");
        }
        //public ActionResult Delete(int id)
        //{
        //        var std = context.Employees.Where(x => x.Id == id).FirstOrDefault<Employee>();
        //        context.Employees.Remove(std);
        //        context.SaveChanges();
            
        //    return Json(true);
        //}
    }
}
