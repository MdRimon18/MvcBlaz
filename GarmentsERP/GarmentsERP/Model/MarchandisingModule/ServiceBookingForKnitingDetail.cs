using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class ServiceBookingForKnitingDetail
    {
        public int Id { get; set; }
        public int ServiceBookingForKnitingId { get; set; }
        public int ProcessId { get; set; }
        public string Sensitivity { get; set; }
        public string ProgramNo { get; set; }
        public int FabricDescriptionId { get; set; }
        public string Dia { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
