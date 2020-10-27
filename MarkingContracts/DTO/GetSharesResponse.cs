using DIContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class GetSharesResponse:Response
    {
        public Share[] Shares { get; set; }
    }
}
