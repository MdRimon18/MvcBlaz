using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblSubDeptInfo
    {

        [Key]
        public int SubDeptID { get; set; }
        public string Sub_dept_Name { get; set; }
        public int? DepartmentID { get; set; }

       
    }
}
