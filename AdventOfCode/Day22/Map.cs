using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day22
{
    public class Map
    {
        private readonly Dictionary<(int, int), char> _map;

        public Map(Map map)
        {
            _map = map._map.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        private Map(Dictionary<(int, int), char> map)
        {
            _map = map;
        }

        public int Count => _map.Count;

        public bool IsInfected((int, int) position)
        {
            return _map.ContainsKey(position) && _map[position] == '#';
        }

        public bool IsInfected(int x, int y)
        {
            return IsInfected((x, y));
        }

        public void Infect(int x, int y)
        {
            var pos = (x, y);
            Infect(pos);
        }

        public void Infect((int, int) pos)
        {
            _map[pos] = '#';
        }

        public void Clean(int x, int y)
        {
            var pos = (x, y);
            Clean(pos);
        }

        internal void Clean((int, int) position)
        {
            _map[position] = '.';
        }

        public static Map Parse(string input)
        {
            var rows = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var map = new Dictionary<(int, int), char>();
            var offset = rows.Length / 2;
            for (var row = 0; row < rows.Length; row++)
            {
                for (var col = 0; col < rows[row].Length; col++)
                {
                    var x = col - offset;
                    var y = -(row - offset);
                    map[(x, y)] = rows[row][col];
                }
            }
            return new Map(map);
        }

        public override string ToString()
        {
            var minX = _map.Keys.Min(k => k.Item1);
            var maxX = _map.Keys.Max(k => k.Item1);
            var minY = _map.Keys.Min(k => k.Item2);
            var maxY = _map.Keys.Max(k => k.Item2);
            
            var str = new StringBuilder();
            for (var row = maxY; row >= minY; row--)
            {
                for (var col = minX; col <= maxX; col++)
                {
                    var pos = (col, row);
                    var isInfected = IsInfected(pos);
                    str.Append(isInfected ? "# " : ". ");
                }
                str.AppendLine();
            }
            return str.ToString();
        }
    }
}
