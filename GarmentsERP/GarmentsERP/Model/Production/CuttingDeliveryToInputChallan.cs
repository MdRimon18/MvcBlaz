using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Production
{
    public class CuttingDeliveryToInputChallan
    {
        public int Id { get; set; }
        public string SysChallanNo { get; set; }
        public int LocationId { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryBasis { get; set; }
        public string ChallanNo { get; set; }
        public string CuttingSource { get; set; }
        public int CuttingCompanyId { get; set; }
        public int CutCompanyLocation { get; set; }
        public string BundleNo { get; set; }
        public double DeliveryQnt { get; set; }
        public double TotalBundleQnty { get; set; }
        public string Remarks { get; set; }


        public string Status { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }

        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }

        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }


        [NotMapped]
        public string CuttCompanyName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string CuttCompanyLocation{ get; set; }
    }
}
