// This file was generated by typhen-api

using System;
using System.Collections.Generic;

namespace TyphenApi.WebSocketApi.Parts.Submarine
{
    public partial class Battle : TyphenApi.IWebSocketApi
    {
        public enum MessageType
        {
            Ping = -1287020902,
            Room = -1286955548,
            Now = -1565539188,
            Start = -1240750730,
            Finish = -162791524,
            Actor = -1257891252,
            Visibility = -1278494184,
            Movement = 1298310360,
            Destruction = -1118469016,
            StartRequest = 504335322,
            AccelerationRequest = -710337400,
            BrakeRequest = 1492486768,
            TurnRequest = 698416554,
            PingerRequest = 110864488,
            TorpedoRequest = 1327463172,
            AddBotRequest = 1859155646,
            RemoveBotRequest = -1928553516,
        }

        readonly IWebSocketSession session;

        public event Action<TyphenApi.Type.Submarine.Battle.PingObject> OnPingReceive;
        public event Action<TyphenApi.Type.Submarine.Room> OnRoomReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.NowObject> OnNowReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.Start> OnStartReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.Finish> OnFinishReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.Actor> OnActorReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.Visibility> OnVisibilityReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.Movement> OnMovementReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.Destruction> OnDestructionReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.StartRequestObject> OnStartRequestReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.AccelerationRequestObject> OnAccelerationRequestReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.BrakeRequestObject> OnBrakeRequestReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.TurnRequestObject> OnTurnRequestReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.PingerRequestObject> OnPingerRequestReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.TorpedoRequestObject> OnTorpedoRequestReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.AddBotRequestObject> OnAddBotRequestReceive;
        public event Action<TyphenApi.Type.Submarine.Battle.RemoveBotRequestObject> OnRemoveBotRequestReceive;


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
        public void SendRoom(TyphenApi.Type.Submarine.Room room)
        {
            session.Send((int)MessageType.Room, room);
        }

        public void SendRoom(long id, List<TyphenApi.Type.Submarine.User> members, List<TyphenApi.Type.Submarine.Bot> bots)
        {
            session.Send((int)MessageType.Room, new TyphenApi.Type.Submarine.Room()
            {
                Id = id,
                Members = members,
                Bots = bots,
            });
        }
        public void SendNow(TyphenApi.Type.Submarine.Battle.NowObject now)
        {
            session.Send((int)MessageType.Now, now);
        }

        public void SendNow(long time)
        {
            session.Send((int)MessageType.Now, new TyphenApi.Type.Submarine.Battle.NowObject()
            {
                Time = time,
            });
        }
        public void SendStart(TyphenApi.Type.Submarine.Battle.Start start)
        {
            session.Send((int)MessageType.Start, start);
        }

        public void SendStart(long startedAt)
        {
            session.Send((int)MessageType.Start, new TyphenApi.Type.Submarine.Battle.Start()
            {
                StartedAt = startedAt,
            });
        }
        public void SendFinish(TyphenApi.Type.Submarine.Battle.Finish finish)
        {
            session.Send((int)MessageType.Finish, finish);
        }

        public void SendFinish(long winnerUserId, long finishedAt)
        {
            session.Send((int)MessageType.Finish, new TyphenApi.Type.Submarine.Battle.Finish()
            {
                WinnerUserId = winnerUserId,
                FinishedAt = finishedAt,
            });
        }
        public void SendActor(TyphenApi.Type.Submarine.Battle.Actor actor)
        {
            session.Send((int)MessageType.Actor, actor);
        }

        public void SendActor(long id, long userId, TyphenApi.Type.Submarine.Battle.ActorType type, TyphenApi.Type.Submarine.Battle.Movement movement, bool isVisible)
        {
            session.Send((int)MessageType.Actor, new TyphenApi.Type.Submarine.Battle.Actor()
            {
                Id = id,
                UserId = userId,
                Type = type,
                Movement = movement,
                IsVisible = isVisible,
            });
        }
        public void SendVisibility(TyphenApi.Type.Submarine.Battle.Visibility visibility)
        {
            session.Send((int)MessageType.Visibility, visibility);
        }

