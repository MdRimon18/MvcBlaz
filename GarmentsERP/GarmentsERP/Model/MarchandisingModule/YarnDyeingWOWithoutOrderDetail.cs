using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class YarnDyeingWOWithoutOrderDetail
    {
        public int Id { get; set; }
        public int YarnDyeingWOWithoutOrderMasterId { get; set; }
        public string SampleDevelopId { get; set; }
        public string SampleName { get; set; }
        public string LotNo { get; set; }
        public int YarnCountId { get; set; }
        public string YarnDescription { get; set; }
        public string YarnColor { get; set; }
        public int ColorRangeId { get; set; }
        public string RefNo { get; set; }
        public int UomId { get; set; }
        public double YarnWoQnty { get; set; }
        public double DyeingCharge { get; set; }
        public double Amount { get; set; }
        public int NoofBag { get; set; }
        public int NoofCone { get; set; }
        public int MinReqCone { get; set; }
        public string Remarks { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
