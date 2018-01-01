using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea_brute
{
    public static class GraphMethods
    {
        public static Graph RandGraph(int size, int minDisctance, int maxDistance)
        {
            Graph graph = new Graph();
            Random rand = new Random();

            for (short i = 0; i < size; i++)
            {
                Vertex vertex = new Vertex();
                vertex.index = i;
                graph.verticles.Add(vertex);
            }

            for (short i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    Edge edge = new Edge();
                    edge.distance = rand.Next(minDisctance, maxDistance);
                    edge.verticle1 = graph.verticles[i];
                    edge.verticle2 = graph.verticles[j];

                      graph.verticles[i].neighbours.Add(edge);

                    Edge edge2 = new Edge();
                    edge2.distance = edge.distance;
                    edge2.verticle1 = graph.verticles[j];
                    edge2.verticle2 = graph.verticles[i];

                    graph.verticles[j].neighbours.Add(edge2);

                    graph.egdes.Add(edge);
                    graph.egdes.Add(edge2);
                }
            }

            return graph;
        }
        public static int LoadSize(string path)
        {
            string patch = @"D:\PEA\Pea-brute-final\Pea-brute\Pea-brute\Cities\" + path;
            StreamReader sr = new StreamReader(patch + ".txt");
            int size = Int32.Parse(sr.ReadLine());
            return size;
        }
        public static Graph CreateGraph(int size, string path)
        {
            Graph graph = new Graph();

            string patch = @"D:\PEA\Pea-brute-final\Pea-brute\Pea-brute\Cities\" + path;
            StreamReader sr = new StreamReader(patch + ".txt");
            size = Int32.Parse(sr.ReadLine());
            string text;
            string[] bits;


            for (short i = 0; i < size; i++)
            {
                Vertex vertex = new Vertex();
                vertex.index = i;
                graph.verticles.Add(vertex);
            }

            for (short i = 0; i < size; i++)
            {
                text = sr.ReadLine();
                bits = text.Split(' ');

                for (short j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        
                    }
                    else if (int.Parse(bits[j]) == 0)
                    {
                        
                    }
                    else
                    {
                        Edge edge = new Edge();
                        edge.distance = short.Parse(bits[j]);
                        edge.verticle1 = graph.verticles[i];
                        edge.verticle2 = graph.verticles[j];

                        graph.verticles[i].neighbours.Add(edge);

                        graph.egdes.Add(edge);
                    }

                }
            }

            return graph;
        }
        public static int NearestNeighbour(Graph graph, int size)
        {
            var ProhibVertex = new Stack<Vertex>(); // lista zakazanych wierzcholkow
            var startVertex = graph.verticles[0];
            int distance = 0;
            int min = 999999;
            var NextVertex = startVertex;
            var TempVertex = new Vertex();
            int level = 1;
            var Tabu = new Vertex();  // zakazany wierzcholek
            while (level < size)
            {
                foreach (Edge edge in NextVertex.neighbours)
                {
                    if (edge.distance < min && (ProhibVertex.Contains(edge.verticle2)==false))
                    {
                        min = edge.distance;
                        TempVertex = edge.verticle2;
                        Tabu = edge.verticle1;
                    }
                }
                distance += min;
                NextVertex = TempVertex;
                ProhibVertex.Push(Tabu);
                level++;
                min = 9999;
            }
            distance += NextVertex.neighbours[0].distance;
                return distance;
        }

    }
}
