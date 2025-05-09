using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class TrimsBookingItemDtlsChild
    {
        public int Id { get; set; }
        public int TrimsBookingMasterId { get; set; }
        public int PrecostingId { get; set; }
        public string JobNo { get; set; }
        public int OrderAutoId { get; set; }
        public int PoDeptId { get; set; }
        public int TrimCostId { get; set; }
        public string OrdNo { get; set; }
        public string TrimsGroup { get; set; }
        public string Description { get; set; }
        public string BrandSup { get; set; }
        public double ReqQnty { get; set; }
        public string Uom { get; set; }
        public double CuWOQ { get; set; }
        public double BalWOQ { get; set; }
        public string Sensitivity { get; set; }
        public double Woq { get; set; }
        public double ExchRate { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string DelvDate { get; set; }
        public string ItemColor { get; set; }
        public string mesurmentDescription { get; set; }
        public string EntryBy { get; set; }

        public string Status { get; set; }

        public string EntryDate { get; set; }
        public string JobOrPoLevel { get; set; }
        public decimal? SizeQnty { get; set; }

        public string GmtsColor { get; set; }
        public string Gmtssizes { get; set; }
        public int? GroupId { get; set; }
        public int? ConsumptionId { get; set; }
        public string RefNo { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public decimal? PerAccessories { get; set; }
        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }


    }
}
