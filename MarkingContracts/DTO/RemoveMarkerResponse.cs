using DIContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class RemoveMarkerResponse : Response
    {
        public string MarkerId { get; set; }
    }
}
