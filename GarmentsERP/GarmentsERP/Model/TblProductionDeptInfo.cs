using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblProductionDeptInfo
    {

        [Key]
        public int ID { get; set; }
        public string ProdDeptName { get; set; }
        public int? Department_Id { get; set; }

        
    }
}
