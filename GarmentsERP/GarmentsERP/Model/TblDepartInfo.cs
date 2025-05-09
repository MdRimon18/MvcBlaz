using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblDepartInfo
    {

        [Key]
        public int DepId { get; set; }
        public string DepartmentName { get; set; }
        public string Details { get; set; }
        
    }
}
