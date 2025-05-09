using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class ConversionCostForPreCost
    {
        [Key]
    public  int Id {get;set;}
      public int PrecostingId { get; set; }
      public  int FabricDescriptionId {get;set;}
        public int? FabricCostId { get; set; }
        public  int PoNo {get;set;}
    public  int ProcessId {get;set;}
    public  double  ProcessLoss {get;set;}
       public double? FabricCons { get; set; }
        public  double  ReqQty {get;set;}
    public  double  AvgReqQty {get;set;}
    public  double  ChargeUnit {get;set;}
    public  double  Amount {get;set;}
    public  string  Status {get;set;}
    }
}
