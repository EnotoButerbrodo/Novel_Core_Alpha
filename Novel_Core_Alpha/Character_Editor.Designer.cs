namespace Novel_Core_Alpha
{
    partial class Character_Editor
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
            this.CharaterName_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddCharacter_button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateNewFile_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Chr_box = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.Chr_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // CharaterName_textbox
            // 
            this.CharaterName_textbox.Location = new System.Drawing.Point(9, 42);
            this.CharaterName_textbox.Name = "CharaterName_textbox";
            this.CharaterName_textbox.Size = new System.Drawing.Size(141, 20);
            this.CharaterName_textbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя";
            // 
            // AddCharacter_button
            // 
            this.AddCharacter_button.Location = new System.Drawing.Point(695, 382);
            this.AddCharacter_button.Name = "AddCharacter_button";
            this.AddCharacter_button.Size = new System.Drawing.Size(75, 23);
            this.AddCharacter_button.TabIndex = 3;
            this.AddCharacter_button.Text = "Добавить";
            this.AddCharacter_button.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateNewFile_menu,
            this.OpenFile_menu});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // CreateNewFile_menu
            // 
            this.CreateNewFile_menu.Name = "CreateNewFile_menu";
            this.CreateNewFile_menu.Size = new System.Drawing.Size(180, 22);
            this.CreateNewFile_menu.Text = "Создать";
            this.CreateNewFile_menu.Click += new System.EventHandler(this.CreateNewFile_menu_Click);
            // 
            // OpenFile_menu
            // 
            this.OpenFile_menu.Name = "OpenFile_menu";
            this.OpenFile_menu.Size = new System.Drawing.Size(180, 22);
            this.OpenFile_menu.Text = "Открыть";
            this.OpenFile_menu.Click += new System.EventHandler(this.OpenFile_menu_Click);
            // 
            // Chr_box
            // 
            this.Chr_box.Controls.Add(this.label1);
            this.Chr_box.Controls.Add(this.CharaterName_textbox);
            this.Chr_box.Controls.Add(this.AddCharacter_button);
            this.Chr_box.Location = new System.Drawing.Point(12, 27);
            this.Chr_box.Name = "Chr_box";
            this.Chr_box.Size = new System.Drawing.Size(776, 411);
            this.Chr_box.TabIndex = 5;
            this.Chr_box.TabStop = false;
            this.Chr_box.Text = "Персонаж";
            // 
            // Character_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Chr_box);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Character_Editor";
            this.Text = "Character_Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Chr_box.ResumeLayout(false);
            this.Chr_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CharaterName_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddCharacter_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateNewFile_menu;
        private System.Windows.Forms.ToolStripMenuItem OpenFile_menu;
        private System.Windows.Forms.GroupBox Chr_box;
    }
}