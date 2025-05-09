using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class RequiredFabric
    {
        public int Id { get; set; }
        public int SampleFabricBookingId { get; set; }
        public int OrderId { get; set; }
        public int SampleRequisitionId { get; set; }
        public string SampleName { get; set; }
        public int GarmentItemId { get; set; }
        public int BodyPartId { get; set; }
        public int FabricNature { get; set; }
        public int FabricDescriptionId { get; set; }
        public double GSM { get; set; }
        public string Dia { get; set; }
        public int ColorId { get; set; }
        public int ColorTypeId { get; set; }
        public string WidthDia { get; set; }
        public int UomId { get; set; }
        public double FinishReqQty { get; set; }
        public double ProcessLoss { get; set; }
        public double GreyReqQty { get; set; }
        public string FabricDelDate { get; set; }
        public string FabricSource { get; set; }
        public string Image { get; set; }
        public string Remarks { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
