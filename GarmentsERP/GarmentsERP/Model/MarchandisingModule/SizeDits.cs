using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.MarchandisingModule
{
    public class SizeDits
    {

        public int Id { get; set; }
        public string Size { get; set; }
        public int GmtsPcs { get; set; }
        public int BhQty { get; set; }
       

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string Status { get; set; }
    }
}
