using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Shared
{
    public class PageObjectCreatorChild
    {

        public int Id { get; set; }
        public int MasterId { get; set; }
        public int ArryIndex { get; set; }
        public string  InputName { get; set; }
        public string  DataType  { get; set; }
        public string  InputType  { get; set; }
        public string  LabelName  { get; set; }
        public string  DropdownListName  { get; set; }
        public string  IsRequired { get; set; }
        public string  DropdownServiceName { get; set; }
        public string DropdownMethodName { get; set; }
        public string DropdwnModelName { get; set; }
        public string DropdwnIdProperty { get; set; }
        public string DropdownValueProperty { get; set; }
        public string IsSearchable { get; set; }
 
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
