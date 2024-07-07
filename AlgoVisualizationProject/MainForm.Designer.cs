using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoVisualizationProject
{
    public partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button dijkstraButton;
        private Button bfsDfsButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            dijkstraButton = new Button();
            bfsDfsButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // dijkstraButton
            // 
            dijkstraButton.Location = new Point(325, 120);
            dijkstraButton.Name = "dijkstraButton";
            dijkstraButton.Size = new Size(150, 40);
            dijkstraButton.TabIndex = 0;
            dijkstraButton.Text = "Dijkstra";
            dijkstraButton.Click += DijkstraButton_Click;
            // 
            // bfsDfsButton
            // 
            bfsDfsButton.Location = new Point(325, 220);
            bfsDfsButton.Name = "bfsDfsButton";
            bfsDfsButton.Size = new Size(150, 40);
            bfsDfsButton.TabIndex = 1;
            bfsDfsButton.Text = "BFS / DFS";
            bfsDfsButton.Click += BfsDfsButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F);
            label1.Location = new Point(178, 45);
            label1.Name = "label1";
            label1.Size = new Size(460, 27);
            label1.TabIndex = 2;
            label1.Text = "Choose one of the algorithms to visualize:";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // MainForm
            // 
            BackgroundImage = Properties.Resources.Main_Background;
            ClientSize = new Size(800, 400);
            Controls.Add(label1);
            Controls.Add(dijkstraButton);
            Controls.Add(bfsDfsButton);
            Name = "MainForm";
            Text = "Graph Algorithm Visualizer";
            ResumeLayout(false);
            PerformLayout();
        }

        private void DijkstraButton_Click(object sender, EventArgs e)
        {
            WeightedGraphForm dijkstraForm = new WeightedGraphForm();
            dijkstraForm.Show();
        }

        private void BfsDfsButton_Click(object sender, EventArgs e)
        {
            UnweightedGraphForm bfsDfsForm = new UnweightedGraphForm();
            bfsDfsForm.Show();
        }
        #endregion

        private Label label1;
    }

}