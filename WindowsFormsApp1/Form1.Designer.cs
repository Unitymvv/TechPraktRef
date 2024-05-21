namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Archive = new System.Windows.Forms.ToolStripMenuItem();
            this.Unzip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Encode = new System.Windows.Forms.ToolStripMenuItem();
            this.Decode = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFile,
            this.ClearFile,
            this.deleteToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // AddFile
            // 
            this.AddFile.Name = "AddFile";
            this.AddFile.Size = new System.Drawing.Size(101, 22);
            this.AddFile.Text = "Add";
            this.AddFile.Click += new System.EventHandler(this.AddFile_Click);
            // 
            // ClearFile
            // 
            this.ClearFile.Name = "ClearFile";
            this.ClearFile.Size = new System.Drawing.Size(101, 22);
            this.ClearFile.Text = "Clear";
            this.ClearFile.Click += new System.EventHandler(this.ClearFile_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Archive,
            this.Unzip});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(87, 20);
            this.toolStripMenuItem2.Text = "Архівування";
            // 
            // Archive
            // 
            this.Archive.Name = "Archive";
            this.Archive.Size = new System.Drawing.Size(151, 22);
            this.Archive.Text = "Архівувати";
            this.Archive.Click += new System.EventHandler(this.Archive_Click);
            // 
            // Unzip
            // 
            this.Unzip.Name = "Unzip";
            this.Unzip.Size = new System.Drawing.Size(151, 22);
            this.Unzip.Text = "Розархівувати";
            this.Unzip.Click += new System.EventHandler(this.Unzip_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Encode,
            this.Decode});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(91, 20);
            this.toolStripMenuItem3.Text = "Шифрування";
            // 
            // Encode
            // 
            this.Encode.Name = "Encode";
            this.Encode.Size = new System.Drawing.Size(157, 22);
            this.Encode.Text = "Шифрувати";
            this.Encode.Click += new System.EventHandler(this.Encode_Click);
            // 
            // Decode
            // 
            this.Decode.Name = "Decode";
            this.Decode.Size = new System.Drawing.Size(157, 22);
            this.Decode.Text = "Розшифрувати";
            this.Decode.Click += new System.EventHandler(this.Decode_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(776, 407);
            this.listBox1.TabIndex = 1;
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem AddFile;
        private System.Windows.Forms.ToolStripMenuItem ClearFile;
        private System.Windows.Forms.ToolStripMenuItem Archive;
        private System.Windows.Forms.ToolStripMenuItem Unzip;
        private System.Windows.Forms.ToolStripMenuItem Encode;
        private System.Windows.Forms.ToolStripMenuItem Decode;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

