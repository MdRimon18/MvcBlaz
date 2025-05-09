using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.LibraryModule
{
    public class VariableSettingsTable
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ModuleId { get; set; }
        public int CountPageInputField { get; set; }
        public int VariableListId { get; set; }
        public string LabelOne { get; set; }
        public string ValueOne { get; set; }
        public string LabelTwo { get; set; }
        public string ValueTwo { get; set; }
        public string LabelThree { get; set; }
        public string ValueThree { get; set; }
        public string LabelFour { get; set; }
        public string ValueFour { get; set; }
        public string LabelFive { get; set; }
        public string ValueFive { get; set; }
        public string LabelSix { get; set; }
        public string ValueSix { get; set; }
        public string LabelSeven { get; set; }
        public string ValueSeven { get; set; }
    }
}
