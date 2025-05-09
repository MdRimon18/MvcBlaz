using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class ItemGroup
    {
        [Key]
        public int Id { get; set; }
        public int ItemCategoryId { get; set; }
        public string GroupCode { get; set; }
        public string ItemGroupName { get; set; }
        public string ItemType { get; set; }
        public string OrderUom { get; set; }
        public string ConsUom { get; set; }
        public double?   ConvFactor { get; set; }
        public string FancyItem { get; set; }
        public string CalParameter { get; set; }
        public string status { get; set; }
        [NotMapped]
        public string ItemCategoryName { get; set; }

    }
}
