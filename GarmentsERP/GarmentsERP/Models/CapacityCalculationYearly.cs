//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GarmentsERP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CapacityCalculationYearly
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int WorkingDay { get; set; }
        public double CapacityMinutes { get; set; }
        public double CapacityPcs { get; set; }
        public int CapacityCalculationId { get; set; }
        public string CapacityCalculationYear { get; set; }
        public string CapacityCalculationMonth { get; set; }
    }
}
