using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblPackingInfo
    {

        [Key]
        public int PackingID { get; set; }
        public string Packing_Name { get; set; }

       
    }
}
