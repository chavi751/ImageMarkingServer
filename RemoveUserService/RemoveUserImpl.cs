using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace RemoveUserService
{
    [Register(Policy.Transient, typeof(IRemoveUserService))]
    public class RemoveUserImpl : IRemoveUserService
    {
        IMarkingDAL _dal;
        public RemoveUserImpl(IMarkingDAL dal)
        {
            _dal = dal;
        }
       
       Response IRemoveUserService.RemoveUser(RemoveUserRequest request)
        {
            try
            {
                var ds = _dal.RemoveUser(request.UserId);
                RemoveUserResponse retval = new RemoveUserIsNotExist(request);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        if ( (Int16)tbl.Rows[0][2]==0)
                        {
                            retval = new RemoveUserResponseOK();
                        }

                    }
                }

                return retval;
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }

        }
    }
}