        public void SendVisibility(long actorId, bool isVisible, TyphenApi.Type.Submarine.Battle.Movement movement)
        {
            session.Send((int)MessageType.Visibility, new TyphenApi.Type.Submarine.Battle.Visibility()
            {
                ActorId = actorId,
                IsVisible = isVisible,
                Movement = movement,
            });
        }
        public void SendMovement(TyphenApi.Type.Submarine.Battle.Movement movement)
        {
            session.Send((int)MessageType.Movement, movement);
        }

        public void SendMovement(long actorId, TyphenApi.Type.Submarine.Battle.Point position, double direction, long movedAt, TyphenApi.Type.Submarine.Battle.Accelerator accelerator)
        {
            session.Send((int)MessageType.Movement, new TyphenApi.Type.Submarine.Battle.Movement()
            {
                ActorId = actorId,
                Position = position,
                Direction = direction,
                MovedAt = movedAt,
                Accelerator = accelerator,
            });
        }
        public void SendDestruction(TyphenApi.Type.Submarine.Battle.Destruction destruction)
        {
            session.Send((int)MessageType.Destruction, destruction);
        }

        public void SendDestruction(long actorId)
        {
            session.Send((int)MessageType.Destruction, new TyphenApi.Type.Submarine.Battle.Destruction()
            {
                ActorId = actorId,
            });
        }
        public void SendStartRequest(TyphenApi.Type.Submarine.Battle.StartRequestObject startRequest)
        {
            session.Send((int)MessageType.StartRequest, startRequest);
        }

        public void SendStartRequest()
        {
            session.Send((int)MessageType.StartRequest, new TyphenApi.Type.Submarine.Battle.StartRequestObject()
            {
            });
        }
        public void SendAccelerationRequest(TyphenApi.Type.Submarine.Battle.AccelerationRequestObject accelerationRequest)
        {
            session.Send((int)MessageType.AccelerationRequest, accelerationRequest);
        }

        public void SendAccelerationRequest(double direction)
        {
            session.Send((int)MessageType.AccelerationRequest, new TyphenApi.Type.Submarine.Battle.AccelerationRequestObject()
            {
                Direction = direction,
            });
        }
        public void SendBrakeRequest(TyphenApi.Type.Submarine.Battle.BrakeRequestObject brakeRequest)
        {
            session.Send((int)MessageType.BrakeRequest, brakeRequest);
        }

        public void SendBrakeRequest(double direction)
        {
            session.Send((int)MessageType.BrakeRequest, new TyphenApi.Type.Submarine.Battle.BrakeRequestObject()
            {
                Direction = direction,
            });
        }
        public void SendTurnRequest(TyphenApi.Type.Submarine.Battle.TurnRequestObject turnRequest)
        {
            session.Send((int)MessageType.TurnRequest, turnRequest);
        }

        public void SendTurnRequest(double direction)
        {
            session.Send((int)MessageType.TurnRequest, new TyphenApi.Type.Submarine.Battle.TurnRequestObject()
            {
                Direction = direction,
            });
        }
        public void SendPingerRequest(TyphenApi.Type.Submarine.Battle.PingerRequestObject pingerRequest)
        {
            session.Send((int)MessageType.PingerRequest, pingerRequest);
        }

        public void SendPingerRequest()
        {
            session.Send((int)MessageType.PingerRequest, new TyphenApi.Type.Submarine.Battle.PingerRequestObject()
            {
            });
        }
        public void SendTorpedoRequest(TyphenApi.Type.Submarine.Battle.TorpedoRequestObject torpedoRequest)
        {
            session.Send((int)MessageType.TorpedoRequest, torpedoRequest);
        }

        public void SendTorpedoRequest()
        {
            session.Send((int)MessageType.TorpedoRequest, new TyphenApi.Type.Submarine.Battle.TorpedoRequestObject()
            {
            });
        }
        public void SendAddBotRequest(TyphenApi.Type.Submarine.Battle.AddBotRequestObject addBotRequest)
        {
            session.Send((int)MessageType.AddBotRequest, addBotRequest);
        }

