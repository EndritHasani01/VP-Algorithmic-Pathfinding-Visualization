using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVisualizationProject
{
    public class BFSAlgorithm : Algorithm
    {
        public async Task<List<Node>> Execute(Graph graph, Node startNode, Node endNode)
        {
            return await graph.BFS(startNode, endNode);
        }
    }
}
