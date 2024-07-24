namespace CreateCsFiles
{
    partial class LocalizationForm
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
            btnStartOperation = new Button();
            ProjectTB = new TextBox();
            label1 = new Label();
            GpOperations = new GroupBox();
            cbEnumOrError = new CheckBox();
            OutputTB = new TextBox();
            label2 = new Label();
            GpOperations.SuspendLayout();
            SuspendLayout();
            // 
            // btnStartOperation
            // 
            btnStartOperation.Location = new Point(26, 441);
            btnStartOperation.Name = "btnStartOperation";
            btnStartOperation.Size = new Size(191, 40);
            btnStartOperation.TabIndex = 0;
            btnStartOperation.Text = "Start Operation";
            btnStartOperation.UseVisualStyleBackColor = true;
            btnStartOperation.Click += btnStartOperation_Click;
            // 
            // ProjectTB
            // 
            ProjectTB.Location = new Point(181, 24);
            ProjectTB.Name = "ProjectTB";
            ProjectTB.Size = new Size(938, 35);
            ProjectTB.TabIndex = 41;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 24);
            label1.Name = "label1";
            label1.Size = new Size(174, 30);
            label1.TabIndex = 40;
            label1.Text = "Desired Address :";
            // 
            // GpOperations
            // 
            GpOperations.Controls.Add(cbEnumOrError);
            GpOperations.Location = new Point(26, 148);
            GpOperations.Name = "GpOperations";
            GpOperations.Size = new Size(1084, 287);
            GpOperations.TabIndex = 42;
            GpOperations.TabStop = false;
            GpOperations.Text = "Select Operations";
            // 
            // cbEnumOrError
            // 
            cbEnumOrError.AutoSize = true;
            cbEnumOrError.Location = new Point(36, 60);
            cbEnumOrError.Name = "cbEnumOrError";
            cbEnumOrError.Size = new Size(336, 34);
            cbEnumOrError.TabIndex = 0;
            cbEnumOrError.Text = "Add Enums And Error Messages";
            cbEnumOrError.UseVisualStyleBackColor = true;
            // 
            // OutputTB
            // 
            OutputTB.Location = new Point(181, 87);
            OutputTB.Name = "OutputTB";
            OutputTB.Size = new Size(938, 35);
            OutputTB.TabIndex = 44;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 87);
            label2.Name = "label2";
            label2.Size = new Size(179, 30);
            label2.TabIndex = 43;
            label2.Text = "Outputs Address :";
            // 
            // LocalizationForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1136, 495);
            Controls.Add(OutputTB);
            Controls.Add(label2);
            Controls.Add(GpOperations);
            Controls.Add(ProjectTB);
            Controls.Add(label1);
            Controls.Add(btnStartOperation);
            Name = "LocalizationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Localization";
            Load += LocalizationForm_Load;
            GpOperations.ResumeLayout(false);
            GpOperations.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartOperation;
        private TextBox ProjectTB;
        private Label label1;
        private GroupBox GpOperations;
        private CheckBox cbEnumOrError;
        private TextBox OutputTB;
        private Label label2;
    }
}