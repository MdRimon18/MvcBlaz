using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class ItemAccountCreation
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ItemCategoryId { get; set; }
        public int ItemGroupId { get; set; }
        public string SubGroupCode { get; set; }
        public string SubGroupName { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string ItemSize { get; set; }
        public string ReOrderLabel { get; set; }
        public string MinLabel { get; set; }
        public string MaxLabel { get; set; }  
        public string OrderUom { get; set; }
        public string ConsUom { get; set; }
        public string ItemAccount { get; set; }
        public string Status { get; set; }
        public string Brand { get; set; }
        public int OriginOrCountryId { get; set; }
        public string Model { get; set; }

        [NotMapped]
        public string CompanyName { get; set; }

       [NotMapped]
       public string ItemCategoryName { get; set; }

        [NotMapped]
       public string ItemGroupName { get; set; }

    }
}
