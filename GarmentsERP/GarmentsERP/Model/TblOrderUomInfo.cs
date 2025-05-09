using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblOrderUomInfo
    {

        [Key]
        public int UOMID { get; set; }
        public string Order_Uom_Name { get; set; }

      
    }
}
