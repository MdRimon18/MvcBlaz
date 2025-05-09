using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class YarnCountDetermination
    {
        public int Id { get; set; }
        public string FabricNature { get; set; }
        public string Construction { get; set; }
        public string ColorRange { get; set; }
        public double GSM { get; set; }
        public string Status { get; set; }
        public double StitchLength { get; set; }
        public double ProcessLoss { get; set; }
        public double SequenceNo { get; set; }
       


        [NotMapped]
        public List<YarnCountDeterminationChild> YarnCountDeterminationChildList { get; set; }
    }
   
}
