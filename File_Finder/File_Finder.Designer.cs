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
            this.components = new System.ComponentModel.Container();
            this.recurCheckBox = new System.Windows.Forms.CheckBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileTypesTextBox = new System.Windows.Forms.TextBox();
            this.searchTermType = new System.Windows.Forms.ComboBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.phraseTextBox = new System.Windows.Forms.TextBox();
            this.lowerBound = new System.Windows.Forms.TextBox();
            this.upperBound = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.foundFiles = new System.Windows.Forms.ListBox();
            this.fileItemCM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.open_file = new System.Windows.Forms.ToolStripMenuItem();
            this.open_explorer = new System.Windows.Forms.ToolStripMenuItem();
            this.notDetected = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.foundFilesPath = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.genFilesBtn = new System.Windows.Forms.Button();
            this.fileItemCM.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // recurCheckBox
            // 
            this.recurCheckBox.AutoSize = true;
            this.recurCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recurCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recurCheckBox.Location = new System.Drawing.Point(100, 141);
            this.recurCheckBox.Name = "recurCheckBox";
            this.recurCheckBox.Size = new System.Drawing.Size(120, 20);
            this.recurCheckBox.TabIndex = 4;
            this.recurCheckBox.Text = "Recursive Search";
            this.recurCheckBox.UseVisualStyleBackColor = true;
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.pathTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pathTextBox.Location = new System.Drawing.Point(100, 23);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(325, 23);
            this.pathTextBox.TabIndex = 1;
            this.pathTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(37, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "File Types";
            // 
            // fileTypesTextBox
            // 
            this.fileTypesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTypesTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileTypesTextBox.Location = new System.Drawing.Point(100, 62);
            this.fileTypesTextBox.Name = "fileTypesTextBox";
            this.fileTypesTextBox.Size = new System.Drawing.Size(325, 23);
            this.fileTypesTextBox.TabIndex = 2;
            this.fileTypesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // searchTermType
            // 
            this.searchTermType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTermType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchTermType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchTermType.FormattingEnabled = true;
            this.searchTermType.Items.AddRange(new object[] {
            "Keyword Phrase",
            "Number Range"});
            this.searchTermType.Location = new System.Drawing.Point(100, 102);
            this.searchTermType.Name = "searchTermType";
            this.searchTermType.Size = new System.Drawing.Size(325, 23);
            this.searchTermType.TabIndex = 3;
            this.searchTermType.SelectedIndexChanged += new System.EventHandler(this.searchTermType_Change);
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchBtn.Location = new System.Drawing.Point(166, 244);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 7;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // phraseTextBox
            // 
            this.phraseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.phraseTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.phraseTextBox.Location = new System.Drawing.Point(100, 167);
            this.phraseTextBox.Name = "phraseTextBox";
            this.phraseTextBox.Size = new System.Drawing.Size(325, 23);
            this.phraseTextBox.TabIndex = 5;
            this.phraseTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // lowerBound
            // 
            this.lowerBound.Location = new System.Drawing.Point(100, 167);
            this.lowerBound.Name = "lowerBound";
            this.lowerBound.Size = new System.Drawing.Size(100, 23);
            this.lowerBound.TabIndex = 5;
            this.lowerBound.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // upperBound
            // 
            this.upperBound.Location = new System.Drawing.Point(236, 167);
            this.upperBound.Name = "upperBound";
            this.upperBound.Size = new System.Drawing.Size(100, 23);
            this.upperBound.TabIndex = 6;
            this.upperBound.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(206, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(23, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Search Term";
            // 
            // foundFiles
            // 
            this.foundFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foundFiles.ContextMenuStrip = this.fileItemCM;
            this.foundFiles.FormattingEnabled = true;
            this.foundFiles.HorizontalScrollbar = true;
            this.foundFiles.ItemHeight = 15;
            this.foundFiles.Location = new System.Drawing.Point(100, 314);
            this.foundFiles.Name = "foundFiles";
            this.foundFiles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.foundFiles.Size = new System.Drawing.Size(325, 94);
            this.foundFiles.TabIndex = 12;
            this.foundFiles.TabStop = false;
            this.foundFiles.DoubleClick += new System.EventHandler(this.foundFiles_DoubleClick);
            // 
            // fileItemCM
            // 
            this.fileItemCM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_file,
            this.open_explorer});
            this.fileItemCM.Name = "fileItemCM";
            this.fileItemCM.Size = new System.Drawing.Size(169, 48);
            this.fileItemCM.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fileItemCM_ItemClicked);
            // 
            // open_file
            // 
            this.open_file.Name = "open_file";
            this.open_file.Size = new System.Drawing.Size(168, 22);
            this.open_file.Text = "Open file";
            // 
            // open_explorer
            // 
            this.open_explorer.Name = "open_explorer";
            this.open_explorer.Size = new System.Drawing.Size(168, 22);
            this.open_explorer.Text = "Open file location";
            // 
            // notDetected
            // 
            this.notDetected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notDetected.FormattingEnabled = true;
            this.notDetected.HorizontalScrollbar = true;
            this.notDetected.ItemHeight = 15;
            this.notDetected.Location = new System.Drawing.Point(100, 539);
            this.notDetected.Name = "notDetected";
            this.notDetected.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.notDetected.Size = new System.Drawing.Size(325, 94);
            this.notDetected.TabIndex = 13;
            this.notDetected.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(14, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Detected Files";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(17, 539);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Not Detected";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(17, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Detected Files";
            // 
            // foundFilesPath
            // 
            this.foundFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foundFilesPath.ContextMenuStrip = this.fileItemCM;
            this.foundFilesPath.FormattingEnabled = true;
            this.foundFilesPath.HorizontalScrollbar = true;
            this.foundFilesPath.ItemHeight = 15;
            this.foundFilesPath.Location = new System.Drawing.Point(100, 428);
            this.foundFilesPath.Name = "foundFilesPath";
            this.foundFilesPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.foundFilesPath.Size = new System.Drawing.Size(325, 94);
            this.foundFilesPath.TabIndex = 16;
            this.foundFilesPath.TabStop = false;
            this.foundFilesPath.DoubleClick += new System.EventHandler(this.foundFilesPath_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(35, 443);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "(full path)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBar});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 641);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(458, 20);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBar
            // 
            this.statusBar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(39, 15);
            this.statusBar.Text = "Ready";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancelBtn.Location = new System.Drawing.Point(247, 244);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(25, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Search Type";
            // 
            // genFilesBtn
            // 
            this.genFilesBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.genFilesBtn.Location = new System.Drawing.Point(166, 273);
            this.genFilesBtn.Name = "genFilesBtn";
            this.genFilesBtn.Size = new System.Drawing.Size(156, 23);
            this.genFilesBtn.TabIndex = 22;
            this.genFilesBtn.Text = "Generate Files";
            this.genFilesBtn.UseVisualStyleBackColor = true;
            this.genFilesBtn.Click += new System.EventHandler(this.genFilesBtn_Click);
            // 
            // File_Finder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(458, 661);
            this.Controls.Add(this.genFilesBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.statusStrip1);
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
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchTermType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileTypesTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.recurCheckBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(474, 700);
            this.Name = "File_Finder";
            this.Text = "USS-UPI File Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.fileItemCM.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private Button searchBtn;
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
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusBar;
        private Button cancelBtn;
        private ContextMenuStrip fileItemCM;
        private ToolStripMenuItem open_file;
        private ToolStripMenuItem open_explorer;
        private Label label9;
        private Button genFilesBtn;
    }
}