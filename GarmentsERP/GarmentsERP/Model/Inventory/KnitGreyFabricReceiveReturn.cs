using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class KnitGreyFabricReceiveReturn
    {
        public int Id { get; set; }
        public string ReturnNumber { get; set; }
        public int CompanyId { get; set; }
        public string ReturnDate { get; set; }
        public string ReceivedID { get; set; }
        public string ReturnedTo { get; set; }
        public string PiNO { get; set; }


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
