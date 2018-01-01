using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea_brute
{

    class Program
    {
        public static void Main(string[] args)
        {

            var graph = new Graph();

            string path = "15cities";
            int Size = GraphMethods.LoadSize(path);
            graph = GraphMethods.CreateGraph(Size, path);
            int current_distance = GraphMethods.NearestNeighbour(graph, Size);
            var problem = new BruteForce(path, current_distance);

            problem.graph = graph;
            var startTime = DateTime.Now;
            Console.WriteLine("Branch and Bound Method");
            Console.WriteLine(current_distance);
            foreach (var v in problem.ShortestHamiltonCycle())
            {
                Console.Write(v.index + " ");
            }
            DateTime stopTime = DateTime.Now;
            var roznica = stopTime - startTime;
            Console.WriteLine();
            Console.WriteLine("Distance: " + problem.minimumDistance);
            Console.WriteLine();
            Console.WriteLine("Time: " + (roznica.TotalMilliseconds)/1000);
            Console.Read();
        }

    }
}
