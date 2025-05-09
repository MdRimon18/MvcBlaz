using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblLocationInfo
    {

        [Key]
        public int LocationId { get; set; }
        public string Location_Name { get; set; }

      
    }
}
