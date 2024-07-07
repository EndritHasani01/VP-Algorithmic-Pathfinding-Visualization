using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace AlgoVisualizationProject
{
    public class GraphVisualizer : Control
    {
        private Graph directedGraph;
        private Graph undirectedGraph;
        private Node selectedNodeD;
        private Node selectedNodeU;

        private bool isWeighted;

        private bool IsNodes;
        private bool IsEdges;
        private bool IsRemove;
        private bool IsAlgo;

        private bool graphType; // true directed, false undirected

        public int VisualSpeed;

        private Algorithm algorithm;

        public GraphVisualizer()
        {
            directedGraph = new DirectedGraph(this,true);
            undirectedGraph = new UndirectedGraph(this,false);
            this.BackColor = Color.White;
            this.Paint += directedGraph.Graph_Paint;
            IsNodes = IsEdges = IsRemove = IsAlgo = false;
            graphType = true;
            VisualSpeed = 1000;
        }

        private Graph generateSampleWeighted(bool type)
        {
            List<Node> nodes = new List<Node>
            {
                new Node(1, new Point(100, 150)),
                new Node(2, new Point(200, 50)),
                new Node(3, new Point(200, 150)),
                new Node(4, new Point(200, 250)),
                new Node(5, new Point(300, 150))
            };

            List<Edge> edges = new List<Edge>
            {
                new Edge(nodes[0], nodes[1], 9, type), // Edge 1 -> 2
                new Edge(nodes[0], nodes[2], 12, type), // Edge 1 -> 3
                new Edge(nodes[0], nodes[3], 4, type), // Edge 1 -> 4
                new Edge(nodes[1], nodes[4], 2, type), // Edge 2 -> 5
                new Edge(nodes[2], nodes[4], 5, type), // Edge 3 -> 5
                new Edge(nodes[3], nodes[4], 10, type), // Edge 4 -> 5
            };

            if (!type)
            {
                edges.Add(new Edge(nodes[1], nodes[0], 9));
                edges.Add(new Edge(nodes[2], nodes[0], 12));
                edges.Add(new Edge(nodes[3], nodes[0], 4));
                edges.Add(new Edge(nodes[4], nodes[1], 2));
                edges.Add(new Edge(nodes[4], nodes[2], 5));
                edges.Add(new Edge(nodes[4], nodes[3], 10));
            }


            if (type) return new DirectedGraph(nodes, edges, this, type);
            else return new UndirectedGraph(nodes, edges, this, type);
        }

        private Graph generateSampleUnweighted(bool type)
        {
            List<Node> nodes = new List<Node>
            {
                new Node(1, new Point(500, 20)),
                new Node(2, new Point(400, 60)),
                new Node(3, new Point(600, 60)),
                new Node(4, new Point(350, 100)),
                new Node(5, new Point(450, 100)),
                new Node(6, new Point(550, 100)),
                new Node(7, new Point(650, 100)),
                new Node(8, new Point(325, 160)),
                new Node(9, new Point(375, 160)),
                new Node(10, new Point(425, 160)),
                new Node(11, new Point(475, 160)),
                new Node(12, new Point(525, 160)),
                new Node(13, new Point(575, 160)),
                new Node(14, new Point(625, 160)),
                new Node(15, new Point(675, 160)),
            };

            List<Edge> edges = new List<Edge>
            {
                new Edge(nodes[0], nodes[1], 0, type), // Edge 1 -> 2
                new Edge(nodes[0], nodes[2], 0, type), // Edge 1 -> 3
                new Edge(nodes[1], nodes[3], 0, type), // Edge 2 -> 4
                new Edge(nodes[1], nodes[4], 0, type), // Edge 2 -> 5
                new Edge(nodes[2], nodes[5], 0, type), // Edge 3 -> 6
                new Edge(nodes[2], nodes[6], 0, type), // Edge 3 -> 7 
                new Edge(nodes[3], nodes[7], 0, type), // Edge 4 -> 8 //
                new Edge(nodes[3], nodes[8], 0, type), // Edge 4 -> 9
                new Edge(nodes[4], nodes[9], 0, type), // Edge 5 -> 10
                new Edge(nodes[4], nodes[10], 0, type), // Edge 5 -> 11
                new Edge(nodes[5], nodes[11], 0, type), // Edge 6 -> 12
                new Edge(nodes[5], nodes[12], 0, type), // Edge 6 -> 13
                new Edge(nodes[6], nodes[13], 0, type), // Edge 7 -> 14
                new Edge(nodes[6], nodes[14], 0, type), // Edge 7 -> 15 
            
            };

            if (!type) // if undirected
            {
                edges.Add(new Edge(nodes[1], nodes[0], 0));
                edges.Add(new Edge(nodes[2], nodes[0], 0));
                edges.Add(new Edge(nodes[3], nodes[1], 0));
                edges.Add(new Edge(nodes[4], nodes[1], 0));
                edges.Add(new Edge(nodes[5], nodes[2], 0));
                edges.Add(new Edge(nodes[6], nodes[2], 0));
                edges.Add(new Edge(nodes[7], nodes[3], 0));
                edges.Add(new Edge(nodes[8], nodes[3], 0));
                edges.Add(new Edge(nodes[9], nodes[4], 0));
                edges.Add(new Edge(nodes[10], nodes[4], 0));
                edges.Add(new Edge(nodes[11], nodes[5], 0));
                edges.Add(new Edge(nodes[12], nodes[5], 0));
                edges.Add(new Edge(nodes[13], nodes[6], 0));
                edges.Add(new Edge(nodes[14], nodes[6], 0));
            }

            if (type) return new DirectedGraph(nodes, edges, this, type);
            else return new UndirectedGraph(nodes, edges, this, type);
        }

        public void showSample(bool tf) //true for weighted 
        {
            this.Paint -= (graphType ? directedGraph : undirectedGraph).Graph_Paint;
            directedGraph = tf ? generateSampleWeighted(true) : generateSampleUnweighted(true);
            undirectedGraph = tf ? generateSampleWeighted(false) : generateSampleUnweighted(false);
            this.Paint += (graphType ? directedGraph : undirectedGraph).Graph_Paint;
            this.Invalidate(true);
        }

        public void setAlgo(String algo) // Dijkstra, BFS, DFS
        {
            if (algo == null) return;

            if (algo.Equals("Dijkstra"))
            {
                algorithm = new DijkstraAlgorithm();
            }
            else if (algo.Equals("BFS"))
            {
                algorithm = new BFSAlgorithm();
            }
            else if (algo.Equals("DFS"))
            {
                algorithm = new DFSAlgorithm();
            }
        }

        public void AddNode()
        {
            if (IsNodes || IsAlgo) return;

            if (IsEdges)
            {
                this.MouseClick -= SelectNodeForEdge_MouseClick;
                IsEdges = false;
            }

            if (IsRemove)
            {
                this.MouseClick -= RemoveNode_MouseClick;
                IsRemove = false;
            }

            IsNodes = true;
            this.MouseClick += AddNode_MouseClick;
        }

        private void AddNode_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsAlgo) return;
            Node node = new Node(directedGraph.idcn++, e.Location);
            undirectedGraph.idcn++;
            directedGraph.AddNode(node);
            undirectedGraph.AddNode(node);
            this.Invalidate(true);
        }

        public void AddEdge(bool weighted)
        {
            if (IsEdges || IsAlgo) return;

            if (directedGraph.Nodes.Count < 2)
            {
                MessageBox.Show("There are less than 2 nodes in the graph, please add more nodes!");
                return;
            }

            if (IsNodes)
            {
                this.MouseClick -= AddNode_MouseClick;
                IsNodes = false;
            }

            if (IsRemove)
            {
                this.MouseClick -= RemoveNode_MouseClick;
                IsRemove = false;
            }


            IsEdges = true;
            isWeighted = weighted;
            this.MouseClick += SelectNodeForEdge_MouseClick;
        }

        private void SelectNodeForEdge_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsAlgo) return;
            Node nodeD = directedGraph.GetNodeAt(e.Location);
            Node nodeU = undirectedGraph.GetNodeAt(e.Location);

            if (nodeD != null)
            {
                if (selectedNodeD == null)
                {
                    selectedNodeD = nodeD;
                    selectedNodeU = nodeU;
                    selectedNodeD.Selected = true;
                    selectedNodeU.Selected = true;
                    this.Invalidate(true);
                }
                else
                {
                    if (selectedNodeD != nodeD)
                    {
                        nodeD.Selected = true;
                        nodeU.Selected = true;

                        this.Invalidate(true);

                        float weight = 0; // Default for unweighted
                        if (isWeighted)
                        {
                            weight = 1;
                            using (var form = new WeightInputForm())
                            {
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    weight = form.Weight;
                                }
                            }
                        }

                        directedGraph.AddEdge(new Edge(selectedNodeD, nodeD, weight, true));

                        undirectedGraph.AddEdge(new Edge(selectedNodeU, nodeU, weight, false));

                        selectedNodeD.Selected = false;
                        selectedNodeU.Selected = false;

                        nodeD.Selected = false;
                        nodeU.Selected = false;

                        this.Invalidate(true);
                        selectedNodeD = null;
                        selectedNodeU = null;

                    }
                }
            }
        }

        public void changeGraphType(bool type)
        {
            this.Paint -= (graphType ? directedGraph : undirectedGraph).Graph_Paint;
            this.graphType = type;
            this.Paint += (graphType ? directedGraph : undirectedGraph).Graph_Paint;
            this.Invalidate();
        }

        public void RemoveNode()
        {
            if (IsRemove || IsAlgo) return;
            if (IsEdges)
            {
                this.MouseClick -= SelectNodeForEdge_MouseClick;
                IsEdges = false;
            }
            if (IsNodes)
            {
                this.MouseClick -= AddNode_MouseClick;
                IsNodes = false;
            }

            IsRemove = true;

            this.MouseClick += RemoveNode_MouseClick;
        }

        private void RemoveNode_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsAlgo) return;
            directedGraph.RemoveNode(directedGraph.GetNodeAt(e.Location));
            undirectedGraph.RemoveNode(undirectedGraph.GetNodeAt(e.Location));
            this.Invalidate(true);
            //this.MouseClick -= AddNode_MouseClick;
            //this.MouseClick += GraphVisualizer_MouseClick;
        }

        public void Restart()
        {
            if (IsAlgo) return;
            if (IsEdges)
            {
                this.MouseClick -= SelectNodeForEdge_MouseClick;
                IsEdges = false;
            }
            if (IsNodes)
            {
                this.MouseClick -= AddNode_MouseClick;
                IsNodes = false;
            }
            if (IsRemove)
            {
                this.MouseClick -= RemoveNode_MouseClick;
                IsRemove = false;
            }

            ClearGraph();
        }

        public int increaseSpeed()
        {
            if (VisualSpeed > 500) VisualSpeed -= 250;

            directedGraph.VisualSpeed = this.VisualSpeed;
            undirectedGraph.VisualSpeed = this.VisualSpeed;
            return VisualSpeed;
        }

        public int decreaseSpeed()
        {
            if (VisualSpeed < 2000) VisualSpeed += 250;

            directedGraph.VisualSpeed = this.VisualSpeed;
            undirectedGraph.VisualSpeed = this.VisualSpeed;
            return VisualSpeed;
        }

        private void GraphVisualizer_Paint(object sender, PaintEventArgs e)
        {
            foreach (var node in (graphType ? directedGraph : undirectedGraph).Nodes)
            {
                node.Draw(e.Graphics);
            }

            foreach (var edge in (graphType ? directedGraph : undirectedGraph).Edges)
            {
                edge.Draw(e.Graphics);
            }
        }

        public void highlight_Path(List<Node> nodes, bool tf)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Selected = tf;
                if (i == nodes.Count - 1) break;
                Edge edge = (graphType ? directedGraph : undirectedGraph).Edges.Find(e => e.Start == nodes[i] && e.End == nodes[i + 1]);

                if (edge != null)
                {
                    edge.Selected = tf;
                }
            }
        }

        public void dehighlight_AllGraph()
        {
            (graphType ? directedGraph : undirectedGraph).dehiglight_Graph();
        }


        public async Task<List<Node>> RunAlgo(String start, String end)
        {
            if (IsAlgo) return null;
            IsAlgo = true;
            Node startN = (graphType ? directedGraph : undirectedGraph).GetNodeWith(start);
            Node endN = (graphType ? directedGraph : undirectedGraph).GetNodeWith(end);
            if (startN == null || endN == null)
            {
                MessageBox.Show("An error happend, please try again!");
                IsAlgo = false;
                return null;
            }

            List<Node> path = await algorithm.Execute((graphType ? directedGraph : undirectedGraph), startN, endN);

            if (path == null)
            {
                MessageBox.Show("The path could't be found :/");
                IsAlgo = false;
                return null;
            }

     
            await Task.Delay(3000);

            dehighlight_AllGraph();
            this.Invalidate(true);
            IsAlgo = false;
            return path;

        }

        public void ClearGraph()
        {
            IsAlgo = false;
            this.Paint -= (graphType ? directedGraph : undirectedGraph).Graph_Paint;
            directedGraph = new DirectedGraph(this,true);
            undirectedGraph = new UndirectedGraph(this, false);
            this.Paint += (graphType ? directedGraph : undirectedGraph).Graph_Paint;
            this.Invalidate(true);
        }


    }


}
