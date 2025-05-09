using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class SizeEntry
    {
        [Key]
        public int Id { get; set; }
        public int Sequence { get; set; }
        public string Status { get; set; }
        public string SinzeName { get; set; }
    }
}
