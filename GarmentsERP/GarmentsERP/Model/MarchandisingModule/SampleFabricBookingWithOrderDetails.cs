using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class SampleFabricBookingWithOrderDetails
    {
        public int Id { get; set; }
        public int SampleFabricBookingId { get; set; }
        public int FabricDescriptionId { get; set; }
        public string GarmentsColor { get; set; }
        public string FabricColor { get; set; }
        public string Garmentssize { get; set; }
        public string Itemsize { get; set; }
        public string DiaOrWidth { get; set; }
        public double FinishFabric { get; set; }
        public double Processloss { get; set; }
        public double GrayFabric { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double RmgQty { get; set; }
        public string Departments { get; set; }
        public string Responsibleperson { get; set; }
        public string Reason { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
