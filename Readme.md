# Algorithmic Pathfinding Visualization
The **Algorithmic Pathfinding Visualization** is a C# Windows Forms application designed to help users visualize and understand graph algorithms, specifically Dijkstra's algorithm, Breadth-First Search (BFS), and Depth-First Search (DFS). It provides an interactive and educational interface for exploring the concepts of graph traversal and shortest path finding through practical examples. Users can add nodes and edges, choose different algorithms, and visualize their execution in real time.
## Functionalities
### Algorithm Visualization:
- Users can select from Dijkstra's, BFS, or DFS algorithms to find the shortest path or to traverse the graph. The application will highlight the process step-by-step.

![Main Form](https://github.com/EndritHasani01/VP-Algorithmic-Pathfinding-Visualization/assets/89995500/4fff162b-0db4-41ca-bb03-0336395f3676)

### Graph Types:
- The application supports both directed and undirected graphs, also weighted and unweighted graphs.
- If the user chooses Dijkstra algorithm on the main form, then only weighted graph is allowed, if BFS / DFS is chosen then only unweighted graph is allowed.

![Weighted Graph - Dijkstra](https://github.com/EndritHasani01/VP-Algorithmic-Pathfinding-Visualization/assets/89995500/55be338a-604a-4e4a-abbd-79a8ff571109)
![Unweighted Graph - BFS -DFS #001](https://github.com/EndritHasani01/VP-Algorithmic-Pathfinding-Visualization/assets/89995500/bcfc822c-9de0-43d5-bb1a-f739c10a9a41)
### Sample Graphs:
- The application provides pre-defined sample graphs to help users get started quickly.

![Unweighted Graph - BFS -DFS #002](https://github.com/EndritHasani01/VP-Algorithmic-Pathfinding-Visualization/assets/89995500/d5ee910a-35bc-4373-9db1-fd74a52f8e66)
![Weighted Graph - Dijkstra #002](https://github.com/EndritHasani01/VP-Algorithmic-Pathfinding-Visualization/assets/89995500/4c818766-4d55-4c13-aafc-559afb62f650)
### Node and Edge Creation:
- Users can add or remove nodes and create weighted or unweighted edges to construct their own graphs.
### Interactive Graph Manipulation:
- Users can modify the graph, including adding, removing nodes and edges by clicking on the Graph Box.
- Adding a Node: click “Add Node” -> click somewhere on the Graph Box.
- Adding an Edge: if you have added at least 2 nodes then click “Add Edge” -> click the node on the graph box from where you want to create the edge, then click the end node, if graph is weighted enter the weight, then click set.
- Removing a Node: click “Remove Node” -> click the node you want to remove.

![Weighted Graph - Dijkstra #003](https://github.com/EndritHasani01/VP-Algorithmic-Pathfinding-Visualization/assets/89995500/82d52437-bb5a-47cb-815b-ac9668582a2a)
### Running Algorithm and Speed Controls:
- Enter node “Source” id, enter node “Destination” id, then click Run button, visualization will be step by step, marking by red the nodes or edges that the algorithm is iterating. 
- Users can adjust the visualization speed to better understand each step of the algorithm.

![Weighted Graph - Dijkstra #005](https://github.com/EndritHasani01/VP-Algorithmic-Pathfinding-Visualization/assets/89995500/4ef615c7-e47c-4fe5-8aa5-09c315f4b52a)

## Purpose:
This application serves as a learning tool for students and professionals who want to understand the inner workings of graph algorithms. It is particularly useful for visual learners who benefit from seeing algorithms in action rather than just reading about them.
## Similar Applications:
An example of a similar application is [VisuAlgo](https://visualgo.net), which provides visualizations for various data structures and algorithms, though the focus of my project is more specific to graph algorithms and includes custom graph creation features.
## Description of the Solution
### Data Structures and Classes:
- Node: Represents a node in the graph. Contains an ID and a location.
- Edge: Represents an edge in the graph. Can be directed or undirected and may have a weight.
- GraphVisualizer: Manages the visualization of the graph and the execution of the algorithms.
- Graph: Abstract class that keeps the nodes and edges of the graph and implements all the algorithms.
- DirectedGraph, UndirectedGraph: Extends the Graph class by just overriding the “AddEdge” method
- Algorithm Interface: Defines a common interface for all algorithms (Here I used the **Strategy Design Pattern**)

```
public interface Algorithm
{
    public Task<List<Node>> Execute(Graph graph, Node startNode, Node endNode);
}
```

- DijkstraAlgorithm, BFSAlgorithm, DFSAlgorithm: Calls respective algorithms from the graph.
```
public class DijkstraAlgorithm : Algorithm
{
  public async Task<List<Node>> Execute(Graph graph, Node startNode, Node endNode)
  {
    return await graph.Dijkstra(startNode, endNode);
  }
}
```
- AlgoForm: An abstract class, that has the base code for both weighted and unweighted graph.
- UnweightedGraphForm and WeightedGraphForm: Forms for managing unweighted and weighted graphs, respectively, that inherit from AlgoForm.

## Description of a Key Class
Class: GraphVisualizer

The **GraphVisualizer** class is an extension of the **Control** class, which means that it is also added directly to Windows Form for display and interaction. The class manages two graph objects, **directedGraph** and **undirectedGraph**, allowing the user to switch between directed and undirected graph modes.

The main method here can be the “RunAlgo” method, where we first predefine with the “setAlgo” method which algorithm we are using, then we use the general “RunAlgo” method for each execution of the respective algorithm.

In order for the animation to happen and in order for the user to have access to increase and decrease speed while the algorithm is running I have made “RunAlgo” method asynchronized so I can use “await Task.Delay(int);” for emphasizing the steps that the algorithm is taking:
```
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
```
```
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
```

