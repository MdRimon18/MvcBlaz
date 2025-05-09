using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblSeasonInfo
    {

        [Key]
        public int SeasonID { get; set; }
        public string Season_Name { get; set; }

        
    }
}
