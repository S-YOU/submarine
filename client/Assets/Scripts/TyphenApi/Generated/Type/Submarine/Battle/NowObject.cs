// This file was generated by typhen-api

using System.Collections.Generic;

namespace TyphenApi.Type.Submarine.Battle
{
    public partial class NowObject : TyphenApi.TypeBase<NowObject>
    {
        protected static readonly SerializationInfo<NowObject, long> time = new SerializationInfo<NowObject, long>("time", false, (x) => x.Time, (x, v) => x.Time = v);
        public long Time { get; set; }
    }
}
