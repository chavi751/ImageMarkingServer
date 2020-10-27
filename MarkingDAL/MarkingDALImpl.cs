using DALContracts;
using DIContract;
using MarkingContracts.Interface;
using Oracle.ManagedDataAccess.Client;
using OracleDAL;
using System;
using System.Data;

namespace MarkingDAL
{

    [Register(Policy.Transient, typeof(IMarkingDAL))]
    public class MarkingDALImpl : IMarkingDAL
    {
        
        IDBConnection _conn;
        InfraDAL _infraDAL = new InfraDAL();
        
        

        public MarkingDALImpl()
        {
            var strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=CHAVI;Password=1234;";
            _conn = _infraDAL.Connect(strConn);
          
        }
       

            public DataSet CreateUser(string id, string userName)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("p_user", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, "CREATEUSER", _infraDAL.getParameter("p_userId", OracleDbType.Varchar2, id),
                _infraDAL.getParameter("p_userName", OracleDbType.Varchar2, userName), retval);
        }
        public DataSet GetUser(string id, string userName)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, "GETUSER", _infraDAL.getParameter("p_username", OracleDbType.Varchar2, id),
                _infraDAL.getParameter("p_userid", OracleDbType.Varchar2, userName),retval);
            
       }
        /*public DataSet Login(string userName)
        {

            var output = new OracleParameter("p_user", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.Output;
            return _infraDAL.ExecuteSPQuery(_conn, "LOGIN",
                _infraDAL.getParameter("p_userName", OracleDbType.Varchar2, userName), output);

        }
        */
        public DataSet RemoveUser(string userId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, " MARKUSERASREMOVED",
                _infraDAL.getParameter("p_userid", OracleDbType.Varchar2, userId),retval);

        }
        public DataSet GetDocument(string docId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, "GetDocument",
                _infraDAL.getParameter("p_docId", OracleDbType.Varchar2, docId), retval);
        }
        public DataSet GetDocuments(string userId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            var getDocuments =  _infraDAL.ExecuteSPQuery(_conn, "GetDocuments", 
                _infraDAL.getParameter("p_userId", OracleDbType.Varchar2, userId),retval);
            var getSharedDocuments = GetSharedDocuments(userId);
            getDocuments.Merge(getSharedDocuments);
            return getDocuments;
        } 


        public DataSet CreateDocument(string UserId,string ImageUrl,string DocumentName)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            var guid = Guid.NewGuid();
           
            return _infraDAL.ExecuteSPQuery(_conn, "CREATEDOCUMENT",
                _infraDAL.getParameter("p_docId", OracleDbType.Varchar2, guid.ToString()),
                _infraDAL.getParameter("p_documentName ", OracleDbType.Varchar2, DocumentName),
                _infraDAL.getParameter("p_imageurl", OracleDbType.Varchar2, ImageUrl),
                _infraDAL.getParameter("p_userId", OracleDbType.Varchar2, UserId),retval);
        }
        public DataSet RemoveDocument(string DocId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, "REMOVEDOCUMENT",
                _infraDAL.getParameter("p_docId", OracleDbType.Varchar2, DocId),retval);
        }

        public DataSet GetMarkers(string DocId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, "GETMARKERS",
                _infraDAL.getParameter("p_docid", OracleDbType.Varchar2, DocId),retval);

        }
        DataSet IMarkingDAL.GetMarker(string MarkerId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, "GETMARKER",
                _infraDAL.getParameter("p_markerid", OracleDbType.Varchar2, MarkerId),retval);
        }

        
        public DataSet RemoveMarker(string MarkerId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, "REMOVEMARKER",
                _infraDAL.getParameter("p_markerid", OracleDbType.Varchar2, MarkerId),retval);
        }

        public DataSet CreateShare(string DocId, string UserId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, "CREATESHARE",
                _infraDAL.getParameter("p_docId", OracleDbType.Varchar2, DocId),
                _infraDAL.getParameter("p_userId", OracleDbType.Varchar2, UserId),
                retval);

        }

        public DataSet RemoveShare(string DocId, string UserId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, "REMOVESHARE",
                _infraDAL.getParameter("p_docId", OracleDbType.Varchar2, DocId),
                 _infraDAL.getParameter("p_userId", OracleDbType.Varchar2, UserId)
                , retval);
        }

        public DataSet GetSharedDocuments(string userId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            
             return _infraDAL.ExecuteSPQuery(_conn, "GetSharedDocuments",
                _infraDAL.getParameter("p_userId", OracleDbType.Varchar2, userId), retval);
        }

        public DataSet GetSharedDocument(string docId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);

            return _infraDAL.ExecuteSPQuery(_conn, "GetShares",
               _infraDAL.getParameter("p_docId", OracleDbType.Varchar2, docId), retval);
        }

        public DataSet CreateMarker(string DocId, string MarkerType, decimal RadiusX, decimal RadiusY,
            decimal CenterX, decimal CenterY, string ForeColor, string BackColor, string UserId)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            var MarkerId = Guid.NewGuid();
            return _infraDAL.ExecuteSPQuery(_conn, "CreateMarker",
               _infraDAL.getParameter("p_docId", OracleDbType.Varchar2, DocId),
               _infraDAL.getParameter("p_markerid", OracleDbType.Varchar2, MarkerId.ToString()),
               _infraDAL.getParameter("p_markertype", OracleDbType.Varchar2, MarkerType),
               _infraDAL.getParameter("p_radiusx", OracleDbType.Decimal, RadiusX),
               _infraDAL.getParameter("p_radiusy", OracleDbType.Decimal, RadiusY),
               _infraDAL.getParameter("p_centerx", OracleDbType.Decimal, CenterX),
               _infraDAL.getParameter("p_centery", OracleDbType.Decimal, CenterY),
               _infraDAL.getParameter("p_forecolor", OracleDbType.Varchar2, ForeColor),
               _infraDAL.getParameter("p_backcolor", OracleDbType.Varchar2, BackColor),
               _infraDAL.getParameter("p_userid", OracleDbType.Varchar2, UserId)
               , retval);
        }

        public DataSet UpdateDocument(string docId, string documentName, string imageUrl)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, "UpdateDocument",
                      _infraDAL.getParameter("p_docId", OracleDbType.Varchar2, docId),
                      _infraDAL.getParameter("p_documentName", OracleDbType.Varchar2, documentName),
                      _infraDAL.getParameter("p_imageUrl", OracleDbType.Varchar2, imageUrl), retval);
        }

        public DataSet UpdateMarker(string markerId, string foreColor, string backColor)
        {
            OracleParameterAdapter retval = new OracleParameterAdapter("retval", OracleDbType.RefCursor, ParameterDirection.Output);
            return _infraDAL.ExecuteSPQuery(_conn, "UpdateMarker",
               _infraDAL.getParameter("p_markerid", OracleDbType.Varchar2, markerId),
               _infraDAL.getParameter("p_foreColor", OracleDbType.Varchar2, foreColor),
               _infraDAL.getParameter("p_backColor", OracleDbType.Varchar2, backColor), retval);
        }
    }
}
