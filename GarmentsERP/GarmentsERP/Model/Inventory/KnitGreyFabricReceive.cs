using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class KnitGreyFabricReceive
    {
        public int Id { get; set; }
        public string ReceivedID { get; set; }
        public int CompanyId { get; set; }
        public string ReceiveBasis { get; set; }
        public string ReceiveDate { get; set; }
        public string ReceiveChallanNo { get; set; }
        public string WoPIProduction { get; set; }
        public int LocationId { get; set; }
        public string KnittingSource { get; set; }
        public string KnittingComp { get; set; }
        public string StoreName { get; set; }
        public string YarnIssueChNo { get; set; }
        public string JobNo { get; set; }
        public int BuyerId { get; set; }
        public string Remarks { get; set; }


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
        public string CompanyName { get; set; } 
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string BuyerName { get; set; }


    }
}
