using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class ItemCategory
    {
        [Key]
        public int Id { get; set; }
        public string ItemCategoryName { get; set; }
        public string Status { get; set; }
       
    }
}
