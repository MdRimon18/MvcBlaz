using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class JournalType
    {
        [Key]
        public int Id { get; set; }
        public string JournalTypeName { get; set; }
        public string status { get; set; }
    }
}
