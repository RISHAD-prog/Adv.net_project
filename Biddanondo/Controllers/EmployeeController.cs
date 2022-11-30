using Biddanondo.Dbs;
using Biddanondo.Models;
using Biddanondo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace Biddanondo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var product = Session["Login"].ToString();
                var json = new JavaScriptSerializer().Deserialize<List<EmployeeModel>>(product);
                ViewBag.Product = json;
                return View(ItemRepo.Get());
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepo.Create(employee);
                    TempData["msg"] = "User Added";
                    return View(employee);
                }
                else
                {

                    return View(employee);
                }
            }
            catch
            {
                return View(employee);

            }
        }

        [HttpGet]
        public ActionResult Order()
        {
            if (Session["Login"] != null)
            {

                var collect = Session["Collect"].ToString();
                var products = new JavaScriptSerializer().Deserialize<List<CollectionModel>>(collect);
               
                return View(products);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
       
        [HttpPost]
        public ActionResult Order(int id)
        { 
             var item =CollectionRepo.Get(id);
             
            var json = Session["Login"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<EmployeeModel>>(json);
            foreach(var product in products)
            {
                ItemRepo.Create(new ItemModel()
                {
                   
                    RestaurantName = item.RestaurantName,
                    Location = item.Location,
                    EmployeeId = product.Id,
                    EmployeeName = product.EmployeeName,

                });
            }                                                                                              
            TempData["msg"] = "Order Accepted";
            return RedirectToAction("Index");

        }
        public ActionResult Logout()
        {
            if (Session["Login"]!=null)
            {
                Session["Login"] = null;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }

    
}