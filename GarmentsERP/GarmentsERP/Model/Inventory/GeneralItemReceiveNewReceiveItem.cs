using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class GeneralItemReceiveNewReceiveItem
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string StoreName { get; set; }
        public double RtnQnty { get; set; }
        public string SerialNo { get; set; }
        public int ItemCategory { get; set; }
        public double Rate { get; set; }
        public string MrRStock { get; set; }
        public int ItemGroup { get; set; }
        public double RtnValue { get; set; }
        public string GlobalStock { get; set; }
        public string ItemDesc { get; set; }
        public int ConsUOM { get; set; }
        public string Remark { get; set; }


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
