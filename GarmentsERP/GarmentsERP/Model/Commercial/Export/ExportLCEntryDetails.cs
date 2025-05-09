using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class ExportLCEntryDetails
    {
      
        
            public int Id { get; set; }
            public int ExportLCMasterId { get; set; }
            public int PoId { get; set; }
            public int JobNoId { get; set; }                       
            public int SalesContractMasterId { get; set; }                       
            public string OrderNumber { get; set; }
            public string AccPONo { get; set; }
            public double OrderQty { get; set; }
            public double OrderValue { get; set; }
            public double AttachedQty { get; set; }
            public int? Uom { get; set; }
            public double Rate { get; set; }
            public double AttachedValue { get; set; }
            public string StyleRef { get; set; }
            public int GmtsItem { get; set; }
            public string JobNo { get; set; }
            public string FabricDescription { get; set; }
            public double Categroy { get; set; }
            public string HsCode { get; set; }


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
