namespace AlgoVisualizationProject
{
    partial class WeightInputForm
    {
        private NumericUpDown weightInput;
        private Button okButton;

        public float Weight { get; private set; }


        private void InitializeComponent()
        {
            weightInput = new NumericUpDown();
            okButton = new Button();
            weightLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)weightInput).BeginInit();
            SuspendLayout();
            // 
            // weightInput
            // 
            weightInput.Location = new Point(90, 20);
            weightInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            weightInput.Name = "weightInput";
            weightInput.Size = new Size(120, 23);
            weightInput.TabIndex = 0;
            weightInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // okButton
            // 
            okButton.Location = new Point(135, 49);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 1;
            okButton.Text = "Set";
            okButton.Click += OkButton_Click;
            // 
            // weightLabel
            // 
            weightLabel.AutoSize = true;
            weightLabel.Location = new Point(38, 22);
            weightLabel.Name = "weightLabel";
            weightLabel.Size = new Size(46, 15);
            weightLabel.TabIndex = 2;
            weightLabel.Text = "weight:";
            // 
            // WeightInputForm
            // 
            ClientSize = new Size(222, 89);
            Controls.Add(weightLabel);
            Controls.Add(weightInput);
            Controls.Add(okButton);
            Name = "WeightInputForm";
            Text = "Enter Weight";
            ((System.ComponentModel.ISupportInitialize)weightInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Weight = (float)this.weightInput.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private Label weightLabel;
    }
}