using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class Composition
    {
        [Key]
        public int Id { get; set; }
        public string CompositionName { get; set; }
        public string Status { get; set; }
    }
}
