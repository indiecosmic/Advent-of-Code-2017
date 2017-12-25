using System;
using System.Linq;
using AdventOfCode.Day20;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day20 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 20");
            var input = GetInput();
            var rows = input.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Part 1");
            var particles = rows.Select(Particle.Parse).ToList();
            for (var count = 0; count < 300; count++)
            {
                foreach (var particle in particles)
                {
                    particle.Update();
                }
            }

            var minDistance = particles.Min(p => p.Distance(Vector.Zero));
            var nearest = particles.First(p => p.Distance(Vector.Zero) == minDistance);
            var index = 0;
            for (var i = 0; i < particles.Count; i++)
            {
                if (particles[i].Equals(nearest))
                    index = i;
            }
            Console.WriteLine($"{index}: p={nearest.Position}, v={nearest.Velocity}, a={nearest.Acceleration}");

            Console.WriteLine("Part 2");
            particles = rows.Select(Particle.Parse).ToList();
            for (var count = 0; count < 50; count++)
            {
                foreach (var particle in particles)
                {
                    particle.Update();
                }
                foreach (var particle in particles)
                {
                    if (particles.Count(p => p.Position.Equals(particle.Position)) > 1)
                        particle.Destroyed = true;
                }
                var destroyedParticles = particles.Where(p => p.Destroyed).ToArray();
                foreach (var destroyedParticle in destroyedParticles)
                {
                    particles.Remove(destroyedParticle);
                }
            }
            Console.WriteLine($"Count: {particles.Count}");
        }
    }
}
