using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class GeneralItemTransferDisplay
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public double CurrentStock { get; set; }
        public double AvgRate { get; set; }
        public double TransferValue { get; set; }
        public int Uom { get; set; }


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
