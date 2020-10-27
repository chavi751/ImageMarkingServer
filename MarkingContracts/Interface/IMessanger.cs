using MarkingContracts.DTO;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace MarkingContracts.Interface
{
    public interface IMessanger
    {
        Task Send(string id, string message);
        IReceiver AddOrRemove(string id,WebSocket socket, string data,string type);

        


    }
}
