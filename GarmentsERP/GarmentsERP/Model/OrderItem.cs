using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class OrderItem
    {
        
        [Key]
        public int ItemID { get; set; }
        public string Name { get; set; }

       
    }
}
