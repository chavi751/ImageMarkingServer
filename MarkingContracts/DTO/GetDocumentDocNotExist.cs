using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class GetDocumentDocNotExist: GetDocumentResponse
    {
        public GetDocumentRequest Request { get; set; }
        public GetDocumentDocNotExist(GetDocumentRequest request)
        {
            Request = request;
        }
    }
}
