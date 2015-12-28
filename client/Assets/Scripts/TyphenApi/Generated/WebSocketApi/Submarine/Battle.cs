// This file was generated by typhen-api

using System;

namespace TyphenApi.WebSocketApi.Parts.Submarine
{
    public partial class Battle : TyphenApi.IWebSocketApi
    {
        public enum MessageType
        {
            Ping = -973977363,
        }

        readonly IWebSocketSession session;

        public event Action<TyphenApi.Type.Submarine.Battle.PingObject> OnPingReceive;


        public Battle(IWebSocketSession session)
        {
            this.session = session;

        }

        public void SendPing(TyphenApi.Type.Submarine.Battle.PingObject ping)
        {
            session.Send((int)MessageType.Ping, ping);
        }

        public void SendPing(string message)
        {
            session.Send((int)MessageType.Ping, new TyphenApi.Type.Submarine.Battle.PingObject()
            {
                Message = message,
            });
        }

        public TyphenApi.TypeBase DispatchMessageEvent(int messageType, byte[] messageData)
        {
            switch ((MessageType)messageType)
            {
                case MessageType.Ping:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.PingObject>(messageData);

                    if (OnPingReceive != null)
                    {
                        OnPingReceive(message);
                    }

                    return message;
                }
            }


            return null;
        }
    }
}