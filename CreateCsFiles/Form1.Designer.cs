namespace CreateCsFiles
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EntityName = new TextBox();
            createCheckBox = new CheckBox();
            editCheckBox = new CheckBox();
            deleteCheckBox = new CheckBox();
            label1 = new Label();
            GetById = new CheckBox();
            GetAll = new CheckBox();
            Generate = new Button();
            label2 = new Label();
            txbNameSpace = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            comboBox3 = new ComboBox();
            textBox6 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            Reset = new Button();
            comboBox4 = new ComboBox();
            textBox8 = new TextBox();
            label6 = new Label();
            textBox7 = new TextBox();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            localizationToolStripMenuItem = new ToolStripMenuItem();
            checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            comboBox8 = new ComboBox();
            comboBox7 = new ComboBox();
            comboBox6 = new ComboBox();
            comboBox5 = new ComboBox();
            comboBox9 = new ComboBox();
            comboBox10 = new ComboBox();
            comboBox11 = new ComboBox();
            chbForHarmony = new CheckBox();
            CbController = new ComboBox();
            label7 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // EntityName
            // 
            EntityName.Location = new Point(170, 136);
            EntityName.Name = "EntityName";
            EntityName.Size = new Size(219, 35);
            EntityName.TabIndex = 2;
            EntityName.TextChanged += EntityName_TextChanged;
            // 
            // createCheckBox
            // 
            createCheckBox.AutoSize = true;
            createCheckBox.Location = new Point(418, 65);
            createCheckBox.Name = "createCheckBox";
            createCheckBox.Size = new Size(99, 34);
            createCheckBox.TabIndex = 13;
            createCheckBox.Text = "Create";
            createCheckBox.UseVisualStyleBackColor = true;
            // 
            // editCheckBox
            // 
            editCheckBox.AutoSize = true;
            editCheckBox.Location = new Point(417, 125);
            editCheckBox.Name = "editCheckBox";
            editCheckBox.Size = new Size(74, 34);
            editCheckBox.TabIndex = 14;
            editCheckBox.Text = "Edit";
            editCheckBox.UseVisualStyleBackColor = true;
            // 
            // deleteCheckBox
            // 
            deleteCheckBox.AutoSize = true;
            deleteCheckBox.Location = new Point(417, 180);
            deleteCheckBox.Name = "deleteCheckBox";
            deleteCheckBox.Size = new Size(99, 34);
            deleteCheckBox.TabIndex = 15;
            deleteCheckBox.Text = "Delete";
            deleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 136);
            label1.Name = "label1";
            label1.Size = new Size(138, 30);
            label1.TabIndex = 7;
            label1.Text = "Entity Name :";
            // 
            // GetById
            // 
            GetById.AutoSize = true;
            GetById.Location = new Point(755, 72);
            GetById.Name = "GetById";
            GetById.Size = new Size(123, 34);
            GetById.TabIndex = 17;
            GetById.Text = "Get By Id";
            GetById.UseVisualStyleBackColor = true;
            // 
            // GetAll
            // 
            GetAll.AutoSize = true;
            GetAll.Location = new Point(755, 122);
            GetAll.Name = "GetAll";
            GetAll.Size = new Size(101, 34);
            GetAll.TabIndex = 16;
            GetAll.Text = "Get All";
            GetAll.UseVisualStyleBackColor = true;
            // 
            // Generate
            // 
            Generate.Location = new Point(34, 553);
            Generate.Name = "Generate";
            Generate.Size = new Size(131, 40);
            Generate.TabIndex = 12;
            Generate.Text = "Generate";
            Generate.UseVisualStyleBackColor = true;
            Generate.Click += Generate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 66);
            label2.Name = "label2";
            label2.Size = new Size(135, 30);
            label2.TabIndex = 13;
            label2.Text = "NameSpace :";
            // 
            // txbNameSpace
            // 
            txbNameSpace.Location = new Point(170, 66);
            txbNameSpace.Name = "txbNameSpace";
            txbNameSpace.Size = new Size(219, 35);
            txbNameSpace.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(24, 285);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(157, 35);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(191, 285);
            label3.Name = "label3";
            label3.Size = new Size(127, 30);
            label3.TabIndex = 15;
            label3.Text = "Entity Name";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(378, 282);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(162, 35);
            textBox2.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(588, 277);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(175, 38);
            comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(588, 344);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(175, 38);
            comboBox2.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(378, 349);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(162, 35);
            textBox4.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(191, 352);
            label4.Name = "label4";
            label4.Size = new Size(127, 30);
            label4.TabIndex = 19;
            label4.Text = "Entity Name";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(24, 352);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(157, 35);
            textBox3.TabIndex = 6;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(588, 409);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(175, 38);
            comboBox3.TabIndex = 11;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(378, 414);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(162, 35);
            textBox6.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(191, 417);
            label5.Name = "label5";
            label5.Size = new Size(127, 30);
            label5.TabIndex = 23;
            label5.Text = "Entity Name";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(24, 417);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(157, 35);
            textBox5.TabIndex = 9;
            // 
            // Reset
            // 
            Reset.Location = new Point(838, 553);
            Reset.Name = "Reset";
            Reset.Size = new Size(131, 40);
            Reset.TabIndex = 24;
            Reset.Text = "Reset";
            Reset.UseVisualStyleBackColor = true;
            Reset.Click += Reset_Click;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(588, 473);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(175, 38);
            comboBox4.TabIndex = 27;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(378, 478);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(162, 35);
            textBox8.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(191, 481);
            label6.Name = "label6";
            label6.Size = new Size(127, 30);
            label6.TabIndex = 28;
            label6.Text = "Entity Name";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(24, 481);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(157, 35);
            textBox7.TabIndex = 25;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(28, 28);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, localizationToolStripMenuItem, checkForUpdatesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(992, 38);
            menuStrip1.TabIndex = 35;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(105, 34);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // localizationToolStripMenuItem
            // 
            localizationToolStripMenuItem.Name = "localizationToolStripMenuItem";
            localizationToolStripMenuItem.Size = new Size(141, 34);
            localizationToolStripMenuItem.Text = "Localization";
            localizationToolStripMenuItem.Click += localizationToolStripMenuItem_Click;
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            checkForUpdatesToolStripMenuItem.Size = new Size(204, 34);
            checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
            checkForUpdatesToolStripMenuItem.Click += checkForUpdatesToolStripMenuItem_Click;
            // 
            // comboBox8
            // 
            comboBox8.FormattingEnabled = true;
            comboBox8.Location = new Point(794, 473);
            comboBox8.Name = "comboBox8";
            comboBox8.Size = new Size(175, 38);
            comboBox8.TabIndex = 39;
            // 
            // comboBox7
            // 
            comboBox7.FormattingEnabled = true;
            comboBox7.Location = new Point(794, 409);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(175, 38);
            comboBox7.TabIndex = 38;
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(794, 344);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(175, 38);
            comboBox6.TabIndex = 37;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(794, 277);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(175, 38);
            comboBox5.TabIndex = 36;
            // 
            // comboBox9
            // 
            comboBox9.FormattingEnabled = true;
            comboBox9.Location = new Point(526, 66);
            comboBox9.Name = "comboBox9";
            comboBox9.Size = new Size(161, 38);
            comboBox9.TabIndex = 40;
            // 
            // comboBox10
            // 
            comboBox10.FormattingEnabled = true;
            comboBox10.Location = new Point(526, 122);
            comboBox10.Name = "comboBox10";
            comboBox10.Size = new Size(161, 38);
            comboBox10.TabIndex = 41;
            // 
            // comboBox11
            // 
            comboBox11.FormattingEnabled = true;
            comboBox11.Location = new Point(526, 178);
            comboBox11.Name = "comboBox11";
            comboBox11.Size = new Size(161, 38);
            comboBox11.TabIndex = 42;
            // 
            // chbForHarmony
            // 
            chbForHarmony.AutoSize = true;
            chbForHarmony.Location = new Point(794, 196);
            chbForHarmony.Name = "chbForHarmony";
            chbForHarmony.Size = new Size(159, 34);
            chbForHarmony.TabIndex = 43;
            chbForHarmony.Text = "For Harmony";
            chbForHarmony.UseVisualStyleBackColor = true;
            // 
            // CbController
            // 
            CbController.FormattingEnabled = true;
            CbController.Location = new Point(170, 196);
            CbController.Name = "CbController";
            CbController.Size = new Size(219, 38);
            CbController.TabIndex = 44;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 197);
            label7.Name = "label7";
            label7.Size = new Size(115, 30);
            label7.TabIndex = 45;
            label7.Text = "Controller :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 616);
            Controls.Add(label7);
            Controls.Add(CbController);
            Controls.Add(chbForHarmony);
            Controls.Add(comboBox11);
            Controls.Add(comboBox10);
            Controls.Add(comboBox9);
            Controls.Add(comboBox8);
            Controls.Add(comboBox7);
            Controls.Add(comboBox6);
            Controls.Add(comboBox5);
            Controls.Add(comboBox4);
            Controls.Add(textBox8);
            Controls.Add(label6);
            Controls.Add(textBox7);
            Controls.Add(Reset);
            Controls.Add(comboBox3);
            Controls.Add(textBox6);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(comboBox2);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(txbNameSpace);
            Controls.Add(Generate);
            Controls.Add(GetAll);
            Controls.Add(GetById);
            Controls.Add(label1);
            Controls.Add(deleteCheckBox);
            Controls.Add(editCheckBox);
            Controls.Add(createCheckBox);
            Controls.Add(EntityName);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "File Maker";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EntityName;
        private CheckBox createCheckBox;
        private CheckBox editCheckBox;
        private CheckBox deleteCheckBox;
        private Label label1;
        private CheckBox GetById;
        private CheckBox GetAll;
        private Button Generate;
        private Label label2;
        private TextBox txbNameSpace;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private ComboBox comboBox3;
        private TextBox textBox6;
        private Label label5;
        private TextBox textBox5;
        private Button Reset;
        private ComboBox comboBox4;
        private TextBox textBox8;
        private Label label6;
        private TextBox textBox7;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem localizationToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private ComboBox comboBox8;
        private ComboBox comboBox7;
        private ComboBox comboBox6;
        private ComboBox comboBox5;
        private ComboBox comboBox9;
        private ComboBox comboBox10;
        private ComboBox comboBox11;
        private CheckBox chbForHarmony;
        private ComboBox CbController;
        private Label label7;
    }
}