using System;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day20
{
    public class Particle
    {
        public Vector Position { get; private set; }
        public Vector Velocity { get; private set; }
        public Vector Acceleration { get; }
        public bool Destroyed { get; set; }

        public Particle(Vector position, Vector velocity, Vector acceleration)
        {
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
        }

        public int Distance(Vector position)
        {
            return Vector.Distance(Position, position);
        }

        public void Update()
        {
            Velocity += Acceleration;
            Position += Velocity;
        }
        
        public static Particle Parse(string input)
        {
            var match = Regex.Match(input, @"^p=(?<p>\<-?\d+,-?\d+,-?\d+\>),\sv=(?<v>\<-?\d+,-?\d+,-?\d+\>),\sa=(?<a>\<-?\d+,-?\d+,-?\d+\>)$");
            var position = Vector.Parse(match.Groups["p"].Value);
            var velocity = Vector.Parse(match.Groups["v"].Value);
            var acceleration = Vector.Parse(match.Groups["a"].Value);

            return new Particle(position, velocity, acceleration);
        }
    }

    public struct Vector
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Z;

        public Vector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        private bool Equals(Vector other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z;
        }

        public override int GetHashCode()
        {
            var hash = X.GetHashCode();
            hash = ((hash << 5) + hash) ^ Y.GetHashCode();
            hash = ((hash << 5) + hash) ^ Z.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
                return false;
            return Equals((Vector)obj);
        }

        public override string ToString()
        {
            return $"<{X},{Y},{Z}>";
        }

        public static Vector Zero => new Vector(0, 0, 0);

        public static int Distance(Vector left, Vector right)
        {
            return Math.Abs(left.X - right.X) + Math.Abs(left.Y - right.Y) + Math.Abs(left.Z - right.Z);
        }

        public static Vector operator +(Vector left, Vector right)
        {
            return new Vector(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector Parse(string input)
        {
            var match = Regex.Match(input, @"<(?<x>[-]?\d+),(?<y>[-]?\d+),(?<z>[-]?\d+)>");

            return new Vector(Convert.ToInt32(match.Groups["x"].Value),Convert.ToInt32(match.Groups["y"].Value),Convert.ToInt32(match.Groups["z"].Value));
        }
    }
}
