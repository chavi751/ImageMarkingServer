using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class GetSharesResponseNoShares: GetSharesResponse
    {
        public GetSharesRequest Request { get; set; }
        public GetSharesResponseNoShares(GetSharesRequest request)
        {
            Request = request;
        }
    }
}
