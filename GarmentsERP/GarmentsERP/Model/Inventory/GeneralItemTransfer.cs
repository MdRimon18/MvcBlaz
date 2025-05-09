using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class GeneralItemTransfer
    {
        public int Id { get; set; }
        public string TransferSystemID { get; set; }
        public string TransferCriteria { get; set; }
        public int Company { get; set; }
        public int ToCompany { get; set; }
        public string TransferDate { get; set; }
        public string ChallanNo { get; set; }
        public int ItemCategory { get; set; }


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
