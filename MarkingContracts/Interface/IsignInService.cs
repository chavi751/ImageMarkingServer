using DIContract;
using MarkingContracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.Interface
{
    public interface IsignInService
    {
        Response SignIn(SignInRequest request);
    }
}
