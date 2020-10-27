using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
   public class RemoveUserIsNotExist:RemoveUserResponse
    {
        public RemoveUserRequest Request { get; set; }
        public RemoveUserIsNotExist(RemoveUserRequest request)
        {
            Request = request;
        }
    }
}
