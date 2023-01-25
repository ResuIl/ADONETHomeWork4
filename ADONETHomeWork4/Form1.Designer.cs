namespace ADONETHomeWork4
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
            this.cBox_Categories = new System.Windows.Forms.ComboBox();
            this.cBox_Authors = new System.Windows.Forms.ComboBox();
            this.tBox_Search = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cBox_Categories
            // 
            this.cBox_Categories.FormattingEnabled = true;
            this.cBox_Categories.Location = new System.Drawing.Point(12, 12);
            this.cBox_Categories.Name = "cBox_Categories";
            this.cBox_Categories.Size = new System.Drawing.Size(192, 23);
            this.cBox_Categories.TabIndex = 0;
            this.cBox_Categories.SelectedIndexChanged += new System.EventHandler(this.cBox_Categories_SelectedIndexChanged);
            // 
            // cBox_Authors
            // 
            this.cBox_Authors.Enabled = false;
            this.cBox_Authors.FormattingEnabled = true;
            this.cBox_Authors.Location = new System.Drawing.Point(210, 12);
            this.cBox_Authors.Name = "cBox_Authors";
            this.cBox_Authors.Size = new System.Drawing.Size(192, 23);
            this.cBox_Authors.TabIndex = 1;
            this.cBox_Authors.SelectedIndexChanged += new System.EventHandler(this.cBox_Authors_SelectedIndexChanged);
            // 
            // tBox_Search
            // 
            this.tBox_Search.Enabled = false;
            this.tBox_Search.Location = new System.Drawing.Point(408, 12);
            this.tBox_Search.Name = "tBox_Search";
            this.tBox_Search.Size = new System.Drawing.Size(380, 23);
            this.tBox_Search.TabIndex = 2;
            this.tBox_Search.TextChanged += new System.EventHandler(this.tBox_Search_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(776, 397);
            this.dataGridView1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tBox_Search);
            this.Controls.Add(this.cBox_Authors);
            this.Controls.Add(this.cBox_Categories);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cBox_Categories;
        private ComboBox cBox_Authors;
        private TextBox tBox_Search;
        private DataGridView dataGridView1;
    }
}