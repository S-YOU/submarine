// This file was generated by typhen-api

using System.Collections.Generic;

namespace TyphenApi.Type.Submarine
{
    public partial class Bot : TyphenApi.TypeBase<Bot>
    {
        protected static readonly SerializationInfo<Bot, long> id = new SerializationInfo<Bot, long>("id", false, (x) => x.Id, (x, v) => x.Id = v);
        public long Id { get; set; }
        protected static readonly SerializationInfo<Bot, string> name = new SerializationInfo<Bot, string>("name", false, (x) => x.Name, (x, v) => x.Name = v);
        public string Name { get; set; }
    }
}
