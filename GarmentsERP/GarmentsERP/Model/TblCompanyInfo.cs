using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblCompanyInfo
    {
        
        [Key]

        public int CompID { get; set; }
        public string Company_Name { get; set; }
        public string Details { get; set; }

       
    }
}
