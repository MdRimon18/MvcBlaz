using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class ServiceBookingForKnitingandDyeingWithoutOrderDetails
    {
        public int Id { get; set; }
        public int ServiceBookingMasterId { get; set; }
        public string FabricSource { get; set; }
        public int FabricDescription { get; set; }
        public string GSM { get; set; }
        public string Dia { get; set; }
        public int UOM { get; set; }
        public string ArtworkNo { get; set; }
        public string GmtsColor { get; set; }
        public double WOQty { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string DeliveryStartDate { get; set; }
        public string DeliveryEndDate { get; set; }
        public string Remarks { get; set; }
        public int Process { get; set; }
        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
