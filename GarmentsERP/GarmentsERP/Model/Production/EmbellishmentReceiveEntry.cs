using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class EmbellishmentReceiveEntry
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int CountryId { get; set; }
        public int BuyerId { get; set; }
        public string Style { get; set; }
        public int ItemId { get; set; }
        public double OrderQnty { get; set; }
        public string EmbelName { get; set; }
        public int EmbelTypeId { get; set; }
        public string Source { get; set; }
        public int EmbelCompanyId { get; set; }
        public int LocationId { get; set; }
        public int FloorId { get; set; }
        public string WorkOrder { get; set; }
        public int ReceivingLocationId { get; set; }
        public string ReceiveDate { get; set; }
        public int ColorTypeId { get; set; }
        public double ReceiveQnty { get; set; }
        public double RejectQnty { get; set; }
        public string ChallanNo { get; set; }
        public string SysChln { get; set; }
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
        public string RecievingLocationName { get; set; }
    }
}
