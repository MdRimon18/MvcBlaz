using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class ShareholderShareDetails
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string NoOfShare { get; set; }
        public string FaceValue { get; set; }
        public string Premium { get; set; }
        public string ShareValue { get; set; }
        public int ShareholderId { get; set; }
    }
}
