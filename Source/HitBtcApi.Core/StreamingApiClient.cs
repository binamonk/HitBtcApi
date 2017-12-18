using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HitBtcApi.Core
{
    public class StreamingApiClient
    {
        public StreamingApiClient() {
        }

        public async Task<bool> StartAsync() {
            var socket = new ClientWebSocket();
            var uri = new Uri("ws://api.hitbtc.com:80");
            var cancellationToken = new CancellationToken();
            await socket.ConnectAsync(uri, cancellationToken);
            var buffer = new byte[1048576];
            while (true)
            {
                var segment = new ArraySegment<byte>(buffer);
                var result = await socket.ReceiveAsync(segment, CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close) {
                    await socket.CloseAsync(WebSocketCloseStatus.InvalidMessageType, "I don't do binary", CancellationToken.None);
                }
                int count = result.Count;
                while (!result.EndOfMessage && result.Count != 0)
                {
                    //if (count <= buffer.Length) {
                    //    await socket.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None);
                    //}

                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = await socket.ReceiveAsync(segment, CancellationToken.None);
                    count += result.Count;
                }
                var message = Encoding.UTF8.GetString(buffer, 0, count);
                try
                {
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonEnvelopes.MarketDataEnvelope>(message);

                    if (obj.MarketDataIncrementalRefresh != null)
                    {
                        if (obj.MarketDataIncrementalRefresh.symbol == "BTCUSD")
                        {
                            System.Diagnostics.Debug.Write($"> {message}\r\n");
                        }

                        //System.Diagnostics.Debug.Write($"> {obj.MarketDataIncrementalRefresh.symbol}\r\n");
                    }
                    else if (obj.MarketDataSnapshotFullRefresh != null) {
                        if (obj.MarketDataSnapshotFullRefresh.symbol == "BTCUSD")
                        {
                            System.Diagnostics.Debug.Write($"> {message}\r\n");
                        }
                        //System.Diagnostics.Debug.Write($">");
                    }
                }
                catch (Newtonsoft.Json.JsonSerializationException jex)
                {
                    System.Diagnostics.Debug.WriteLine(jex.Message);
                }
                catch (Newtonsoft.Json.JsonReaderException jrex) {
                    System.Diagnostics.Debug.WriteLine(jrex.Message);
                }
                //System.Diagnostics.Debug.Write($"> {message}\r\n");
            }
            return true;
        }
    }
}
