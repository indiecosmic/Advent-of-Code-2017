using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day09
{
    public class StreamProcessor
    {
        public Group FindGroups(string input)
        {
            Group root = null, currentGroup = null;
            var garbage = false;
            var cancel = false;
            foreach (var c in input)
            {
                if (c == '{' && !garbage && !cancel)
                {
                    if (currentGroup == null)
                    {
                        currentGroup = new Group(1);
                        root = currentGroup;
                    }
                    else
                    {
                        var newGroup = new Group(currentGroup.Score + 1);
                        currentGroup.Children.Add(newGroup);
                        newGroup.Parent = currentGroup;
                        currentGroup = newGroup;
                    }
                }
                else if (c == '}' && !garbage && !cancel)
                {
                    currentGroup = currentGroup?.Parent;
                }
                else if (c == '<' && !garbage && !cancel)
                {
                    garbage = true;
                }
                else if (c == '>' && garbage && !cancel)
                {
                    garbage = false;
                }
                else if (c == '!' && !cancel)
                {
                    cancel = true;
                }
                else
                {
                    cancel = false;
                }
            }

            return root;
        }

        public int CountCharactersInsideGarbage(string input)
        {
            var garbage = false;
            var cancel = false;
            var count = 0;
            foreach (char c in input)
            {
                if (c == '<' && !garbage && !cancel)
                {
                    garbage = true;
                }
                else if (c == '>' && garbage && !cancel)
                {
                    garbage = false;
                }
                else if (c == '!' && !cancel)
                {
                    cancel = true;
                }
                else if (garbage && !cancel)
                {
                    count++;
                }
                else
                {
                    cancel = false;
                }
            }

            return count;
        }
    }

    public class Group
    {
        public int Score { get; }
        public IList<Group> Children { get; }
        public Group Parent { get; set; }

        public Group(int score)
        {
            Score = score;
            Children = new List<Group>();
        }

        public int GetCount()
        {
            if (!Children.Any())
                return 1;
            var count = 0;
            foreach (var child in Children)
            {
                count += child.GetCount();
            }
            return count + 1;
        }

        public int GetScore()
        {
            if (!Children.Any())
                return Score;
            var childScore = 0;
            foreach (var child in Children)
            {
                childScore += child.GetScore();
            }
            return childScore + Score;
        }
    }
}
