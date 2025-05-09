using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblRegionInfo
    {

        [Key]
        public int RegionID { get; set; }
        public string Region_Name { get; set; }
        public string CuttOff { get; set; }
        


    }
}
