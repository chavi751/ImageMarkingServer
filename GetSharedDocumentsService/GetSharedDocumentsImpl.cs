using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace GetSharedDocumentsService
{
    [Register(Policy.Transient, typeof(IGetSharedDocumentsService))]
    public class GetSharedDocumentsImpl : IGetSharedDocumentsService
    {
        IMarkingDAL _dal;
        public GetSharedDocumentsImpl(IMarkingDAL dal)
        {
            _dal = dal;
        }
        public Response GetSharedDocuments(GetSharedDocumentsRequest request)
        {
            try
            {
                var ds = _dal.GetSharedDocuments(request.userId);
                GetSharedDocumentsResponse retval = new GetSharedDocumentsNoSharings(request);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                                   
                                                     
                            retval = new GetSharedDocumentsResponseOK();

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
