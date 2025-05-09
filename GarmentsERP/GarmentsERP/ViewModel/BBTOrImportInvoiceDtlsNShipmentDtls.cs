using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.ViewModel
{
    public class BBTOrImportInvoiceDtlsNShipmentDtls
    {
        public int Id { get; set; }
        public string LCNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string DocumentValue { get; set; }
        public double LCValue { get; set; }
        public double ExchangeRate { get; set; }

        //child Part
        public string BLOrCargoNo { get; set; }
        public string BLOrCargoDate { get; set; }
        public int    ShipmentMode { get; set; }
        public string DocumentStatus { get; set; }
        public string CopyDocReceiveDate { get; set; }
        public string OriginalDocReceiveDate { get; set; }
        public string DocumenttoCAndF { get; set; }
    }
}
