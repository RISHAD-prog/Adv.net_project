using Biddanondo.Dbs;
using Biddanondo.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Biddanondo.Repo
{
    public class AdminRepo
    {
        public static List<AdminModel> Get()
        {
            return null;
        }
        public static AdminModel Get(String Name)
        {
            var db = new BiddanondoEntities();
            var model = (from b in db.Admins
                         where b.Name == Name
                         select b).SingleOrDefault();

            return new AdminModel()
            {
                Id=model.Id,
                Name =model.Name,
                Password=model.Password,
            };

        }
        
    }
}