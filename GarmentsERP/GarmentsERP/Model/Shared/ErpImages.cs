using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Shared
{
    public class ErpImages
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public int PageSpecificationId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
    }
}
