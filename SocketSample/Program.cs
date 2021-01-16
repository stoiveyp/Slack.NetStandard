using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Socket;
using Slack.NetStandard;
using Slack.NetStandard.Interaction;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;
using static System.Threading.Channels.Channel;

namespace SocketSample
{
    class Program
    {
        private static string apptoken = "xapp-1-A01JMB95JNS-1664023245712-f2c0dd33fdb4d3faf8199c0bf3563f4768502d66f99be3df19f64a744c4480f5";

        static async Task Main(string[] args)
        {
            var webapi = new SlackWebApiClient(apptoken);
            var url = await webapi.Apps.OpenConnection();
            using var client = new ClientWebSocket();
            var cancel = new CancellationTokenSource();
            while (Reconnect)
            {
                await client.ConnectAsync(new Uri(url.Url, UriKind.Absolute), cancel.Token);

                var send = Send(client, cancel.Token);
                var receive = Receive(client, cancel);
                var readKey = ReadKey(cancel);
                var process = ProcessMessages(client, cancel);

                try
                {
                    await Task.WhenAll(readKey, send, receive, process);
                }
                finally
                {
                    if (client.State == WebSocketState.Open)
                    {
                        await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "App shutting down", default);
                    }
                }
            }
        }

        private static Task ReadKey(CancellationTokenSource cancel)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Press ESC to quit");
                ConsoleKeyInfo cki = new ConsoleKeyInfo();
                do
                {
                    // true hides the pressed character from the console
                    cki = Console.ReadKey(true);

                    // Wait for an ESC
                } while (cki.Key != ConsoleKey.Escape);

                Reconnect = false;
                cancel.Cancel();
            },cancel.Token);
        }

        private static bool Reconnect = true;

        private static async Task Receive(ClientWebSocket client, CancellationTokenSource cancel)
        {
            var osb = new StringBuilder();
            var memory = new Memory<byte>(new byte[2048]);
            var sentHello = false;
            while (!cancel.IsCancellationRequested)
            {
                var messageEnd = false;
                while (!messageEnd)
                {
                    var result = await client.ReceiveAsync(memory, cancel.Token);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        cancel.Cancel();
                        Reconnect = false;
                    }

                    Console.WriteLine("Received text");
                    osb.Append(Encoding.UTF8.GetString(memory.Span));
                    messageEnd = result.EndOfMessage;
                }

                Console.WriteLine("adding to messages channel");
                await Messages.Writer.WriteAsync(osb.ToString(), cancel.Token);
                osb.Clear();

            }
        }

        private static readonly Channel<string> Messages = CreateUnbounded<string>();
        private static readonly Channel<Acknowledge> Acknowledgement = Channel.CreateUnbounded<Acknowledge>();

        private static async Task ProcessMessages(ClientWebSocket client, CancellationTokenSource cancel)
        {
            while (!cancel.IsCancellationRequested)
            {
                await Messages.Reader.WaitToReadAsync(cancel.Token);
                if (cancel.IsCancellationRequested)
                {
                    return;
                }

                Console.WriteLine("reading message off channel");
                var msg = await Messages.Reader.ReadAsync(cancel.Token);
                if (msg != null)
                {
                    if(!msg.Contains("envelope_id"))
                    {
                        var jo = JObject.Parse(msg);
                        var objectType = jo.Value<string>("type");
                        if (objectType == Hello.EventType)
                        {
                            Console.WriteLine("saying hi");
                            await SendMessage(client, "hello");
                        }
                        else if (objectType == Disconnect.EventType)
                        {
                            Console.WriteLine("reconnecting");
                            Reconnect = true;
                            cancel.Cancel();
                        }
                    }

                    else
                    {
                        var env = JsonConvert.DeserializeObject<Envelope>(msg);
                        Console.WriteLine("processing envelope " + env.EnvelopeId);
                        if (env.Payload is SlashCommand)
                        {
                            await Acknowledgement.Writer.WriteAsync(new Acknowledge
                            {
                                EnvelopeId = env.EnvelopeId,
                                Payload = new Message
                                {
                                    Blocks = new List<IMessageBlock>
                                    {
                                        new Section("This is from a socket....shh!")
                                    }
                                }
                            });
                        }
                    }
                }
            }
        }

        private static async Task Send(ClientWebSocket client, CancellationToken cancel)
        {
            while (!cancel.IsCancellationRequested)
            {
                await Acknowledgement.Reader.WaitToReadAsync(cancel);
                var ack = await Acknowledgement.Reader.ReadAsync(cancel);
                if (ack != null)
                {
                    Console.WriteLine("sending ack " + ack.EnvelopeId);
                    await SendMessage(client, JsonConvert.SerializeObject(ack));
                }
            }
        }

        private static Task SendMessage(ClientWebSocket client, string text)
        {
            return client.SendAsync(
                Encoding.UTF8.GetBytes(text),
                WebSocketMessageType.Text, true, default);
        }
    }
}
