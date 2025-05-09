using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class DocSubmissiontoBuyerDetails
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int Sl { get; set; }
        public string InvoiceNo { get; set; }
        public string LcOrSCNo { get; set; }
        public string BLNo { get; set; }
        public string InvoiceDate { get; set; }
        public double NetInvValue { get; set; }
        public string OrderNumbers { get; set; }


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
