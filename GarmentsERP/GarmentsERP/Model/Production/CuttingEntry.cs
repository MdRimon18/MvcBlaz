using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class CuttingEntry
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public int CountryId { get; set; }
        public int BuyerId { get; set; }
        public string Style { get; set; }
        public int ItemId { get; set; }
        public double OrderQnty { get; set; }
        public double PlanCutQnty { get; set; }
        public string Source { get; set; }
        public int CuttCompany { get; set; }
        public int Location { get; set; }
        public int Floor { get; set; }
        public string WorkOrder { get; set; }
        public string ProducedBy { get; set; }
        public string ColorType { get; set; }
        public double CuttingQuantity { get; set; }
        public double RejectQnty { get; set; }
        public double ReportingHour { get; set; }
        public string ChallanNo { get; set; }
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
        public string CuttCompanyName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string BuyerName { get; set; }
        [NotMapped]
        public string OrderName { get; set; }
        [NotMapped]
        public string ItemName { get; set; }
    }
}
