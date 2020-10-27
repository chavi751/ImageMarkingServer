
using DIContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class SignInResponse:Response
    {
        public string emailAddress { get; set; }
        public string UserName { get; set; }
    }
}
