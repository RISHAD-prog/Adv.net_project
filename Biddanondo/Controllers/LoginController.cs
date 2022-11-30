using Biddanondo.Models;
using Biddanondo.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Biddanondo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String Name, String Password)
        {
            
            if(Name.Substring(0, 3) =="Res")
            {
                var restaurant = RestaurantRepo.Get(Name);
                if (Name == restaurant.RestaurantName && Password == restaurant.Password)
                {
                    List<RestaurantModel> products = null;
                    if (Session["Res"] == null)
                    {
                        products = new List<RestaurantModel>();
                    }
                    else
                    {
                        var new_list = Session["Res"].ToString();
                        products = new JavaScriptSerializer().Deserialize<List<RestaurantModel>>(new_list);
                    }
                    products.Add(restaurant);
                    var json = new JavaScriptSerializer().Serialize(products);
                    Session["Res"] = json;
                    TempData["msg"] = "Restaurant has been listed";
                    return RedirectToAction("Index", "Restaurant");
                }
                else
                {
                    TempData["Val"] = "Invalid Login";
                    return View();   
                }
                
            }
            else if(Name.Substring(0, 3) =="Emp")
            {
                var employee = EmployeeRepo.Get(Name);
                if (Name == employee.EmployeeName && Password == employee.Password)
                {
                    List<EmployeeModel> products = null;
                    if (Session["Login"] == null)
                    {
                        products = new List<EmployeeModel>();
                    }
                    else
                    {
                        var new_list = Session["Login"].ToString();
                        products = new JavaScriptSerializer().Deserialize<List<EmployeeModel>>(new_list);
                    }
                    products.Add(employee);
                    var json = new JavaScriptSerializer().Serialize(products);
                    Session["Login"] = json;
                    TempData["msg"] = "Employee has been listed";
                    return RedirectToAction("Index", "Employee");

                }
                else
                {
                    TempData["Val"] = "Invalid Login";
                    return View();
                }
                
            }
            else if(Name.Substring(0,3) =="Adm")
            {
                var admin = AdminRepo.Get(Name);
                if (Name == admin.Name && Password == admin.Password)
                {
                    List<AdminModel> products = null;
                    if (Session["Admin"] == null)
                    {
                        products = new List<AdminModel>();
                    }
                    else
                    {
                        var new_list = Session["Admin"].ToString();
                        products = new JavaScriptSerializer().Deserialize<List<AdminModel>>(new_list);
                    }
                    products.Add(admin);
                    var json = new JavaScriptSerializer().Serialize(products);
                    Session["Admin"] = json;
                    TempData["msg"] = "Admin has been listed";
                    return RedirectToAction("Index", "Request");
                }
                else
                {
                    TempData["Val"] = "Invalid Login";
                    return View();
                }
               
            }
            else
            {
                TempData["Val"] = "You doesn't registered yet";
                return View();
            }

              
            
        }
    }
}