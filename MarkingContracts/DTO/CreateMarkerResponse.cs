using DIContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MarkingContracts.DTO
{
    public class CreateMarkerResponse : Response
    {
        public Marker Marker { get; set; }
    }
}
