using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblProductCategoryInfo
    {

        [Key]
        public int ProdCatId { get; set; }
        public string ProdCategory_Name { get; set; }

      
    }
}
