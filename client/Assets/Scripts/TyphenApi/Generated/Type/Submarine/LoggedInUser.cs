// This file was generated by typhen-api

using System.Collections.Generic;

namespace TyphenApi.Type.Submarine
{
    public partial class LoggedInUser : TyphenApi.Type.Submarine.User
    {
        protected static readonly SerializationInfo<LoggedInUser, TyphenApi.Type.Submarine.JoinedRoom> joinedRoom = new SerializationInfo<LoggedInUser, TyphenApi.Type.Submarine.JoinedRoom>("joined_room", true, (x) => x.JoinedRoom, (x, v) => x.JoinedRoom = v);
        public TyphenApi.Type.Submarine.JoinedRoom JoinedRoom { get; set; }
    }
}
