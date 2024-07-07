
namespace AlgoVisualizationProject
{
    partial class WeightedGraphForm
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

        

        private void InitializeComponent()
        {
            Name = "WeightedForm";
            Text = "Weighted Graph";
            graphVisualizer.setAlgo("Dijkstra");
            algorithmSet = "Dijkstra";
        }



        public override void AddEdgeButton_Click(object sender, EventArgs e)
        {
            graphVisualizer.AddEdge(true); // true for weighted edges
            Information.Text = "Adding Edges...";
        }

        public override void SampleGraph_Click(object sender, EventArgs e)
        {
            graphVisualizer.showSample(true);
        }


        #endregion
    }
}