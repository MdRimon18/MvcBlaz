using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class ReturnItem
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string ItemDescription { get; set; }
        public double NoOfBag { get; set; }
        public double NoOfCone { get; set; }
        public string Store { get; set; }
        public double ReturnedQnty { get; set; }
        public double InvRecvQnty { get; set; }
        public int Uom { get; set; }
        public double Rate { get; set; }
        public double ReturnValue { get; set; }


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
