using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class Sampledetails
    {
        public int Id { get; set; }
        public int SampleFabricBookingid { get; set; }
        public int OrderId { get; set; }
        public int SampleRequisitionId { get; set; }
        public int GarmentItem { get; set; }
    public string SampleName { get; set; }
        public double SMV { get; set; }
        public string ArticleNo { get; set; }
    public int Color { get; set; }
    public double SampleReqQty { get; set; }
    public double SubmnQty { get; set; }
    public string DelvStartDate { get; set; }
    public string DelvEndDate { get; set; }
    public string BuyerSubDate { get; set; }
    public double ChargeUnit { get; set; }
    public int CurrencyId { get; set; }
    public string Image { get; set; }
    public string Comments { get; set; }

    public string EntryDate { get; set; }
    public string EntryBy { get; set; }
    public string ApprovedDate { get; set; }
    public string ApprovedBy { get; set; }
    public bool IsApproved { get; set; }
    public string Status { get; set; }
}
}
