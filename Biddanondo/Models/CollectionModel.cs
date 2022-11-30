using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biddanondo.Models
{
    public class CollectionModel
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public int PreservationTime { get; set; }
        public string Location { get; set; }
        public Nullable<int> RestaurantId { get; set; }
    }
}