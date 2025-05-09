using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class ProductSubDepartment
    {
        [Key]
     public int      Id {get;set;}
     public string   SubDepartmentName {get;set;}
     public string   DepartnemtName {get;set;}
     public int      BuyerNameId { get;set;}

        [NotMapped]
        public string BuyerName { get;set;}
}
}
