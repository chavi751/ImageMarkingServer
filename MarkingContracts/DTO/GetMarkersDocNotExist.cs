using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class GetMarkersDocNotExist : GetMarkersResponse
    {
        public GetMarkersRequest Request { get; set; }
        public GetMarkersDocNotExist(GetMarkersRequest request)
        {
            Request = request;
        }
    }
}
