using DIContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class RemoveShareResponse:Response
    {
        public Share Share { get; set; }
    }
}
