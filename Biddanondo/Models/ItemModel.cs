using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biddanondo.Models
{
    public class ItemModel
    {
        public int Id { get; set; }       
        public int EmployeeId { get; set; }
        public string RestaurantName { get; set; }
        public string EmployeeName { get; set; }
        public string Location { get; set; }
    }
}