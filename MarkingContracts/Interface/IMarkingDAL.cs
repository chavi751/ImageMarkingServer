using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MarkingContracts.Interface
{
    public interface IMarkingDAL
    {
        DataSet CreateUser(string id, string userName);
        //DataSet Login(string userName);

        public DataSet GetUser(string id, string userName);
        DataSet RemoveUser(string userId);
        DataSet GetDocument(string docId);
        DataSet GetDocuments(string userId);
        DataSet UpdateDocument(string docId,string documentName, string imageUrl);
        DataSet CreateDocument(string UserId, string ImageUrl, string DocumentName);
        DataSet RemoveDocument(string DocId);
        DataSet GetMarkers(string DocId);
        DataSet GetMarker(string MarkerId);
        DataSet CreateMarker(string DocId, string MarkerType, decimal RadiusX,
            decimal RadiusY, decimal CenterX, decimal CenterY, string ForeColor,
            string BackColor, string UserId);
        DataSet RemoveMarker(string MarkerId);
        DataSet UpdateMarker(string markerId,string foreColor, string backColor);
        DataSet CreateShare(string DocId, string UserId);
        DataSet RemoveShare(string DocId, string UserId);
        DataSet GetSharedDocuments(string userId);
        DataSet GetSharedDocument(string docId);

    }
}
