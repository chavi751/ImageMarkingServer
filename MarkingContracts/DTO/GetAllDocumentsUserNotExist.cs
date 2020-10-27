using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class GetAllDocumentsUserNotExist : GetAllDocumentsResponse
    {
        public GetAllDocumentsRequest Request { get; set; }
        public GetAllDocumentsUserNotExist(GetAllDocumentsRequest request)
        {
            Request = request;
        }
    }
}
