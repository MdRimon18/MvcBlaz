using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Import
{
    public class BTBOrMarginLCAmendmentRecord
    {
        public int Id { get; set; }
        public string AmendmentNo { get; set; }
        public string AmendmentDate { get; set; }
        public string PiNo { get; set; }
        public string PiValue { get; set; }
        public double AmendmentValue { get; set; }
        public string ValueChangedBy { get; set; }
        public string LastShipDate { get; set; }
        public string ExpiryDate { get; set; }
        public int DeliveryModeId { get; set; }
        public string IncoTerm { get; set; }
        public string IncoTermPlace { get; set; }
        public string PartialShipment { get; set; }
        public string PortofLoading { get; set; }
    public string PortofDischarge { get; set; }
    public string PayTerm { get; set; }
    public string Tenor { get; set; }
    public string Remarks { get; set; }
    public int CurrentRecordMasterId { get; set; }


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
