using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea_brute
{
    public class Edge
    {
        public Edge()
        {
            this.verticle1 = new Vertex();
            this.verticle2 = new Vertex();
        }
        public int distance { get; set; }
        public Vertex verticle1 { get; set; }
        public Vertex verticle2 { get; set; }
    }
}
