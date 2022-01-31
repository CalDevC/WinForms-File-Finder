namespace File_Finder
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
            this.SuspendLayout();
            // 
            // recurCheckBox
            // 
            this.recurCheckBox.AutoSize = true;
            this.recurCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recurCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recurCheckBox.Location = new System.Drawing.Point(273, 228);
            this.recurCheckBox.Name = "recurCheckBox";
            this.recurCheckBox.Size = new System.Drawing.Size(120, 20);
            this.recurCheckBox.TabIndex = 0;
            this.recurCheckBox.Text = "Recursive Search";
            this.recurCheckBox.UseVisualStyleBackColor = true;
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pathTextBox.Location = new System.Drawing.Point(273, 110);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(325, 23);
            this.pathTextBox.TabIndex = 1;
            this.pathTextBox.TextChanged += new System.EventHandler(this.pathTextBox_Change);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(198, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(210, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "File Types";
            // 
            // fileTypesTextBox
            // 
            this.fileTypesTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileTypesTextBox.Location = new System.Drawing.Point(273, 149);
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
            this.searchTermType.Location = new System.Drawing.Point(273, 189);
            this.searchTermType.Name = "searchTermType";
            this.searchTermType.Size = new System.Drawing.Size(325, 23);
            this.searchTermType.TabIndex = 5;
            this.searchTermType.SelectedIndexChanged += new System.EventHandler(this.searchTermType_Change);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 346);
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
            this.phraseTextBox.Location = new System.Drawing.Point(273, 254);
            this.phraseTextBox.Name = "phraseTextBox";
            this.phraseTextBox.Size = new System.Drawing.Size(325, 23);
            this.phraseTextBox.TabIndex = 7;
            // 
            // lowerBound
            // 
            this.lowerBound.Location = new System.Drawing.Point(273, 254);
            this.lowerBound.Name = "lowerBound";
            this.lowerBound.Size = new System.Drawing.Size(100, 23);
            this.lowerBound.TabIndex = 8;
            // 
            // upperBound
            // 
            this.upperBound.Location = new System.Drawing.Point(409, 254);
            this.upperBound.Name = "upperBound";
            this.upperBound.Size = new System.Drawing.Size(100, 23);
            this.upperBound.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(379, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(196, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Search Term";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "Form1";
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
    }
}