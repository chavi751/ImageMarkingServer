using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class RemoveMarkerIsNotExist: RemoveMarkerResponse
    {
        public RemoveMarkerRequest Request { get; set; }
        public RemoveMarkerIsNotExist(RemoveMarkerRequest request)
        {
            Request = request;
        }
    }
}
