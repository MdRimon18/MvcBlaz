using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.PlanningModule
{
    public class SewingOperationForWorkStudy
    {
        public int Id { get; set; }
        public string ProductDept { get; set; }
        public int GarmentsItemId { get; set; }
        public int BodyPartId { get; set; }
        public string Code { get; set; }
        public string OperationName { get; set; }
        public double Rate { get; set; }
        public int FabricTypeId { get; set; }
        public string SmvBasis { get; set; }
        public double SeamLength { get; set; }
        public double MachineSMV { get; set; }
        public double ManualSMV { get; set; }
        public string DepartmentCode { get; set; }
        public int UomId { get; set; }
        public string Action { get; set; }
        public int ResourceId { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}

    
  
 
 