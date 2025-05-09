using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class RequiredEmbellishment
    {
        public int Id { get; set; }
        public int SampleFabricBookingId { get; set; }
        public int OrderId { get; set; }
        public int SampleRequisitionId { get; set; }
        public string SampleName { get; set; }
        public int GarmentItemId { get; set; }
        public string EmbellishmentName { get; set; }
        public int EmbellishmentTypeListId { get; set; }
        public int BodyPartEntrieId { get; set; }
        public int SupplierProfileId { get; set; }
        public string Remarks { get; set; }
        public string DeliveryDate { get; set; }
        public string Image { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
