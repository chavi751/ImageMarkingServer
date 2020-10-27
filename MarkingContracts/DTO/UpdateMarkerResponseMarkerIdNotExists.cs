using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class UpdateMarkerResponseMarkerIdNotExists : UpdateMarkerResponse
    {
        public UpdateMarkerRequest Request { get; set; }
        public UpdateMarkerResponseMarkerIdNotExists(UpdateMarkerRequest request)
        {
            Request = request;
        }
    }
}
