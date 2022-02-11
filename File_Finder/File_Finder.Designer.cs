namespace File_Finder
{
    partial class File_Finder
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
            this.recurCheckBox = new System.Windows.Forms.CheckBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileTypesTextBox = new System.Windows.Forms.TextBox();
            this.searchTermType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.phraseTextBox = new System.Windows.Forms.TextBox();
            this.lowerBound = new System.Windows.Forms.TextBox();
            this.upperBound = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.foundFiles = new System.Windows.Forms.ListBox();
            this.notDetected = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.foundFilesPath = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // recurCheckBox
            // 
            this.recurCheckBox.AutoSize = true;
            this.recurCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recurCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recurCheckBox.Location = new System.Drawing.Point(189, 141);
            this.recurCheckBox.Name = "recurCheckBox";
            this.recurCheckBox.Size = new System.Drawing.Size(120, 20);
            this.recurCheckBox.TabIndex = 0;
            this.recurCheckBox.Text = "Recursive Search";
            this.recurCheckBox.UseVisualStyleBackColor = true;
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pathTextBox.Location = new System.Drawing.Point(189, 23);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(325, 23);
            this.pathTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(114, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(126, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "File Types";
            // 
            // fileTypesTextBox
            // 
            this.fileTypesTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileTypesTextBox.Location = new System.Drawing.Point(189, 62);
            this.fileTypesTextBox.Name = "fileTypesTextBox";
            this.fileTypesTextBox.Size = new System.Drawing.Size(325, 23);
            this.fileTypesTextBox.TabIndex = 3;
            // 
            // searchTermType
            // 
            this.searchTermType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchTermType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchTermType.FormattingEnabled = true;
            this.searchTermType.Items.AddRange(new object[] {
            "Keyword Phrase",
            "Number Range"});
            this.searchTermType.Location = new System.Drawing.Point(189, 102);
            this.searchTermType.Name = "searchTermType";
            this.searchTermType.Size = new System.Drawing.Size(325, 23);
            this.searchTermType.TabIndex = 5;
            this.searchTermType.SelectedIndexChanged += new System.EventHandler(this.searchTermType_Change);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // phraseTextBox
            // 
            this.phraseTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.phraseTextBox.Location = new System.Drawing.Point(189, 167);
            this.phraseTextBox.Name = "phraseTextBox";
            this.phraseTextBox.Size = new System.Drawing.Size(325, 23);
            this.phraseTextBox.TabIndex = 7;
            // 
            // lowerBound
            // 
            this.lowerBound.Location = new System.Drawing.Point(189, 167);
            this.lowerBound.Name = "lowerBound";
            this.lowerBound.Size = new System.Drawing.Size(100, 23);
            this.lowerBound.TabIndex = 8;
            // 
            // upperBound
            // 
            this.upperBound.Location = new System.Drawing.Point(325, 167);
            this.upperBound.Name = "upperBound";
            this.upperBound.Size = new System.Drawing.Size(100, 23);
            this.upperBound.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(295, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(112, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Search Term";
            // 
            // foundFiles
            // 
            this.foundFiles.FormattingEnabled = true;
            this.foundFiles.ItemHeight = 15;
            this.foundFiles.Location = new System.Drawing.Point(189, 314);
            this.foundFiles.Name = "foundFiles";
            this.foundFiles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.foundFiles.Size = new System.Drawing.Size(325, 94);
            this.foundFiles.TabIndex = 12;
            // 
            // notDetected
            // 
            this.notDetected.FormattingEnabled = true;
            this.notDetected.ItemHeight = 15;
            this.notDetected.Location = new System.Drawing.Point(189, 539);
            this.notDetected.Name = "notDetected";
            this.notDetected.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.notDetected.Size = new System.Drawing.Size(325, 94);
            this.notDetected.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(103, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Detected Files";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(106, 539);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Not Detected";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(106, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Detected Files";
            // 
            // foundFilesPath
            // 
            this.foundFilesPath.FormattingEnabled = true;
            this.foundFilesPath.HorizontalScrollbar = true;
            this.foundFilesPath.ItemHeight = 15;
            this.foundFilesPath.Location = new System.Drawing.Point(189, 428);
            this.foundFilesPath.Name = "foundFilesPath";
            this.foundFilesPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.foundFilesPath.Size = new System.Drawing.Size(325, 94);
            this.foundFilesPath.TabIndex = 16;
            this.foundFilesPath.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(124, 443);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "(full path)";
            // 
            // File_Finder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 661);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.foundFilesPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.notDetected);
            this.Controls.Add(this.foundFiles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.upperBound);
            this.Controls.Add(this.lowerBound);
            this.Controls.Add(this.phraseTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchTermType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileTypesTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.recurCheckBox);
            this.Name = "File_Finder";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private CheckBox recurCheckBox;
        private TextBox pathTextBox;
        private Label label1;
        private Label label2;
        private TextBox fileTypesTextBox;
        private ComboBox searchTermType;
        private Button button1;
        private TextBox phraseTextBox;
        private TextBox lowerBound;
        private TextBox upperBound;
        private Label label3;
        private Label label4;
        private ListBox foundFiles;
        private ListBox notDetected;
        private Label label5;
        private Label label6;
        private Label label7;
        private ListBox foundFilesPath;
        private Label label8;
    }
}