        public void SendAddBotRequest()
        {
            session.Send((int)MessageType.AddBotRequest, new TyphenApi.Type.Submarine.Battle.AddBotRequestObject()
            {
            });
        }
        public void SendRemoveBotRequest(TyphenApi.Type.Submarine.Battle.RemoveBotRequestObject removeBotRequest)
        {
            session.Send((int)MessageType.RemoveBotRequest, removeBotRequest);
        }

        public void SendRemoveBotRequest(long botId)
        {
            session.Send((int)MessageType.RemoveBotRequest, new TyphenApi.Type.Submarine.Battle.RemoveBotRequestObject()
            {
                BotId = botId,
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
                case MessageType.Room:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Room>(messageData);

                    if (OnRoomReceive != null)
                    {
                        OnRoomReceive(message);
                    }

                    return message;
                }
                case MessageType.Now:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.NowObject>(messageData);

                    if (OnNowReceive != null)
                    {
                        OnNowReceive(message);
                    }

                    return message;
                }
                case MessageType.Start:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.Start>(messageData);

                    if (OnStartReceive != null)
                    {
                        OnStartReceive(message);
                    }

                    return message;
                }
                case MessageType.Finish:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.Finish>(messageData);

                    if (OnFinishReceive != null)
                    {
                        OnFinishReceive(message);
                    }

                    return message;
                }
                case MessageType.Actor:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.Actor>(messageData);

                    if (OnActorReceive != null)
                    {
                        OnActorReceive(message);
                    }

                    return message;
                }
                case MessageType.Visibility:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.Visibility>(messageData);

                    if (OnVisibilityReceive != null)
                    {
                        OnVisibilityReceive(message);
                    }

                    return message;
                }
                case MessageType.Movement:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.Movement>(messageData);

                    if (OnMovementReceive != null)
                    {
                        OnMovementReceive(message);
                    }

                    return message;
                }
                case MessageType.Destruction:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.Destruction>(messageData);

                    if (OnDestructionReceive != null)
                    {
                        OnDestructionReceive(message);
                    }

                    return message;
                }
                case MessageType.StartRequest:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.StartRequestObject>(messageData);

                    if (OnStartRequestReceive != null)
                    {
                        OnStartRequestReceive(message);
                    }

                    return message;
                }
                case MessageType.AccelerationRequest:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.AccelerationRequestObject>(messageData);

                    if (OnAccelerationRequestReceive != null)
                    {
                        OnAccelerationRequestReceive(message);
                    }

                    return message;
                }
                case MessageType.BrakeRequest:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.BrakeRequestObject>(messageData);

                    if (OnBrakeRequestReceive != null)
                    {
                        OnBrakeRequestReceive(message);
                    }

                    return message;
                }
                case MessageType.TurnRequest:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.TurnRequestObject>(messageData);

                    if (OnTurnRequestReceive != null)
                    {
                        OnTurnRequestReceive(message);
                    }

                    return message;
                }
                case MessageType.PingerRequest:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.PingerRequestObject>(messageData);

                    if (OnPingerRequestReceive != null)
                    {
                        OnPingerRequestReceive(message);
                    }

                    return message;
                }
                case MessageType.TorpedoRequest:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.TorpedoRequestObject>(messageData);

                    if (OnTorpedoRequestReceive != null)
                    {
                        OnTorpedoRequestReceive(message);
                    }

                    return message;
                }
                case MessageType.AddBotRequest:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.AddBotRequestObject>(messageData);

                    if (OnAddBotRequestReceive != null)
                    {
                        OnAddBotRequestReceive(message);
                    }

                    return message;
                }
                case MessageType.RemoveBotRequest:
                {
                    var message = session.MessageDeserializer.Deserialize<TyphenApi.Type.Submarine.Battle.RemoveBotRequestObject>(messageData);

                    if (OnRemoveBotRequestReceive != null)
                    {
                        OnRemoveBotRequestReceive(message);
                    }

                    return message;
                }
            }


            return null;
        }
    }
}
