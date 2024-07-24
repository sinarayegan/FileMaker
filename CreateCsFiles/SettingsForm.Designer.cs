namespace CreateCsFiles
{
    partial class SettingsForm
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
            QueriesTB = new TextBox();
            CommandsTB = new TextBox();
            label8 = new Label();
            label7 = new Label();
            SaveAddresses = new Button();
            ProjectTB = new TextBox();
            label1 = new Label();
            OutputTB = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txbIpServer = new TextBox();
            SuspendLayout();
            // 
            // QueriesTB
            // 
            QueriesTB.Location = new Point(227, 90);
            QueriesTB.Name = "QueriesTB";
            QueriesTB.Size = new Size(938, 35);
            QueriesTB.TabIndex = 36;
            // 
            // CommandsTB
            // 
            CommandsTB.Location = new Point(227, 24);
            CommandsTB.Name = "CommandsTB";
            CommandsTB.Size = new Size(938, 35);
            CommandsTB.TabIndex = 35;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 88);
            label8.Name = "label8";
            label8.Size = new Size(175, 30);
            label8.TabIndex = 34;
            label8.Text = "Queries Address :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 24);
            label7.Name = "label7";
            label7.Size = new Size(209, 30);
            label7.TabIndex = 33;
            label7.Text = "Commands Address :";
            // 
            // SaveAddresses
            // 
            SaveAddresses.Location = new Point(960, 385);
            SaveAddresses.Name = "SaveAddresses";
            SaveAddresses.Size = new Size(189, 40);
            SaveAddresses.TabIndex = 37;
            SaveAddresses.Text = "Save Addresses";
            SaveAddresses.UseVisualStyleBackColor = true;
            SaveAddresses.Click += SaveAddresses_Click;
            // 
            // ProjectTB
            // 
            ProjectTB.Location = new Point(227, 154);
            ProjectTB.Name = "ProjectTB";
            ProjectTB.Size = new Size(938, 35);
            ProjectTB.TabIndex = 39;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 152);
            label1.Name = "label1";
            label1.Size = new Size(168, 30);
            label1.TabIndex = 38;
            label1.Text = "Project Address :";
            // 
            // OutputTB
            // 
            OutputTB.Location = new Point(227, 220);
            OutputTB.Name = "OutputTB";
            OutputTB.Size = new Size(938, 35);
            OutputTB.TabIndex = 46;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 220);
            label2.Name = "label2";
            label2.Size = new Size(179, 30);
            label2.TabIndex = 45;
            label2.Text = "Outputs Address :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 294);
            label3.Name = "label3";
            label3.Size = new Size(105, 30);
            label3.TabIndex = 47;
            label3.Text = "Server Ip :";
            // 
            // txbIpServer
            // 
            txbIpServer.Location = new Point(227, 294);
            txbIpServer.Name = "txbIpServer";
            txbIpServer.Size = new Size(938, 35);
            txbIpServer.TabIndex = 48;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 447);
            Controls.Add(txbIpServer);
            Controls.Add(label3);
            Controls.Add(OutputTB);
            Controls.Add(label2);
            Controls.Add(ProjectTB);
            Controls.Add(label1);
            Controls.Add(SaveAddresses);
            Controls.Add(QueriesTB);
            Controls.Add(CommandsTB);
            Controls.Add(label8);
            Controls.Add(label7);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox QueriesTB;
        private TextBox CommandsTB;
        private Label label8;
        private Label label7;
        private Button SaveAddresses;
        private TextBox ProjectTB;
        private Label label1;
        private TextBox OutputTB;
        private Label label2;
        private Label label3;
        private TextBox txbIpServer;
    }
}