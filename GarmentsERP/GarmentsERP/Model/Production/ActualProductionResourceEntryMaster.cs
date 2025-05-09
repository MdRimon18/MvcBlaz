using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class ActualProductionResourceEntryMaster
    {
        public int Id { get; set; }
        public string SystemId { get; set; }
        public int LocationId { get; set; }
        public int FloorId { get; set; }
        public string LineMerge { get; set; }
        public int LineNo { get; set; }


        public string Status { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }

        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }

        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }

        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string FloorName { get; set; }
        [NotMapped]
        public string Line { get; set; }
    }
}
