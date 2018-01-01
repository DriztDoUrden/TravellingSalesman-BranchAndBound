using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea_brute
{
    public class BruteForce
    {
        public Graph graph { get; set; }

        public double minimumDistance { get; private set; }
        private int counter;
        private double distance;
        private string path;
        private double current_distance;

        Vertex startVertex;
        List<Vertex> shortestPath;
        Stack<Vertex> verticesStack;

        public BruteForce(string patch, int _current_distance)
        {
            verticesStack = new Stack<Vertex>();
            shortestPath = new List<Vertex>();
            minimumDistance = 0;
            counter = 0;
            distance = 0;
            path = patch;
            current_distance = _current_distance;
        }
        public BruteForce(int _current_distance)
        {
            verticesStack = new Stack<Vertex>();
            shortestPath = new List<Vertex>();
            minimumDistance = 0;
            counter = 0;
            distance = 0;
            current_distance = _current_distance;
        }

        public List<Vertex> ShortestHamiltonCycle()
        {
            startVertex = graph.verticles[0];
            BruteFRecurring(startVertex);
            return shortestPath;
        }

        void BruteFRecurring(Vertex vertex)
        {
            counter++; // ilosc wierzcholkow na stosie
            verticesStack.Push(vertex); // wrzucamy wierzcholek na stos
            if (distance < current_distance)
            {
                foreach (Edge edge in vertex.neighbours)
                {
                    if (edge.verticle2 == startVertex) // sprawdzenie czy sciezka sie domknie
                    {
                        if (counter == graph.verticles.Count) // czy mamy wszystkie wierzcholki na stosie
                        {
                            verticesStack.Push(edge.verticle2);
                            distance += edge.distance; // dodanie wartosci powrotu do wierzcholka startowego
                            if(distance<=current_distance)
                            {
                                if (minimumDistance == 0 || distance < minimumDistance) // jezeli jest lepsza od dotychczasowej
                                {
                                    shortestPath.Clear();
                                    shortestPath.AddRange(verticesStack);
                                    minimumDistance = distance;
                                    current_distance = distance;
                                    Console.WriteLine(current_distance);
                                }
                            }
                            distance -= edge.distance;
                            verticesStack.Pop();
                        }
                    }
                    if (!verticesStack.Contains(edge.verticle2)) // sprawdzenie czy wierzcholek sie nie powtarza
                    {
                        distance += edge.distance;
                        BruteFRecurring(edge.verticle2);
                        distance -= edge.distance;
                    }
                }
            }
            verticesStack.Pop();
            counter--;
        }
    }
}
