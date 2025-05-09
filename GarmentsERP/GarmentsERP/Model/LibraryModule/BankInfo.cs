using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.LibraryModule
{
    public class BankInfo
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BankCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string SwiftCode { get; set; }
        public string WebSite { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNo { get; set; }
        public string LienBank { get; set; }
        public string IssuingBank { get; set; }
        public string SalaryBank { get; set; }
        public string AdvisingBank { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
    }
}
