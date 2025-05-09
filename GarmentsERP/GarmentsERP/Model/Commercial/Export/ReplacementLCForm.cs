using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class ReplacementLCForm
    {
        public int Id { get; set; }
        public int ExportLCMasterId { get; set; }
        public int SalesContractMasterId { get; set; }
        public string SalesContract { get; set; }
        public double? ReplacedAmount { get; set; }
        public double? ContractValue { get; set; }
        public double? CumulativeReplaced { get; set; }
        public double? YettoReplace { get; set; }
        public string AttachedBTBLC { get; set; }


        public string Status { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }

        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }

        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }


    }
}
