using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class UserMapping
    {
        [Key]
        public int Id {get;set;}
        public int UserId {get;set;}
        public int EmpCategoryId {get;set;}
        public int DepartmentId {get;set;}
        public int DesignationId {get;set;}
        public int AdditionDesignationId { get;set;}


        public string UnitName { get; set; }
        public int BuyerId { get; set; }
        public string DataLevelSecurity { get; set; }
        public string HomeGraph { get; set; }
        public string BindtoIP { get; set; }
        public string ExpiryDate { get; set; }


        public string Status { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }


        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public string EmpCategory { get; set; }
        [NotMapped]
        public string Department { get; set; }
        [NotMapped]
        public string Designation { get; set; }
        [NotMapped]
        public string AdditionDesignation { get; set; }
    }
}
