//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biddanondo.Dbs
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.Items = new HashSet<Item>();
        }
    
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Location { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<Item> Items { get; set; }
    }
}