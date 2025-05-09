using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{

    public class SampleFabricBookingWithoutorderDetails
    {
        public int Id { get; set; }
        public int SfbWithoutOrderId { get; set; }
        public int BuyerProfileId { get; set; }
        public string StypeRef { get; set; }
        public string StyleDes { get; set; }
        public string Sampletype { get; set; }
        public int BodyPartEntryId { get; set; }
        public string ColorType { get; set; }
        public int FabricDescriptionId { get; set; }
        public string Gsm { get; set; }
        public string GmtsColor { get; set; }
        public string FabricColor { get; set; }
        public string GmtsSize { get; set; }
        public string Itemsize { get; set; }
        public string DiaWidth { get; set; }
        public double FinishFabric { get; set; }
        public double Processloss { get; set; }
        public string GrayFabric { get; set; }
        public string ArticleNumber { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public int BodyPartTypeId { get; set; }
        public double ItemQty { get; set; }
        public string YarnDetails { get; set; }
        public string FabricSource { get; set; }
        public string KnittingChargeKG { get; set; }
        public double BhQty { get; set; }
        public double RhQty { get; set; }
        public string DeliveryDate { get; set; }
        public string Remarks { get; set; }
        public string Uom { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }


}
