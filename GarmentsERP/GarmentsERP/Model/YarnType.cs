using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class YarnType
    {

        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

       
    }
}
