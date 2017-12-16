using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day12
{
    public class PipeSystem
    {
        private readonly Program[] _pipes;

        private PipeSystem(Program[] pipes)
        {
            _pipes = pipes;
        }

        public static PipeSystem Parse(string input)
        {
            var pipes = new List<Program>();
            var regex = new Regex(@"(?<id>\d+) <-> (?<connectedTo>\d+(?:, \d+)*)", RegexOptions.Multiline);
            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                var id = Convert.ToInt32(match.Groups["id"].Value);
                var connectedTo = match.Groups["connectedTo"].Value.Split(new []{',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                pipes.Add(new Program(id, connectedTo.Select(c => Convert.ToInt32(c)).ToArray()));
            }

            return new PipeSystem(pipes.ToArray());
        }

        public int[] FindProgramsInGroup(int group)
        {
            var list = new List<int>();
            FindPrograms(_pipes[group], list);
            return list.ToArray();
        }

        public int FindTotalNumberOfGroups()
        {
            var count = 0;
            var visitedPrograms = new List<int>();
            for (var i = 0; i < _pipes.Length; i++)
            {
                if (!visitedPrograms.Contains(i))
                {
                    var group = new List<int>();
                    FindPrograms(_pipes[i], group);
                    visitedPrograms.AddRange(group);
                    count++;
                }
            }
            return count;
        }

        private void FindPrograms(Program pipe, List<int> history)
        {
            if (history.Contains(pipe.Id))
                return;
            history.Add(pipe.Id);
            foreach (var p in pipe.ConnectedTo)
            {
                FindPrograms(_pipes[p], history);
            }
        }

        public class Program
        {
            public int Id { get; }
            public List<int> ConnectedTo { get; }

            public Program(int id, int[] connectedTo)
            {
                Id = id;
                ConnectedTo = new List<int>(connectedTo);
            }


        }
    }
}
