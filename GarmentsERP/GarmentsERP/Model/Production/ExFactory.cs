using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class ExFactory
    {
        public int Id { get; set; }
        public string Source { get; set; }      
        public string OrderNo { get; set; }
        public int CountryId { get; set; }
        public int BuyerId { get; set; }
        public string JobNo { get; set; }
        public string Style { get; set; }
        public int ItemId { get; set; }
        public double OrderQnty { get; set; }
        public int LocationId { get; set; }
        public int FloorId { get; set; }
        public string InspectionQtyValidation { get; set; }
        public string ExFactoryDate { get; set; }
        public double ExFactoryQnty { get; set; }
        public double TotalCartonQty { get; set; }
        public string InvoiceNo { get; set; }
        public string LCOrSCNo { get; set; }
        public double QntyCtn { get; set; }
        public string TransCompany { get; set; }
        public string ChallanNo { get; set; }
        public string ShippingStatus { get; set; }
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
        public string LocationName { get; set; }
    }
}
