using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace GetMarkersService
{
    [Register(Policy.Transient, typeof(IGetMarkersService))]
    public class GetMarkersImpl : IGetMarkersService
    {
        IMarkingDAL _dal;
        public GetMarkersImpl(IMarkingDAL dal)
        {
            _dal = dal;
        }
        
        public Response GetMarkers(GetMarkersRequest request)
        {
        try
        {
            var ds = _dal.GetMarkers(request.DocId);
            GetMarkersResponse retval = new GetMarkersDocNotExist(request);
            if (ds.Tables.Count > 0)
            {
                var tbl = ds.Tables[0];
                if (tbl.Rows.Count >= 1)
                {
                        retval = new GetMarkersResponseOK();
                        retval.Markers = new Marker[tbl.Rows.Count];
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            if (request.DocId == (string)tbl.Rows[i][0])
                            {
                                retval.Markers[i] = new Marker();
                             
                            retval.Markers[i].DocId = (string)tbl.Rows[i][0];
                            retval.Markers[i].MarkerId= (string)tbl.Rows[i][1];
                            retval.Markers[i].MarkerType= (string)tbl.Rows[i][2];
                            retval.Markers[i].CenterX = (decimal)tbl.Rows[i][5];
                            retval.Markers[i].CenterY= (decimal)tbl.Rows[i][6];
                            retval.Markers[i].RadiusX= (decimal)tbl.Rows[i][3];
                            retval.Markers[i].RadiusY= (decimal)tbl.Rows[i][4];
                            retval.Markers[i].UserId= (string)tbl.Rows[i][9];
                            retval.Markers[i].BackColor= (string)tbl.Rows[i][8];
                            retval.Markers[i].ForeColor= (string)tbl.Rows[i][7];
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

