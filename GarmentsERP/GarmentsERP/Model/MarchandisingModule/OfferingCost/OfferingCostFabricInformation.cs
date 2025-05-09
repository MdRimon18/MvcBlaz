using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule.OfferingCost
{
    public class OfferingCostFabricInformation
    {
       
            public int Id { get; set; }
            public int OfferingCostId { get; set; }
            public int OrderAutoId { get; set; }
            public string Fabrics { get; set; }
            public double GSM { get; set; }
            public double CottonPercent { get; set; }
            public double PolysterPercent { get; set; }
            public double ViscosePercent { get; set; }
            public double LaycraPercent { get; set; }
            public int OrQty { get; set; }
            public double FabQty { get; set; }
            public string YarnCount { get; set; }
            public string YarnType { get; set; }
            public double DPL { get; set; }
            public double YarnQty { get; set; }
            public double LycraQty { get; set; }
            public double AcYarn { get; set; }
            public double LycraD { get; set; }

            public string EntryDate { get; set; }
            public string EntryBy { get; set; }
            public string ApprovedDate { get; set; }
            public string ApprovedBy { get; set; }
            public bool IsApproved { get; set; }
            public string Status { get; set; }
        
    }
}
