using Microsoft.VisualBasic;

namespace AlgoVisualizationProject
{
    partial class BFSDFSForm : AlgoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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

        private GraphVisualizer graphVisualizer;
        private Button addNodeButton;
        private Button addEdgeButton;
        private Button runAlgorithmButton;
        private ComboBox algorithmComboBox;

        private void InitializeComponent()
        {
            this.graphVisualizer = new GraphVisualizer();
            this.addNodeButton = new Button();
            this.addEdgeButton = new Button();
            this.runAlgorithmButton = new Button();
            this.algorithmComboBox = new ComboBox();

            // 
            // graphVisualizer
            // 
            this.graphVisualizer.Location = new System.Drawing.Point(0, 0);
            this.graphVisualizer.Size = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.graphVisualizer);

            // 
            // addNodeButton
            // 
            this.addNodeButton.Text = "Add Node";
            this.addNodeButton.Size = new System.Drawing.Size(100, 30);
            this.addNodeButton.Location = new System.Drawing.Point(810, 50);
            this.addNodeButton.Click += new EventHandler(this.AddNodeButton_Click);
            this.Controls.Add(this.addNodeButton);

            // 
            // addEdgeButton
            // 
            this.addEdgeButton.Text = "Add Edge";
            this.addEdgeButton.Size = new System.Drawing.Size(100, 30);
            this.addEdgeButton.Location = new System.Drawing.Point(810, 100);
            this.addEdgeButton.Click += new EventHandler(this.AddEdgeButton_Click);
            this.Controls.Add(this.addEdgeButton);

            // 
            // runAlgorithmButton
            // 
            this.runAlgorithmButton.Text = "Run Algorithm";
            this.runAlgorithmButton.Size = new System.Drawing.Size(100, 30);
            this.runAlgorithmButton.Location = new System.Drawing.Point(810, 200);
            this.runAlgorithmButton.Click += new EventHandler(this.RunAlgorithmButton_Click);
            this.Controls.Add(this.runAlgorithmButton);

            // 
            // algorithmComboBox
            // 
            this.algorithmComboBox.Items.AddRange(new object[] { "BFS", "DFS" });
            this.algorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.algorithmComboBox.Location = new System.Drawing.Point(810, 150);
            this.algorithmComboBox.Size = new System.Drawing.Size(121, 21);
            this.Controls.Add(this.algorithmComboBox);

            // 
            // BFSDFSForm
            // 
            this.Text = "BFS/DFS Graph";
            this.Size = new System.Drawing.Size(1000, 500);
        }

        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            graphVisualizer.AddNode();
        }

        private void AddEdgeButton_Click(object sender, EventArgs e)
        {
            graphVisualizer.AddEdge(false); // false for unweighted edges
        }

        private void RunAlgorithmButton_Click(object sender, EventArgs e)
        {
            string algorithm = algorithmComboBox.SelectedItem.ToString();
            //graphVisualizer.RunBFSDFS(algorithm);
        }
        #endregion

    }

}



