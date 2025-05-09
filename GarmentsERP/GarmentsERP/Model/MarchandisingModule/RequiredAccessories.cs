using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class RequiredAccessories
    {
        public int Id { get; set; }
        public string SampleName { get; set; }
        public int GarmentsItemId { get; set; }
        public int TrimsGroupId { get; set; }
        public int SupplierProfileId { get; set; }
        public string BrandOrSuppRef { get; set; }
        public string Description { get; set; }
        public int SampleFabricBookingid { get; set; }
        public int OrderId { get; set; }
        public int SampleRequisitionId { get; set; }
        public int Uom { get; set; }
        public string ReqDzn { get; set; }
        public double ReqQty { get; set; }
        public string AccDelDate { get; set; }
        public string AccSource { get; set; }
        public string Remarks { get; set; }
        public string Image { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
