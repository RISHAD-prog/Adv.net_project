using Biddanondo.Dbs;
using Biddanondo.Models;
using Biddanondo.Repo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Biddanondo.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            if (Session["Res"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var restaurant = CollectionRepo.Get();
                var new_list = Session["Res"].ToString();
                var products = new JavaScriptSerializer().Deserialize<List<RestaurantModel>>(new_list);
                ViewBag.restaurants = products;
                return View(restaurant);
            }
         
        }
        [HttpGet]
        public ActionResult Dashboard()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Dashboard(CollectionModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CollectionRepo.Create(collection);
                    
                    return View(collection);
                }

                else
                {
                    TempData["msg"] = "New request created";
                    return View(collection);
                }
            }
            catch
            {
                return View(collection);

            }
        }
        

       
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantModel restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RestaurantRepo.Create(restaurant);
                    TempData["msg"] = "Request has been created";
                    return View(restaurant);
                }

                else
                {

                    return View(restaurant);
                }
            }
            catch
            {
                return View(restaurant);

            }
        }
        public ActionResult Logout()
        {
            if (Session["Res"] != null)
            {
                Session["Res"] = null;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}