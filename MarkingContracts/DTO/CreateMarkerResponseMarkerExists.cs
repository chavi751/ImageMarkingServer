using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class CreateMarkerResponseMarkerExists : CreateMarkerResponse
    {
        public CreateMarkerRequest Request { get; set; }
        public CreateMarkerResponseMarkerExists(CreateMarkerRequest request)
        {
            Request = request;
        }
    }
}
