using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class GarmentsItemEntry
    {
        [Key]
    public int Id { get; set; }
    public string ItemName {get;set;}
    public string   CommercialName  {get;set;}
    public int ProductCategoryId { get; set; }
    public int ProductTypeId { get; set; }
    public double? StandardSMV { get; set; }
    public double? Efficiency { get; set; }
    public string Status { get; set; }
        [NotMapped]
    public string ProductTypeName { get; set; } 

        [NotMapped]
    public string ProductCategoryName { get; set; }
    }
}
