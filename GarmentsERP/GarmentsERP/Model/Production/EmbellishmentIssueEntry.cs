using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class EmbellishmentIssueEntry
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int CountryId { get; set; }
        public int BuyerId { get; set; }
        public string Style { get; set; }
        public int Item { get; set; }
        public double OrderQnty { get; set; }
        public string EmbelName { get; set; }
        public int EmbelType { get; set; }
        public string Source { get; set; }
        public int EmbelCompany { get; set; }
        public int LocationId { get; set; }
        public int FloorId { get; set; }
        public int SendingLocationId { get; set; }
        public string IssueDate { get; set; }
        public int ColorTypeId { get; set; }
        public double IssueQty { get; set; }
        public string ChallanNo { get; set; }
        public string IssueId { get; set; }
        public string ManualCutNo { get; set; }
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
        public string BuyerName { get; set; }
        [NotMapped]
        public string EmbelTypeName { get; set; }
        [NotMapped]
        public string EmbelCompanyName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string SendingLocationName { get; set; }
    }
}
