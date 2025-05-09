using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class PartialFabricBookingItemDtlsChild
    {
        public int Id { get; set; }
        public int PreCostingId { get; set; }
        public int PoNoId { get; set; }
        public int PartialFabricBookingMasterId { get; set; }
        public int FabricCostId { get; set; }
        public int BodyPartId { get; set; }
        public int ColorTypeId { get; set; }
        public string WidthDiaType { get; set; }
        public int FabricDesPreCostId { get; set; }
        public string FabricDescription { get; set; }
        public double GsmWeight { get; set; }
        public string GmtsColor { get; set; }
        public string ItemColor { get; set; }
        public string CnsmtnEntryDia { get; set; }
        public double CnsmtnEntryProcess { get; set; }
        public double BalanceQty { get; set; }
        public double WoQnty { get; set; }
        public double AdjQnty { get; set; }
        public double AcWoQnty { get; set; }
        public string Uom { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string Remark { get; set; }
        public int fabCnsPoNoId { get; set; }
        public string fabCnsColor { get; set; }
        public string fabCnsGmtsSizes { get; set; }
        public string fabCnsItemSizes { get; set; }
        public string fabCnsDia { get; set; }
        public string RefNo { get; set; }
        public Decimal fabCnsGreyCons { get; set; }
        public Decimal fabCnsFinishCons { get; set; }
        public Decimal fabCnsTotalQty { get; set; }
        public Decimal fabCnsRate { get; set; }
        public Decimal fabCnsAmount { get; set; }
        public Decimal fabCnsTotalAmount { get; set; }
        public int? fabCnsId { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public string StyleRef { get;  set; }
        [NotMapped]
        public string JobNO { get;  set; }
        [NotMapped]
        public string PoNo { get;  set; }
        [NotMapped]
        public string BodyPartName { get;  set; }
        [NotMapped]
        public double? sizeQnty { get; set; }
        [NotMapped]
        public bool? IsSelected { get; set; }
    }
}
