using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class YarnComp1
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
        
}
