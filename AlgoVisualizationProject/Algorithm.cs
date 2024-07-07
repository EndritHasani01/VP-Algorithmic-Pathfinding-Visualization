using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVisualizationProject
{
    public interface Algorithm
    {
        public Task<List<Node>> Execute(Graph graph, Node startNode, Node endNode);
    }

}
