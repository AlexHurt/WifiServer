using System;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;
using WifiServer.Models;

namespace WifiServer
{
    public class WifiHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequestHandler);
            }
        }

        public async Task WebSocketRequestHandler(AspNetWebSocketContext webSocketContext)
        {
            var webSocket = webSocketContext.WebSocket;
            const int maxMessageSize = 4096;
            var receivedDataBuffer = new ArraySegment<byte>(new byte[maxMessageSize]);
            var cancellationToken = new CancellationToken();

            while (webSocket.State == WebSocketState.Open)
            {
                var webSocketReceiveResult = await webSocket.ReceiveAsync(receivedDataBuffer, cancellationToken);
                if (webSocketReceiveResult.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,
                        String.Empty, cancellationToken);
                }
                else
                {
                    var payloadData = (receivedDataBuffer.Array ?? throw new InvalidOperationException()).Where(b => b != 0).ToArray();
                    var receiveString = System.Text.Encoding.UTF8.GetString(payloadData, 0, payloadData.Length);
                    //Write to db
                }
            }
        }
        public bool IsReusable => false;
    }
}