using Biddanondo.Dbs;
using Biddanondo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biddanondo.Repo
{
    public class RestaurantRepo
    {
        public static List<RestaurantModel> Get()
        {
            var db = new BiddanondoEntities();
            var dbr = new List<RestaurantModel>();
            foreach (var item in db.Restaurants)
            {
                dbr.Add(new RestaurantModel()
                {
                    Id = item.Id,
                    RestaurantName = item.RestaurantName,
                    Location = item.Location,
                });
            }
            return dbr;
        }
        public static RestaurantModel Get(int id)
        {
            var db = new BiddanondoEntities();
            var model = db.Restaurants.Find(id);
            return new RestaurantModel()
            {
                Id = model.Id,
                Location = model.Location,
                RestaurantName = model.RestaurantName,
            };

        }
        
        public static RestaurantModel Get(string name)
        {
            var db = new BiddanondoEntities();
            var model = (from b in db.Restaurants
                         where b.RestaurantName == name
                         select b).SingleOrDefault();
            return new RestaurantModel()
            {
                Id = model.Id,
                RestaurantName = model.RestaurantName,
                Password=model.Password
            };

        }
        public static void Create(RestaurantModel employee)
        {
            var db = new BiddanondoEntities();
            db.Restaurants.Add(new Restaurant()
            {
                Id = employee.Id,
                RestaurantName = employee.RestaurantName,
                Location = employee.Location,
            });

            db.SaveChanges();


        }
    }
}