﻿namespace Novel_Core_Alpha
{
    partial class NC_Editor
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AddBackground_tab = new System.Windows.Forms.TabPage();
            this.SetBackground_button = new System.Windows.Forms.Button();
            this.Delete_background_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Backgrounds_previe = new System.Windows.Forms.PictureBox();
            this.Add_background_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Backgrounds_list = new System.Windows.Forms.ListBox();
            this.AddCharacter_tab = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Characters_combobox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ContenFolderSetPath_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ContentFolderPathStoke = new System.Windows.Forms.TextBox();
            this.ContantFolderStatus = new System.Windows.Forms.Label();
            this.SceneEditor_previe = new System.Windows.Forms.PictureBox();
            this.curr_scene_label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenScene_menu_button = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveScene_menu_button = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsNewScene_menu_button = new System.Windows.Forms.ToolStripMenuItem();
            this.FramesPanel = new System.Windows.Forms.Panel();
            this.Frame_previe = new System.Windows.Forms.ListBox();
            this.SelectedFrame = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.AddFrame_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Frame_text = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Zip_button = new System.Windows.Forms.Button();
            this.UnZip_button = new System.Windows.Forms.Button();
            this.ReadZip_button = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.AddBackground_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Backgrounds_previe)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.AddCharacter_tab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SceneEditor_previe)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AddBackground_tab);
            this.tabControl1.Controls.Add(this.AddCharacter_tab);
            this.tabControl1.Location = new System.Drawing.Point(12, 113);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(341, 479);
            this.tabControl1.TabIndex = 0;
            // 
            // AddBackground_tab
            // 
            this.AddBackground_tab.Controls.Add(this.SetBackground_button);
            this.AddBackground_tab.Controls.Add(this.Delete_background_button);
            this.AddBackground_tab.Controls.Add(this.label3);
            this.AddBackground_tab.Controls.Add(this.Backgrounds_previe);
            this.AddBackground_tab.Controls.Add(this.Add_background_button);
            this.AddBackground_tab.Controls.Add(this.groupBox1);
            this.AddBackground_tab.Location = new System.Drawing.Point(4, 22);
            this.AddBackground_tab.Name = "AddBackground_tab";
            this.AddBackground_tab.Padding = new System.Windows.Forms.Padding(3);
            this.AddBackground_tab.Size = new System.Drawing.Size(333, 453);
            this.AddBackground_tab.TabIndex = 0;
            this.AddBackground_tab.Text = "Задний фон";
            this.AddBackground_tab.UseVisualStyleBackColor = true;
            // 
            // SetBackground_button
            // 
            this.SetBackground_button.Location = new System.Drawing.Point(219, 252);
            this.SetBackground_button.Name = "SetBackground_button";
            this.SetBackground_button.Size = new System.Drawing.Size(75, 36);
            this.SetBackground_button.TabIndex = 7;
            this.SetBackground_button.Text = "Установить фон";
            this.SetBackground_button.UseVisualStyleBackColor = true;
            this.SetBackground_button.Click += new System.EventHandler(this.SetBackground_button_Click);
            // 
            // Delete_background_button
            // 
            this.Delete_background_button.BackColor = System.Drawing.Color.Gainsboro;
            this.Delete_background_button.FlatAppearance.BorderSize = 0;
            this.Delete_background_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_background_button.Location = new System.Drawing.Point(223, 191);
            this.Delete_background_button.Name = "Delete_background_button";
            this.Delete_background_button.Size = new System.Drawing.Size(71, 23);
            this.Delete_background_button.TabIndex = 7;
            this.Delete_background_button.Text = "Удалить";
            this.Delete_background_button.UseVisualStyleBackColor = false;
            this.Delete_background_button.Click += new System.EventHandler(this.Delete_background_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Предпросмотр";
            // 
            // Backgrounds_previe
            // 
            this.Backgrounds_previe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Backgrounds_previe.InitialImage = global::Novel_Core_Alpha.Properties.Resources.Image_wait;
            this.Backgrounds_previe.Location = new System.Drawing.Point(13, 16);
            this.Backgrounds_previe.Name = "Backgrounds_previe";
            this.Backgrounds_previe.Size = new System.Drawing.Size(314, 140);
            this.Backgrounds_previe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Backgrounds_previe.TabIndex = 3;
            this.Backgrounds_previe.TabStop = false;
            // 
            // Add_background_button
            // 
            this.Add_background_button.BackColor = System.Drawing.Color.Gainsboro;
            this.Add_background_button.FlatAppearance.BorderSize = 0;
            this.Add_background_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_background_button.Location = new System.Drawing.Point(223, 162);
            this.Add_background_button.Name = "Add_background_button";
            this.Add_background_button.Size = new System.Drawing.Size(71, 23);
            this.Add_background_button.TabIndex = 0;
            this.Add_background_button.Text = "Добавить";
            this.Add_background_button.UseVisualStyleBackColor = false;
            this.Add_background_button.Click += new System.EventHandler(this.Add_background_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Backgrounds_list);
            this.groupBox1.Location = new System.Drawing.Point(13, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 294);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Коллекция";
            // 
            // Backgrounds_list
            // 
            this.Backgrounds_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Backgrounds_list.FormattingEnabled = true;
            this.Backgrounds_list.Items.AddRange(new object[] {
            ""});
            this.Backgrounds_list.Location = new System.Drawing.Point(6, 19);
            this.Backgrounds_list.Name = "Backgrounds_list";
            this.Backgrounds_list.Size = new System.Drawing.Size(188, 262);
            this.Backgrounds_list.TabIndex = 2;
            this.Backgrounds_list.SelectedIndexChanged += new System.EventHandler(this.Backgrounds_list_SelectedIndexChanged);
            // 
            // AddCharacter_tab
            // 
            this.AddCharacter_tab.Controls.Add(this.listView2);
            this.AddCharacter_tab.Controls.Add(this.Characters_combobox);
            this.AddCharacter_tab.Location = new System.Drawing.Point(4, 22);
            this.AddCharacter_tab.Name = "AddCharacter_tab";
            this.AddCharacter_tab.Size = new System.Drawing.Size(333, 453);
            this.AddCharacter_tab.TabIndex = 1;
            this.AddCharacter_tab.Text = "Персонажи";
            this.AddCharacter_tab.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(3, 30);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(327, 420);
            this.listView2.TabIndex = 22;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Спрайт";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Имя";
            this.columnHeader2.Width = 200;
            // 
            // Characters_combobox
            // 
            this.Characters_combobox.FormattingEnabled = true;
            this.Characters_combobox.Items.AddRange(new object[] {
            "Хуй\t",
            "Пизда"});
            this.Characters_combobox.Location = new System.Drawing.Point(3, 3);
            this.Characters_combobox.Name = "Characters_combobox";
            this.Characters_combobox.Size = new System.Drawing.Size(202, 21);
            this.Characters_combobox.TabIndex = 20;
            this.Characters_combobox.SelectedIndexChanged += new System.EventHandler(this.Characters_combobox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ContenFolderSetPath_button);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ContentFolderPathStoke);
            this.groupBox2.Controls.Add(this.ContantFolderStatus);
            this.groupBox2.Location = new System.Drawing.Point(12, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 72);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Папка контента";
            // 
            // ContenFolderSetPath_button
            // 
            this.ContenFolderSetPath_button.BackColor = System.Drawing.Color.Gainsboro;
            this.ContenFolderSetPath_button.FlatAppearance.BorderSize = 0;
            this.ContenFolderSetPath_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContenFolderSetPath_button.Location = new System.Drawing.Point(6, 42);
            this.ContenFolderSetPath_button.Name = "ContenFolderSetPath_button";
            this.ContenFolderSetPath_button.Size = new System.Drawing.Size(67, 20);
            this.ContenFolderSetPath_button.TabIndex = 3;
            this.ContenFolderSetPath_button.Text = "Выбрать";
            this.ContenFolderSetPath_button.UseVisualStyleBackColor = false;
            this.ContenFolderSetPath_button.Click += new System.EventHandler(this.ContenFolderSetPath_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Статус: ";
            // 
            // ContentFolderPathStoke
            // 
            this.ContentFolderPathStoke.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContentFolderPathStoke.Location = new System.Drawing.Point(6, 19);
            this.ContentFolderPathStoke.Name = "ContentFolderPathStoke";
            this.ContentFolderPathStoke.ReadOnly = true;
            this.ContentFolderPathStoke.Size = new System.Drawing.Size(252, 20);
            this.ContentFolderPathStoke.TabIndex = 2;
            this.ContentFolderPathStoke.Text = "Папка не выбрана";
            this.ContentFolderPathStoke.TextChanged += new System.EventHandler(this.ContentFolderPathStoke_TextChanged);
            // 
            // ContantFolderStatus
            // 
            this.ContantFolderStatus.AutoSize = true;
            this.ContantFolderStatus.Location = new System.Drawing.Point(132, 42);
            this.ContantFolderStatus.Name = "ContantFolderStatus";
            this.ContantFolderStatus.Size = new System.Drawing.Size(0, 13);
            this.ContantFolderStatus.TabIndex = 4;
            // 
            // SceneEditor_previe
            // 
            this.SceneEditor_previe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SceneEditor_previe.Location = new System.Drawing.Point(361, 59);
            this.SceneEditor_previe.Name = "SceneEditor_previe";
            this.SceneEditor_previe.Size = new System.Drawing.Size(720, 400);
            this.SceneEditor_previe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SceneEditor_previe.TabIndex = 0;
            this.SceneEditor_previe.TabStop = false;
            // 
            // curr_scene_label
            // 
            this.curr_scene_label.AutoSize = true;
            this.curr_scene_label.Location = new System.Drawing.Point(352, 43);
            this.curr_scene_label.Name = "curr_scene_label";
            this.curr_scene_label.Size = new System.Drawing.Size(91, 13);
            this.curr_scene_label.TabIndex = 11;
            this.curr_scene_label.Text = "Текущая сцена: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenScene_menu_button,
            this.SaveScene_menu_button,
            this.SaveAsNewScene_menu_button});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // OpenScene_menu_button
            // 
            this.OpenScene_menu_button.Name = "OpenScene_menu_button";
            this.OpenScene_menu_button.Size = new System.Drawing.Size(228, 22);
            this.OpenScene_menu_button.Text = "Открыть сцену";
            this.OpenScene_menu_button.Click += new System.EventHandler(this.OpenScene_menu_button_Click);
            // 
            // SaveScene_menu_button
            // 
            this.SaveScene_menu_button.Name = "SaveScene_menu_button";
            this.SaveScene_menu_button.Size = new System.Drawing.Size(228, 22);
            this.SaveScene_menu_button.Text = "Сохранить сцену";
            this.SaveScene_menu_button.Click += new System.EventHandler(this.saveScene_menu_button_Click);
            // 
            // SaveAsNewScene_menu_button
            // 
            this.SaveAsNewScene_menu_button.Name = "SaveAsNewScene_menu_button";
            this.SaveAsNewScene_menu_button.Size = new System.Drawing.Size(228, 22);
            this.SaveAsNewScene_menu_button.Text = "Сохранить как новую сцену";
            this.SaveAsNewScene_menu_button.Click += new System.EventHandler(this.SaveAsNewScene_menu_button_Click);
            // 
            // FramesPanel
            // 
            this.FramesPanel.AutoScroll = true;
            this.FramesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FramesPanel.Location = new System.Drawing.Point(361, 568);
            this.FramesPanel.Name = "FramesPanel";
            this.FramesPanel.Size = new System.Drawing.Size(911, 150);
            this.FramesPanel.TabIndex = 16;
            // 
            // Frame_previe
            // 
            this.Frame_previe.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Frame_previe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Frame_previe.FormattingEnabled = true;
            this.Frame_previe.Location = new System.Drawing.Point(1087, 75);
            this.Frame_previe.Name = "Frame_previe";
            this.Frame_previe.Size = new System.Drawing.Size(192, 234);
            this.Frame_previe.TabIndex = 3;
            // 
            // SelectedFrame
            // 
            this.SelectedFrame.Enabled = false;
            this.SelectedFrame.Location = new System.Drawing.Point(441, 546);
            this.SelectedFrame.Name = "SelectedFrame";
            this.SelectedFrame.Size = new System.Drawing.Size(83, 20);
            this.SelectedFrame.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 548);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Текущий кадр";
            // 
            // AddFrame_button
            // 
            this.AddFrame_button.Location = new System.Drawing.Point(530, 544);
            this.AddFrame_button.Name = "AddFrame_button";
            this.AddFrame_button.Size = new System.Drawing.Size(106, 23);
            this.AddFrame_button.TabIndex = 18;
            this.AddFrame_button.Text = "Добавить кадр";
            this.AddFrame_button.UseVisualStyleBackColor = true;
            this.AddFrame_button.Click += new System.EventHandler(this.AddFrame_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1087, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Информация о кадре";
            // 
            // Frame_text
            // 
            this.Frame_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Frame_text.Location = new System.Drawing.Point(361, 455);
            this.Frame_text.Multiline = true;
            this.Frame_text.Name = "Frame_text";
            this.Frame_text.Size = new System.Drawing.Size(720, 83);
            this.Frame_text.TabIndex = 0;
            this.Frame_text.TextChanged += new System.EventHandler(this.Frame_text_TextChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Zip_button
            // 
            this.Zip_button.Location = new System.Drawing.Point(1090, 372);
            this.Zip_button.Name = "Zip_button";
            this.Zip_button.Size = new System.Drawing.Size(101, 51);
            this.Zip_button.TabIndex = 20;
            this.Zip_button.Text = "Архивировать";
            this.Zip_button.UseVisualStyleBackColor = true;
            this.Zip_button.Click += new System.EventHandler(this.Zip_button_Click);
            // 
            // UnZip_button
            // 
            this.UnZip_button.Location = new System.Drawing.Point(1197, 372);
            this.UnZip_button.Name = "UnZip_button";
            this.UnZip_button.Size = new System.Drawing.Size(82, 51);
            this.UnZip_button.TabIndex = 20;
            this.UnZip_button.Text = "Деархивировать";
            this.UnZip_button.UseVisualStyleBackColor = true;
            this.UnZip_button.Click += new System.EventHandler(this.UnZip_button_Click);
            // 
            // ReadZip_button
            // 
            this.ReadZip_button.Location = new System.Drawing.Point(1090, 429);
            this.ReadZip_button.Name = "ReadZip_button";
            this.ReadZip_button.Size = new System.Drawing.Size(101, 51);
            this.ReadZip_button.TabIndex = 20;
            this.ReadZip_button.Text = "Просмотр содержимого архива";
            this.ReadZip_button.UseVisualStyleBackColor = true;
            this.ReadZip_button.Click += new System.EventHandler(this.ReadZip_button_Click);
            // 
            // NC_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 721);
            this.Controls.Add(this.UnZip_button);
            this.Controls.Add(this.ReadZip_button);
            this.Controls.Add(this.Zip_button);
            this.Controls.Add(this.Frame_text);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AddFrame_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectedFrame);
            this.Controls.Add(this.Frame_previe);
            this.Controls.Add(this.FramesPanel);
            this.Controls.Add(this.curr_scene_label);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.SceneEditor_previe);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NC_Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NC_Editor";
            this.tabControl1.ResumeLayout(false);
            this.AddBackground_tab.ResumeLayout(false);
            this.AddBackground_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Backgrounds_previe)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.AddCharacter_tab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SceneEditor_previe)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AddBackground_tab;
        private System.Windows.Forms.Button Add_background_button;
        private System.Windows.Forms.ListBox Backgrounds_list;
        private System.Windows.Forms.TextBox ContentFolderPathStoke;
        private System.Windows.Forms.Button ContenFolderSetPath_button;
        private System.Windows.Forms.Label ContantFolderStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox Backgrounds_previe;
        private System.Windows.Forms.Button Delete_background_button;
        private System.Windows.Forms.PictureBox SceneEditor_previe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SetBackground_button;
        private System.Windows.Forms.Label curr_scene_label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenScene_menu_button;
        private System.Windows.Forms.ToolStripMenuItem SaveScene_menu_button;
        private System.Windows.Forms.ToolStripMenuItem SaveAsNewScene_menu_button;
        private System.Windows.Forms.Panel FramesPanel;
        private System.Windows.Forms.ListBox Frame_previe;
        private System.Windows.Forms.NumericUpDown SelectedFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddFrame_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage AddCharacter_tab;
        private System.Windows.Forms.TextBox Frame_text;
        private System.Windows.Forms.ComboBox Characters_combobox;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Zip_button;
        private System.Windows.Forms.Button UnZip_button;
        private System.Windows.Forms.Button ReadZip_button;
    }
}

