using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class BuyerInspection
    {
        public int Id { get; set; }
        public string WeekNo { get; set; }
        public int CountryId { get; set; }
        public double PoQty { get; set; }
        public string ShipDate { get; set; }
        public double FinishingQty { get; set; }
        public double InspecQty { get; set; }
        public double CumlInspQty { get; set; }
        public string InspecStatus { get; set; }
        public string Cause { get; set; }
        public string JobNo { get; set; }
        public int OrderAutoId { get; set; }
        public string InspectedBy { get; set; }
        public int InpCompany { get; set; }
        public string InpDate { get; set; }
        public string Comments { get; set; }
        public int OrderNo { get; set; }


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
