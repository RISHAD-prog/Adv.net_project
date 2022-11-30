using Biddanondo.Dbs;
using Biddanondo.Models;
using Biddanondo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Biddanondo.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            if (Session["Admin"]==null)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                return View(CollectionRepo.Get());
            }
           
        }
        public ActionResult Collect(int id)
        {
            var db = CollectionRepo.Get(id);

            List<CollectionModel> products = null;
            if (Session["Collect"] == null)
            {
                products = new List<CollectionModel>();
            }
            else
            {
                var new_list = Session["Collect"].ToString();
                products = new JavaScriptSerializer().Deserialize<List<CollectionModel>>(new_list);
            }
            products.Add(db);
            var json = new JavaScriptSerializer().Serialize(products);
            Session["Collect"] = json;
            TempData["msg"] = "Requested has been taken";
            return RedirectToAction("Index");
        }
        public ActionResult ShowItem()
        {
            if (Session["Collect"] == null)
            {
                TempData["msg"] = "Cart is empty";
                return RedirectToAction("Index");
            }
            else
            {
                var product = Session["Collect"].ToString();
                var json = new JavaScriptSerializer().Deserialize<List<CollectionModel>>(product);
                return View(json);
            }


        }
        public ActionResult Logout()
        {
            if (Session["Admin"] != null)
            {
                Session["Admin"] = null;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}