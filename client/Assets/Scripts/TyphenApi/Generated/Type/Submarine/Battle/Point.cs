// This file was generated by typhen-api

using System.Collections.Generic;

namespace TyphenApi.Type.Submarine.Battle
{
    public partial class Point : TyphenApi.TypeBase<Point>
    {
        protected static readonly SerializationInfo<Point, double> x = new SerializationInfo<Point, double>("x", false, (x) => x.X, (x, v) => x.X = v);
        public double X { get; set; }
        protected static readonly SerializationInfo<Point, double> y = new SerializationInfo<Point, double>("y", false, (x) => x.Y, (x, v) => x.Y = v);
        public double Y { get; set; }
    }
}
