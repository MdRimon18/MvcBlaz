using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class ServiceBookingForAOPWithoutOrderDetails
    {
        public int Id { get; set; }
        public int ServiceBookingForAOPWithoutOrderId { get; set; }
        public string FabricSource { get; set; }
        public int FabricDescriptionId { get; set; }
        public string AOPGSM { get; set; }
        public string AOPDia { get; set; }
        public int UOMId { get; set; }
        public string ArtworkNo { get; set; }
        public string GmtsColor { get; set; }
        public double WOQnty { get; set; }
        public double AopRate { get; set; }
        public double Amount { get; set; }
        public string DeliveryStartDate { get; set; }
        public string DeliveryEndDate { get; set; }
        public string Remarks { get; set; }
        public string PrintingColor { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
