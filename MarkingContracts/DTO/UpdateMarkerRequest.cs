using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class UpdateMarkerRequest
    {
               
        public string markerId { get; set; }
        public string foreColor { get; set; }
        public string backColor { get; set; }
        
    }
}
