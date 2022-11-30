using Biddanondo.Dbs;
using Biddanondo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biddanondo.Repo
{
    public class EmployeeRepo
    {
        public static List<EmployeeModel> Get()
        {
            var db = new BiddanondoEntities();
            var dbr = new List<EmployeeModel>();
            foreach (var item in db.Employees)
            {
                dbr.Add(new EmployeeModel()
                {
                    Id = item.Id,
                    EmployeeName = item.EmployeeName,
                    Location = item.Location,
                    Password = item.Password,
                });
            }
            return dbr;
        }
        public static EmployeeModel Get(String name)
        {
            var db = new BiddanondoEntities();
            var model = (from b in db.Employees
                         where b.EmployeeName == name
                         select b).SingleOrDefault(); 
            return new EmployeeModel()
            {
                Id=model.Id,
                EmployeeName = model.EmployeeName,
                Location=model.Location,
                Password= model.Password,
            };

        }
        public static void Create(EmployeeModel employee)
        {
            var db = new BiddanondoEntities();
            db.Employees.Add(new Employee()
            {
                Id = employee.Id,
                EmployeeName= employee.EmployeeName,
                Location=employee.Location,
                Password=employee.Password,
            });

            db.SaveChanges();


        }
    }
}