using Biddanondo.Dbs;
using Biddanondo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biddanondo.Repo
{
    public class ItemRepo
    {
        public static List<ItemModel> Get()
        {
            var db = new BiddanondoEntities();
            var dbr = new List<ItemModel>();
            foreach (var item in db.Items)
            {
                dbr.Add(new ItemModel()
                {
                    Id = item.Id,

                    EmployeeId = item.EmployeeId,
                    RestaurantName = item.RestaurantName,
                    EmployeeName = item.EmployeeName,
                    Location = item.Location,
                });
            }
            return dbr;
        }
        public static ItemModel Get(int id)
        {
            return null;

        }
        public static void Create(ItemModel employee)
        {
            var db = new BiddanondoEntities();
            db.Items.Add(new Item()
            {
                Id = employee.Id,
               
                EmployeeId= employee.EmployeeId,
                RestaurantName=employee.RestaurantName,
                EmployeeName = employee.EmployeeName,
                Location=employee.Location,
            });

            db.SaveChanges();


        }
    }
}