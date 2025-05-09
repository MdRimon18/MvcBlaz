using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.LibraryModule
{
    public class AccountInfo
    {
        public int Id { get; set; }
        public int BankInfoId { get; set; }
        public int AccountTypeId { get; set; }
        public string AccountNo { get; set; }
        public int CurrencyId { get; set; }
        public int LoanLimit { get; set; }
        public string LimitType { get; set; }
        public int CompanyId { get; set; }
        public string ChartOfAccount { get; set; }
        public string Status { get; set; }
    }
}
