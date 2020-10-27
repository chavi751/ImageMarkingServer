using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class GetSharedDocumentsNoSharings : GetSharedDocumentsResponse
    {
        public GetSharedDocumentsRequest Request { get; set; }
        public GetSharedDocumentsNoSharings(GetSharedDocumentsRequest request)
        {
            Request = request;
        }
    }
}
