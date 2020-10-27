using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace RemoveMarkerService
{
    [Register(Policy.Transient, typeof(IRemoveMarkerService))]
    public class RemoveMarkerImpl : IRemoveMarkerService
    {
        IMarkingDAL _dal;
        IMessanger _messanger;
        public RemoveMarkerImpl(IMarkingDAL dal, IMessanger messanger)
        {
            _dal = dal;
            _messanger = messanger;

        }
                 
        public Response RemoveMarker(RemoveMarkerRequest request)
        {
            try
            {
                RemoveMarkerResponse retval = new RemoveMarkerIsNotExist(request);
                var ds = _dal.GetMarker(request.MarkerId);
                if (ds.Tables.Count > 0)
                {
                    ds = _dal.RemoveMarker(request.MarkerId);
                    if (ds.Tables.Count > 0)
                    {
                        var tbl = ds.Tables[0];
                        if (tbl.Rows.Count == 1)
                        {
                            if ((string)tbl.Rows[0][1] == request.MarkerId)
                            {
                                retval = new RemoveMarkerResponseOK();
                                retval.MarkerId = request.MarkerId;
                                _messanger.Send((string)tbl.Rows[0][0], "MarkerRemoved/" + request.MarkerId);
                                
                            }

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
