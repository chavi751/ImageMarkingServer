using DIContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MarkingContracts.DTO
{
    public class SignUpResponse:Response
    {
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
    }
}
