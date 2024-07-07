using System;
using System.Windows.Forms;

namespace AlgoVisualizationProject
{
    partial class DijkstraForm
    {
        protected System.ComponentModel.IContainer components = null;
        private GraphVisualizer graphVisualizer;
        private Button addNodeButton;
        private Button addEdgeButton;
        private Button runAlgorithmButton;
        private Label Result;
        private Label label2;
        private TextBox SourceVal;
        private Label label3;
        private Label label4;
        private TextBox DestVal;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) // Corrected position of 'protected'
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            graphVisualizer = new GraphVisualizer();
            addNodeButton = new Button();
            addEdgeButton = new Button();
            runAlgorithmButton = new Button();
            Result = new Label();
            label2 = new Label();
            SourceVal = new TextBox();
            label3 = new Label();
            label4 = new Label();
            DestVal = new TextBox();
            label1 = new Label();
            Information = new Label();
            removeNodeButton = new Button();
            RestartButton = new Button();
            SampleGraph = new Button();
            SlowVisual = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            FastVizual = new Button();
            SuspendLayout();
            // 
            // graphVisualizer
            // 
            graphVisualizer.BackColor = Color.White;
            graphVisualizer.Location = new Point(12, 121);
            graphVisualizer.Name = "graphVisualizer";
            graphVisualizer.Size = new Size(960, 328);
            graphVisualizer.TabIndex = 0;
            // 
            // addNodeButton
            // 
            addNodeButton.Location = new Point(12, 12);
            addNodeButton.Name = "addNodeButton";
            addNodeButton.Size = new Size(100, 30);
            addNodeButton.TabIndex = 1;
            addNodeButton.Text = "Add Node";
            addNodeButton.Click += AddNodeButton_Click;
            // 
            // addEdgeButton
            // 
            addEdgeButton.Location = new Point(12, 48);
            addEdgeButton.Name = "addEdgeButton";
            addEdgeButton.Size = new Size(100, 30);
            addEdgeButton.TabIndex = 2;
            addEdgeButton.Text = "Add Edge";
            addEdgeButton.Click += AddEdgeButton_Click;
            // 
            // runAlgorithmButton
            // 
            runAlgorithmButton.Location = new Point(498, 85);
            runAlgorithmButton.Name = "runAlgorithmButton";
            runAlgorithmButton.Size = new Size(100, 30);
            runAlgorithmButton.TabIndex = 3;
            runAlgorithmButton.Text = "Run Dijkstra";
            runAlgorithmButton.Click += RunAlgorithmButton_Click;
            // 
            // Result
            // 
            Result.AutoSize = true;
            Result.Location = new Point(733, 48);
            Result.Name = "Result";
            Result.Size = new Size(105, 15);
            Result.TabIndex = 4;
            Result.Text = "Label for the result";
            Result.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.WhiteSmoke;
            label2.Location = new Point(733, 20);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 5;
            label2.Text = "Result:";
            // 
            // SourceVal
            // 
            SourceVal.Location = new Point(498, 17);
            SourceVal.Name = "SourceVal";
            SourceVal.Size = new Size(100, 23);
            SourceVal.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Location = new Point(449, 20);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 7;
            label3.Text = "Source";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Location = new Point(425, 53);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 8;
            label4.Text = "Destination";
            // 
            // DestVal
            // 
            DestVal.Location = new Point(498, 50);
            DestVal.Name = "DestVal";
            DestVal.Size = new Size(100, 23);
            DestVal.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.WhiteSmoke;
            label1.Location = new Point(12, 121);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 10;
            label1.Text = "Graph Box";
            // 
            // Information
            // 
            Information.AutoSize = true;
            Information.BackColor = Color.WhiteSmoke;
            Information.Location = new Point(12, 434);
            Information.Name = "Information";
            Information.Size = new Size(282, 15);
            Information.TabIndex = 11;
            Information.Text = "Click \"Add Node\" Button or \"Sample Graph\" To Start";
            // 
            // removeNodeButton
            // 
            removeNodeButton.Location = new Point(12, 84);
            removeNodeButton.Name = "removeNodeButton";
            removeNodeButton.Size = new Size(100, 30);
            removeNodeButton.TabIndex = 12;
            removeNodeButton.Text = "Remove Node";
            removeNodeButton.Click += removeNodeButton_Click;
            // 
            // RestartButton
            // 
            RestartButton.Location = new Point(118, 84);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(100, 30);
            RestartButton.TabIndex = 13;
            RestartButton.Text = "Restart";
            RestartButton.Click += RestartButton_Click;
            // 
            // SampleGraph
            // 
            SampleGraph.Location = new Point(118, 12);
            SampleGraph.Name = "SampleGraph";
            SampleGraph.Size = new Size(100, 30);
            SampleGraph.TabIndex = 14;
            SampleGraph.Text = "Sample Graph";
            SampleGraph.Click += SampleGraph_Click;
            // 
            // SlowVisual
            // 
            SlowVisual.Font = new Font("Segoe UI", 8F);
            SlowVisual.Location = new Point(432, 94);
            SlowVisual.Margin = new Padding(1);
            SlowVisual.Name = "SlowVisual";
            SlowVisual.Size = new Size(60, 20);
            SlowVisual.TabIndex = 20;
            SlowVisual.Text = "Slower";
            SlowVisual.Visible = false;
            SlowVisual.Click += SlowVisual_Click;
            // 
            // FastVizual
            // 
            FastVizual.Font = new Font("Segoe UI", 8F);
            FastVizual.Location = new Point(604, 94);
            FastVizual.Name = "FastVizual";
            FastVizual.Size = new Size(60, 20);
            FastVizual.TabIndex = 16;
            FastVizual.Text = "Faster";
            FastVizual.Visible = false;
            FastVizual.Click += FastVizual_Click;
            // 
            // DijkstraForm
            // 
            ClientSize = new Size(984, 461);
            Controls.Add(FastVizual);
            Controls.Add(SlowVisual);
            Controls.Add(SampleGraph);
            Controls.Add(RestartButton);
            Controls.Add(removeNodeButton);
            Controls.Add(Information);
            Controls.Add(label1);
            Controls.Add(DestVal);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(SourceVal);
            Controls.Add(label2);
            Controls.Add(Result);
            Controls.Add(graphVisualizer);
            Controls.Add(addNodeButton);
            Controls.Add(addEdgeButton);
            Controls.Add(runAlgorithmButton);
            Name = "DijkstraForm";
            Text = "Dijkstra Graph";
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            graphVisualizer.AddNode();
            Information.Text = "Adding Nodes...";
        }

        private void AddEdgeButton_Click(object sender, EventArgs e)
        {
            graphVisualizer.AddEdge(true); // true for weighted edges
            Information.Text = "Adding Edges...";
        }

        private async void RunAlgorithmButton_Click(object sender, EventArgs e)
        {
            SlowVisual.Visible = true;
            FastVizual.Visible = true;
            Information.Text = "Running Dijsktra with speed of " + graphVisualizer.VisualSpeed + "ms ...";
            if (this.SourceVal.Text.Length == 0 || this.DestVal.Text.Length == 0)
            {
                MessageBox.Show("Please define source and destination values!");
                return;
            }
            List<Node> path = null;
                //await graphVisualizer.RunDijkstra(this.SourceVal.Text, this.DestVal.Text);
            if (path == null)
            {
                return;
            }

            this.Result.Text = "Path: "; // Reset the result text before adding new values
            foreach (Node node in path)
            {
                this.Result.Text += node.ID.ToString() + " ";
            }

            this.Result.Visible = true; // Show the result label

            SlowVisual.Visible = false;
            FastVizual.Visible = false;

            Information.Text = "Dijkstra Completed";
            
        }

        private void SlowVisual_Click(object sender, EventArgs e)
        {
            
            int speed = graphVisualizer.decreaseSpeed();

            Information.Text = "Running Dijsktra with speed of " + speed + "ms ...";
        }

        private void FastVizual_Click(object sender, EventArgs e)
        {
            int speed = graphVisualizer.increaseSpeed();
            Information.Text = "Running Dijsktra with speed of " + speed + "ms ...";

        }

        private void removeNodeButton_Click(object sender, EventArgs e)
        {
            graphVisualizer.RemoveNode();
            Information.Text = "Removing Nodes...";
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            graphVisualizer.ClearGraph();
            Information.Text = "Click \"Add Node\" Button or \"Sample Graph\" To Start";
        }

        private void SampleGraph_Click(object sender, EventArgs e)
        {
            graphVisualizer.showSample(true);
        }

        #endregion

        private Label label1;
        private Label Information;
        private Button removeNodeButton;
        private Button RestartButton;
        private Button SampleGraph;
        private Button SlowVisual;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button FastVizual;
    }
}
