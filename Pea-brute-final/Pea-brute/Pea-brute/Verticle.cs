using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea_brute
{
    public class Vertex
    {
        public Vertex()
        {
            this.neighbours = new List<Edge>();
        }
        public short index { get; set; }
        public List<Edge> neighbours { get; set; }
    }
}
