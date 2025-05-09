using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Import
{
    public class YarnBagStickerChild
    {
        public int Id { get; set; }
        public string Lot { get; set; }
        public int Count { get; set; }
        public int Composition { get; set; }
        public double Percentage { get; set; }
        public string YarnType { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public double NoofBag { get; set; }
        public double WgtOrCone { get; set; }
        public double ConeOrBag { get; set; }
        public double BagWgt { get; set; }
        public double RateOrPerUnit { get; set; }
        public int YarnBagStickerMasterId { get; set; }


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
