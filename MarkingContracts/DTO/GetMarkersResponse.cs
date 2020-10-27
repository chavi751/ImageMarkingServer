using DIContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class GetMarkersResponse : Response
    {
        public Marker[] Markers { get; set; }
    }
}
