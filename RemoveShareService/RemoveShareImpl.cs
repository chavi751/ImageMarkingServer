using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace RemoveShareService
{
    [Register(Policy.Transient, typeof(IRemoveShareService))]
    public class RemoveShareImpl : IRemoveShareService
    {
        IMarkingDAL _dal;
        public RemoveShareImpl(IMarkingDAL dal)
        {
            _dal = dal;

        }
        public Response RemoveShare(RemoveShareRequest request)
        {
            try
            {
                RemoveShareResponse retval = new RemoveShareIsNotExist(request);
                var ds = _dal.RemoveShare(request.DocId, request.UserId);
                var index = 0;
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                        if ((string)ds.Tables[0].Rows[0][1] == request.UserId)
                        
                            {
                               
                                retval = new RemoveShareResponseOK();
                                retval.Share = new Share();
                                retval.Share.DocId = (string)tbl.Rows[index][0];
                                retval.Share.UserId = (string)tbl.Rows[index][1];
                                
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
