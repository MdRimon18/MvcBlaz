using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class TNATaskEntry
    {
        [Key]
        public int Id { get; set; }
        public int TaskNameId { get; set; }
        public string TaskShortName { get; set; }
        public string Penalty { get; set; }
        public int SequenceNo { get; set; }
        public int? Completion { get; set; }
        public string GroupName { get; set; }
        public string Status { get; set; }
        public int? GroupSeqNo { get; set; }
        [NotMapped]
        public string TNATaskEntryNmae { get; set; }



    }
}
