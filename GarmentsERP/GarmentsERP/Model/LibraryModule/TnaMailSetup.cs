using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.LibraryModule
{
    public class TnaMailSetup
    {
        public int Id { get; set; }
        public int User { get; set; }
        public string TNATask { get; set; }
        public string MailType { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
