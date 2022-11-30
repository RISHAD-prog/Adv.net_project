using Biddanondo.Dbs;
using Biddanondo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biddanondo.Repo
{
    public class CollectionRepo
    {
        public static List<CollectionModel> Get()
        {
            var db = new BiddanondoEntities();
            var dbr = new List<CollectionModel>();
            foreach (var item in db.Collections)
            {
                dbr.Add(new CollectionModel()
                {
                    Id = item.Id,
                    RestaurantName=item.RestaurantName,
                    PreservationTime=item.PreservationTime,
                    Location=item.Location,
                    RestaurantId=item.RestaurantId,
                });
            }
            return dbr;
        }
        public static CollectionModel Get(int id)
        {
            var db = new BiddanondoEntities();
            var model = db.Collections.Find(id);
            return new CollectionModel()
            {
                Id = model.Id,
                PreservationTime = model.PreservationTime,
                RestaurantName = model.RestaurantName,
                Location = model.Location,
                RestaurantId = model.RestaurantId,
            };

        }
        public static CollectionModel Get(String name)
        {
            var db = new BiddanondoEntities();
            var model = (from b in db.Collections
                         where b.RestaurantName == name
                         select b).SingleOrDefault();
            return new CollectionModel()
            {
                Id = model.Id,
                PreservationTime = model.PreservationTime,
                RestaurantName = model.RestaurantName,
                Location = model.Location,
                RestaurantId = model.RestaurantId,
            };

        }
        public static void Create(CollectionModel employee)
        {
            var db = new BiddanondoEntities();
            db.Collections.Add(new Collection()
            {
                Id = employee.Id,
                RestaurantName=employee.RestaurantName,
                PreservationTime=employee.PreservationTime,
                Location = employee.Location,
                RestaurantId=employee.RestaurantId,    
            });

            db.SaveChanges();


        }
    }
}