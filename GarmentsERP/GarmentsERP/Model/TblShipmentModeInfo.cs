using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarmentsERP.Model
{
    public partial class TblShipmentModeInfo
    {
        [Key]
        public int ID { get; set; }
        public string Shipment_Mode { get; set; }

       
    }
}
