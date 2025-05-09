using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class ExportInformationDetails
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string JobNo { get; set; }
        public int JobNoId { get; set; }
        public int OrderId { get; set; }
        public int ExportInformationId { get; set; }
        public string StyleRef { get; set; }
        public string ArticleNo { get; set; }
        public string ShipmentDate { get; set; }
        public double AttachedOrderQnty { get; set; }
        public string Uom { get; set; }
        public double Rate { get; set; }
        public double CurrInvoiceQnty { get; set; }
        public double CurrInvoiceValue { get; set; }
        public double CumuInvoiceQnty { get; set; }
        public double PoBalanceQnty { get; set; }
        public double CumuInvoiceValue { get; set; }
        public double ExFactoryQnty { get; set; }
        public string Merchandiser { get; set; }
        public string ProductionSource { get; set; }
        public string Brand { get; set; }


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
