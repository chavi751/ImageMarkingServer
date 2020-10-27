using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace UpdateMarkerService
{
    [Register(Policy.Transient, typeof(IUpdateMarkerService))]
    public class UpdateMarkerImpl : IUpdateMarkerService
    {
        IMarkingDAL _dal;
        IMessanger _messanger;
        public UpdateMarkerImpl(IMarkingDAL dal, IMessanger messanger)
        {
            _dal = dal;
            _messanger = messanger;
        }
        public Response UpdateMarker(UpdateMarkerRequest request)
        {
            try
            {
                var ds = _dal.UpdateMarker(request.markerId,request.foreColor,request.backColor);
                UpdateMarkerResponse retval = new UpdateMarkerResponseMarkerIdNotExists(request);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        if (request.markerId == (string)tbl.Rows[0][1])
                        {
                            retval = new UpdateMarkerResponseOK();
                            retval.Marker = new Marker();
                            retval.Marker.DocId = (string)tbl.Rows[0][0];
                            retval.Marker.MarkerId = (string)tbl.Rows[0][1];
                            retval.Marker.MarkerType = (string)tbl.Rows[0][2];
                            retval.Marker.CenterX = (decimal)tbl.Rows[0][5];
                            retval.Marker.CenterY = (decimal)tbl.Rows[0][6];
                            retval.Marker.RadiusX = (decimal)tbl.Rows[0][3];
                            retval.Marker.RadiusY = (decimal)tbl.Rows[0][4];
                            retval.Marker.UserId = (string)tbl.Rows[0][9];
                            retval.Marker.BackColor = (string)tbl.Rows[0][8];
                            retval.Marker.ForeColor = (string)tbl.Rows[0][7];
                            _messanger.Send(retval.Marker.DocId, "MarkerUpdated/" + retval.Marker.MarkerId);
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
