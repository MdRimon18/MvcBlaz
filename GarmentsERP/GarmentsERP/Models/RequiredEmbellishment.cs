//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GarmentsERP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequiredEmbellishment
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
