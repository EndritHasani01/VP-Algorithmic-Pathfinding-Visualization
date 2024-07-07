namespace AlgoVisualizationProject
{
    partial class UnweightedGraphForm : AlgoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private ComboBox algorithmComboBox;


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
            algorithmComboBox = new ComboBox();
            SuspendLayout();
            // 
            // algorithmComboBox
            // 
            algorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            algorithmComboBox.Items.AddRange(new object[] { "BFS", "DFS" });
            algorithmComboBox.Location = new Point(118, 52);
            algorithmComboBox.Name = "algorithmComboBox";
            algorithmComboBox.Size = new Size(100, 23);
            algorithmComboBox.TabIndex = 21;
            algorithmComboBox.SelectedIndex = 0;
            algorithmComboBox.SelectedIndexChanged += algorithmComboBox_SelectedIndexChanged;
            algorithmComboBox_SelectedIndexChanged(null, null);
            algorithmSet = "BFS";
            // 
            // UnweightedGraphForm
            // 
            ClientSize = new Size(984, 461);
            Controls.Add(algorithmComboBox);
            Name = "UnweightedGraphForm";
            Text = "Unweighted Graph";
            Controls.SetChildIndex(runAlgorithmButton, 0);
            Controls.SetChildIndex(addEdgeButton, 0);
            Controls.SetChildIndex(addNodeButton, 0);
            Controls.SetChildIndex(graphVisualizer, 0);
            Controls.SetChildIndex(Result, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(SourceVal, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(DestVal, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(Information, 0);
            Controls.SetChildIndex(removeNodeButton, 0);
            Controls.SetChildIndex(RestartButton, 0);
            Controls.SetChildIndex(SampleGraph, 0);
            Controls.SetChildIndex(SlowVisual, 0);
            Controls.SetChildIndex(FastVizual, 0);
            Controls.SetChildIndex(algorithmComboBox, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        public override void disableenableButtonsWhileAlgoButtonClicked()
        {
            base.disableenableButtonsWhileAlgoButtonClicked();
            if (isAlgoButtonClicked)
            {
                algorithmComboBox.Enabled = false;
            }
            else
            {
                algorithmComboBox.Enabled = true;
            }
        }

        private void algorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAlgorithm = algorithmComboBox.SelectedItem.ToString();
            algorithmSet = selectedAlgorithm;
            graphVisualizer.setAlgo(selectedAlgorithm);
           
        }

        public override void AddEdgeButton_Click(object sender, EventArgs e)
        {
            graphVisualizer.AddEdge(false); // true for weighted edges
            Information.Text = "Adding Edges...";
        }

        public override void SampleGraph_Click(object sender, EventArgs e)
        {
            graphVisualizer.showSample(false);
        }

        #endregion

        
    }
}