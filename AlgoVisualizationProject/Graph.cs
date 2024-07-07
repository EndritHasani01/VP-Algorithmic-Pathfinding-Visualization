using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AlgoVisualizationProject
{
    public abstract class Graph : Control
    {
        public List<Node> Nodes { get; protected set; }
        public List<Edge> Edges { get; protected set; }
        public int idcn { get; set; }
        public int VisualSpeed = 1000;

        private GraphVisualizer _visualizer;

        private bool type; // true directed, false undirected


        public Graph(GraphVisualizer gv, bool type)
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
            _visualizer = gv;
            this.Paint += Graph_Paint;
            idcn = 1;
            this.type = type;
        }

        public Graph(List<Node> nodes, List<Edge> edges, GraphVisualizer gv,bool type)
        {
            Nodes = nodes;
            Edges = edges;
            _visualizer = gv;
            this.Paint += Graph_Paint;
            idcn = nodes.Count + 1;
            this.type = type;
        }


        public void Graph_Paint(object sender, PaintEventArgs e)
        {
            foreach (var edge in Edges)
            {
                edge.Draw(e.Graphics);
            }
            foreach (var node in Nodes)
            {
                node.Draw(e.Graphics);
            }
        }

        public void AddNode(Node node)
        {
            if (GetNodeAt(node.Location) == null) Nodes.Add(node);
        }

        public abstract void AddEdge(Edge edge);

        public void RemoveNode(Node node)
        {
            Nodes.Remove(node);
            Edges = Edges.Where(e => e.Start != node && e.End != node).ToList();
        }

        public void RemoveEdge(Edge edge)
        {
            Edges.Remove(edge);
        }

        public Node GetNodeAt(Point location)
        {
            foreach (var node in Nodes)
            {
                if (node.Contains(location))
                    return node;
            }
            return null;
        }

        public Node GetNodeWith(String id)
        {
            foreach (var node in Nodes)
            {
                if (node.ID == int.Parse(id))
                    return node;
            }
            return null;
        }


        public async Task modInvalidate()
        {
            _visualizer.Invalidate(true);
        }


        // Finding the shortest path using Dijkstra's algorithm
        public async Task<List<Node>> Dijkstra(Node startNode, Node endNode)
        {
            return await Task.Run(async () =>
            {
                var distance = new Dictionary<Node, int>();
                var previous = new Dictionary<Node, Node>();
                var unvisited = new List<Node>(Nodes);
                PriorityQueue<Node,int> pq = new PriorityQueue<Node,int>();

                foreach (var node in Nodes)
                {
                    distance[node] = int.MaxValue;
                    previous[node] = null;
                }
                distance[startNode] = 0;

                pq.Enqueue(startNode, 0);

                while (pq.Count!=0)
                {
                    var currentNode = pq.Dequeue();

                    currentNode.Selected = true;
                    await modInvalidate();
                    await Task.Delay(VisualSpeed);


                    if (currentNode == endNode)
                    {
                        return await generatePath(previous, currentNode);
                    }

                    foreach (var edge in Edges.Where(e => e.Start == currentNode))
                    {
                        var neighbor = edge.End;
                        var newDist = distance[currentNode] + edge.Weight;
                        var neighborEdgeForUni = Edges.Find(e => e.Start == neighbor && e.End == currentNode);

                        edge.Selected = true;
                        if (!type) neighborEdgeForUni.Selected = true; // it is used for the reason that at animation the entire line will look red
                        await modInvalidate();
                        await Task.Delay(VisualSpeed);
                        if (newDist < distance[neighbor])
                        {
                            distance[neighbor] = (int)newDist;
                            previous[neighbor] = currentNode;
                            pq.Enqueue(neighbor, distance[neighbor]);
                        }

                        edge.Selected = false;
                        if (!type) neighborEdgeForUni.Selected = false;
                    }

                    currentNode.Selected = false;
                }
                return new List<Node>();
            });
                
        }

        public async Task<List<Node>> BFS(Node startNode, Node endNode)
        {
            return await Task.Run(async () =>
            {
                var queue = new Queue<Node>();
                var visited = new HashSet<Node>();
                var previous = new Dictionary<Node, Node>();

                foreach (var node in Nodes)
                {
                    previous[node] = null;
                }
                queue.Enqueue(startNode);
                visited.Add(startNode);

                while (queue.Count > 0)
                {
                    var currentNode = queue.Dequeue();

                    currentNode.Selected = true;
                    await modInvalidate();
                    await Task.Delay(VisualSpeed);

                    if (currentNode == endNode)
                    {
                        return await generatePath(previous, currentNode);
                    }

                    foreach (var edge in Edges.Where(e => e.Start == currentNode))
                    {
                        var neighbor = edge.End;
                        var neighborEdgeForUni = Edges.Find(e => e.Start == neighbor && e.End == currentNode);

                        edge.Selected = true;
                        if (!type) neighborEdgeForUni.Selected = true;
                        await modInvalidate();
                        await Task.Delay(VisualSpeed);
                        if (!visited.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            visited.Add(neighbor);
                            previous[neighbor] = currentNode;
                        }
                        currentNode.Selected = true;
                        edge.Selected = false;
                        if (!type) neighborEdgeForUni.Selected = false;
                    }

                    currentNode.Selected = false;
                }

                return new List<Node>(); // Return an empty list if no path is found
            });
        }

        public void dehiglight_Graph()
        {
            foreach (var edge in Edges)
            {
                edge.Selected = false;
            }

            foreach(var node in Nodes)
            {
                node.Selected = false;
            }
        }

        public async Task<List<Node>> generatePath(Dictionary<Node, Node> previous, Node currentNode)
        {

            var path = new List<Node>();
            while (currentNode != null)
            {
                path.Add(currentNode);
                currentNode.Selected = true;
                await Task.Delay(500);
                await modInvalidate();
                if (previous.ContainsKey(currentNode))
                {
                    if(previous[currentNode] != null)
                    {
                        if (Edges.Any(e => e.Start == previous[currentNode] && e.End == currentNode)) Edges.Find(e => e.Start == previous[currentNode] && e.End == currentNode).Selected = true;
                        if (!type)
                        {
                            if (Edges.Any(e => e.Start == currentNode && e.End == previous[currentNode])) Edges.Find(e => e.Start == currentNode && e.End == previous[currentNode]).Selected = true;
                        }
                    }
                    currentNode = previous[currentNode];

                }


            }
   
            path.Reverse();
            return path;
        }

        public async Task<List<Node>> DFS(Node startNode, Node endNode)
        {
            return await Task.Run(async () =>
            {
                var stack = new Stack<Node>();
                var visited = new HashSet<Node>();
                var previous = new Dictionary<Node, Node>();

                foreach (var node in Nodes)
                {
                    previous[node] = null;
                }

                stack.Push(startNode);

                while (stack.Count > 0)
                {
                    var currentNode = stack.Pop();

                    if (!visited.Add(currentNode)) // If currentNode is already visited, skip it
                        continue;

                    currentNode.Selected = true;
                    await modInvalidate();
                    await Task.Delay(VisualSpeed);

                    if (currentNode == endNode)
                    {
                        return await generatePath(previous,currentNode);
                    }

                    foreach (var edge in Edges.Where(e => e.Start == currentNode))
                    {
                        var neighbor = edge.End;
                        var neighborEdgeForUni = Edges.Find(e => e.Start == neighbor && e.End == currentNode);


                        edge.Selected = true;
                        if (!type) neighborEdgeForUni.Selected = true;
                        await modInvalidate();
                        await Task.Delay(VisualSpeed);
                        if (!visited.Contains(neighbor))
                        {
                            stack.Push(neighbor);
                            previous[neighbor] = currentNode;
                        }

                        edge.Selected = false;
                        if (!type) neighborEdgeForUni.Selected = false;
                    }

                    currentNode.Selected = false;
                }

                return new List<Node>(); // Return an empty list if no path is found
            });
        }
    }

    public class UndirectedGraph : Graph
    {
        public UndirectedGraph(GraphVisualizer gv,bool type) : base(gv,type)
        { 

        }

        public UndirectedGraph(List<Node> nodes, List<Edge> edges, GraphVisualizer gv, bool type) : base(nodes,edges,gv,type)
        {

        }

        public override void AddEdge(Edge edge)
        {
            Edges = Edges.Where(e => !((e.Start == edge.Start && e.End == edge.End) || (e.End == edge.Start && e.Start == edge.End))).ToList();
            edge.IsDirected = false;
            Edges.Add(edge);
            Edges.Add(new Edge(edge.End,edge.Start,edge.Weight));
        }
    }

    public class DirectedGraph : Graph
    {
        public DirectedGraph(GraphVisualizer gv, bool type) : base(gv, type)
        {

        }

        public DirectedGraph(List<Node> nodes, List<Edge> edges, GraphVisualizer gv, bool type) : base(nodes,edges,gv, type)
        {

        }

        public override void AddEdge(Edge edge)
        {
            Edges = Edges.Where(e => !(e.Start == edge.Start && e.End == edge.End)).ToList();
            edge.IsDirected = true;
            Edges.Add(edge);
        }

    }

}

