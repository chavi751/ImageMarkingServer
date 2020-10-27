
using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Conection
{
    [Register(Policy.Singelton, typeof(IMessanger))]
    public class Messanger:IMessanger
    {
        Dictionary<string, WebSocket> _sockets;
        Dictionary<string, List<string>> _documents;
        Dictionary<string, Receiver> _receivers;
     
        public Messanger()
        {
            _sockets = new Dictionary<string, WebSocket>();
            _documents = new Dictionary<string, List<string>>();
     
        }
        public async Task Send(string docId, string message)
        {
         
                var buffer = Encoding.UTF8.GetBytes(message);
                _documents[docId].ForEach(async (userId) =>
                    {
                        if (_sockets.ContainsKey(userId))
                        {

                            await _sockets[userId].SendAsync(new ReadOnlyMemory<byte>(buffer), WebSocketMessageType.Text
                                , true
                               , CancellationToken.None);
                        }
                    });
            }
       
        public IReceiver AddOrRemove(string id, WebSocket socket, string docId,string type)
        {
            Receiver retval = new Receiver();
            if (type == "connect")
            {
                if (!_sockets.ContainsKey(id))
                {

                    _sockets.Add(id, socket);
                    retval = new Receiver(socket);
                    if (_documents.ContainsKey(docId))
                    {
                        _documents[docId].Add(id);
                        _documents[docId].ForEach(async (userId) =>
                        {
                            var socket = _sockets[userId];
                            await Send(docId, "UserConnected/" + userId);
                        });
                    }
                    else
                    {
                        _documents.Add(docId, new List<string>());
                    }
                }
                if (_documents[docId].Find(s => s == id) == null)
                    _documents[docId].Add(id);
            }
            else
            {
                _documents[docId].Remove(id);
                _sockets.Remove(id);
                Send(docId, "UserDisconnected/" + id);

            }
           
            
            return retval;
            


           
        }

       
    }
}
