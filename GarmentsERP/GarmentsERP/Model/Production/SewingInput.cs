using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class SewingInput
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public int SewCompanyId { get; set; }
        public string OrderNo { get; set; }
        public int CountryId { get; set; }
        public int BuyerId { get; set; }
        public string JobNo { get; set; }
        public string Style { get; set; }
        public int ItemId { get; set; }
        public double OrderQnty { get; set; }
        public int LocationId { get; set; }
        public int FloorId { get; set; }
        public string InputDate { get; set; }
        public int SewingLineId { get; set; }
        public double InputQuantity { get; set; }
        public string ChallanNo { get; set; }
        public string IssueID { get; set; }
        public string ManualCuttingNo { get; set; }
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
        public string CountryName { get; set; }
        [NotMapped]
        public string SewingCompanyName { get; set; }

        [NotMapped]
        public string BuyerName { get; set; }
        
        [NotMapped]
        public string LocationName { get; set; }
        
    }
}
