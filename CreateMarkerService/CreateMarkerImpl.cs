using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using Oracle.ManagedDataAccess.Client;
using System;

namespace CreateMarkerService
{
    [Register(Policy.Transient, typeof(ICreateMarkerService))]
    public class CreateMarkerImpl : ICreateMarkerService
    {
        IMarkingDAL _dal;
        IMessanger _messanger;
        public CreateMarkerImpl(IMarkingDAL dal,IMessanger messanger)
        {
            _dal = dal;
            _messanger = messanger;
        }
        public Response CreateMarker(CreateMarkerRequest request)
        {
            try
            {
                var ds = _dal.CreateMarker(request.DocId, request.MarkerType, request.RadiusX,
                                           request.RadiusY, request.CenterX, request.CenterY, request.ForeColor, request.BackColor,
                                           request.UserId);
                CreateMarkerResponse retval = new CreateMarkerResponseMarkerExists(request);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        if (request.DocId == (string)tbl.Rows[0][0])
                        {
                            retval = new CreateMarkerResponseOK();
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
                            _messanger.Send(request.DocId, "MarkerCreated/" + request.UserId);                      }
                       
                    }
                }

                return retval;
            }
            catch (OracleException ex)
            {
                return new ResponseError(ex.Message);
            }

        }
        
    }
}
