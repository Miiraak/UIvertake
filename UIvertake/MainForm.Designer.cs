namespace UIvertake
{
    partial class MainForm
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
        /// the contents of this file with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonAnalyze = new Button();
            comboBoxWindows = new ComboBox();
            labelWindows = new Label();
            comboBoxFields = new ComboBox();
            labelFields = new Label();
            buttonStart = new Button();
            SuspendLayout();
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.FlatStyle = FlatStyle.Flat;
            buttonAnalyze.ForeColor = SystemColors.Control;
            buttonAnalyze.Location = new Point(210, 67);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(77, 23);
            buttonAnalyze.TabIndex = 0;
            buttonAnalyze.Text = "Analyze";
            buttonAnalyze.UseVisualStyleBackColor = true;
            buttonAnalyze.Click += ButtonAnalyze_Click;
            // 
            // comboBoxWindows
            // 
            comboBoxWindows.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWindows.FlatStyle = FlatStyle.Flat;
            comboBoxWindows.FormattingEnabled = true;
            comboBoxWindows.Location = new Point(75, 9);
            comboBoxWindows.Name = "comboBoxWindows";
            comboBoxWindows.Size = new Size(295, 22);
            comboBoxWindows.TabIndex = 1;
            comboBoxWindows.SelectedIndexChanged += ComboBoxWindows_SelectedIndexChanged;
            // 
            // labelWindows
            // 
            labelWindows.AutoSize = true;
            labelWindows.ForeColor = SystemColors.Control;
            labelWindows.Location = new Point(12, 9);
            labelWindows.Name = "labelWindows";
            labelWindows.Size = new Size(63, 14);
            labelWindows.TabIndex = 2;
            labelWindows.Text = "Window :";
            // 
            // comboBoxFields
            // 
            comboBoxFields.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFields.FlatStyle = FlatStyle.Flat;
            comboBoxFields.FormattingEnabled = true;
            comboBoxFields.Location = new Point(75, 38);
            comboBoxFields.Name = "comboBoxFields";
            comboBoxFields.Size = new Size(295, 22);
            comboBoxFields.TabIndex = 3;
            // 
            // labelFields
            // 
            labelFields.AutoSize = true;
            labelFields.ForeColor = SystemColors.Control;
            labelFields.Location = new Point(12, 41);
            labelFields.Name = "labelFields";
            labelFields.Size = new Size(63, 14);
            labelFields.TabIndex = 4;
            labelFields.Text = "Fields :";
            // 
            // buttonStart
            // 
            buttonStart.FlatStyle = FlatStyle.Flat;
            buttonStart.ForeColor = SystemColors.Control;
            buttonStart.Location = new Point(293, 67);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(77, 23);
            buttonStart.TabIndex = 5;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += ButtonStart_Click;
            // 
            // MainForm
            // 
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(382, 98);
            Controls.Add(buttonStart);
            Controls.Add(labelFields);
            Controls.Add(comboBoxFields);
            Controls.Add(labelWindows);
            Controls.Add(comboBoxWindows);
            Controls.Add(buttonAnalyze);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            Text = "UIvertake";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.ComboBox comboBoxWindows;
        private System.Windows.Forms.Label labelWindows;
        private System.Windows.Forms.ComboBox comboBoxFields;
        private System.Windows.Forms.Label labelFields;
        private System.Windows.Forms.Button buttonStart;
    }
}