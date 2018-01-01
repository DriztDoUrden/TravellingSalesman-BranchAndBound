using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea_brute
{
    public class Graph
    {
        public Graph()
        {
            this.verticles = new List<Vertex>();
            this.egdes = new List<Edge>();
        }
        public List<Vertex> verticles { get; set; }
        public List<Edge> egdes { get; set; }
    }
}
