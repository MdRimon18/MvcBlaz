using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class JournalSetup
    {
        [Key]
        public int Id {get;set;}
        public int JournalTypeId { get; set; }
        public string PreFix { get; set; }
        public int StartingNumber { get; set; }
        public string Status { get; set; }

    }
}
