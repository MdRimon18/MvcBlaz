using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class YarnCount
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }
        public string Status { get; set; }
       
    }
}
