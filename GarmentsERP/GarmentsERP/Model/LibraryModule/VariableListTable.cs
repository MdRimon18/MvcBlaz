using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.LibraryModule
{
    public class VariableListTable
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ModuleId { get; set; }
        public string VariableName { get; set; }
    }
}
