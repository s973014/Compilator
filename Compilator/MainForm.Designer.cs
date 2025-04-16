using System.Drawing;
using System.Windows.Forms;

namespace Compilator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RepeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrammarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrammarClassificToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnalisysMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ErrorDiagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestExampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LiteratureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TestSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.text11 = new System.Windows.Forms.ToolStripMenuItem();
            this.text12 = new System.Windows.Forms.ToolStripMenuItem();
            this.text14 = new System.Windows.Forms.ToolStripMenuItem();
            this.text16 = new System.Windows.Forms.ToolStripMenuItem();
            this.text18 = new System.Windows.Forms.ToolStripMenuItem();
            this.text20 = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RussanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnglishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InfoButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.PasteButton = new System.Windows.Forms.Button();
            this.CutButton = new System.Windows.Forms.Button();
            this.CopyButton = new System.Windows.Forms.Button();
            this.RepeatButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.CreateFileButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.SettingsToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1622, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.CloseFileToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(69, 29);
            this.toolStripMenuItem1.Tag = "toolStripMenuItem1";
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.CreateToolStripMenuItem.Tag = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.Text = "Создать";
            this.CreateToolStripMenuItem.Click += new System.EventHandler(this.CreateToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.SaveAsToolStripMenuItem.Text = "Сохранить как";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // CloseFileToolStripMenuItem
            // 
            this.CloseFileToolStripMenuItem.Name = "CloseFileToolStripMenuItem";
            this.CloseFileToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.CloseFileToolStripMenuItem.Text = "Закрыть файл";
            this.CloseFileToolStripMenuItem.Click += new System.EventHandler(this.CloseFileToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelToolStripMenuItem,
            this.RepeatToolStripMenuItem,
            this.CutToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.SelectAllToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(89, 29);
            this.toolStripMenuItem2.Text = "Правка";
            // 
            // CancelToolStripMenuItem
            // 
            this.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem";
            this.CancelToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.CancelToolStripMenuItem.Text = "Отменить";
            // 
            // RepeatToolStripMenuItem
            // 
            this.RepeatToolStripMenuItem.Name = "RepeatToolStripMenuItem";
            this.RepeatToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.RepeatToolStripMenuItem.Text = "Повторить";
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.CutToolStripMenuItem.Text = "Вырезать";
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.CopyToolStripMenuItem.Text = "Копировать";
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.PasteToolStripMenuItem.Text = "Вставить";
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.DeleteToolStripMenuItem.Text = "Удалить";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.SelectAllToolStripMenuItem.Text = "Выделить все";
            this.SelectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TaskToolStripMenuItem,
            this.GrammarToolStripMenuItem,
            this.GrammarClassificToolStripMenuItem,
            this.AnalisysMethodToolStripMenuItem,
            this.ErrorDiagToolStripMenuItem,
            this.TestExampleToolStripMenuItem,
            this.LiteratureToolStripMenuItem,
            this.CodeToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(70, 29);
            this.toolStripMenuItem3.Text = "Текст";
            // 
            // TaskToolStripMenuItem
            // 
            this.TaskToolStripMenuItem.Name = "TaskToolStripMenuItem";
            this.TaskToolStripMenuItem.Size = new System.Drawing.Size(428, 34);
            this.TaskToolStripMenuItem.Text = "Постановка задачи";
            this.TaskToolStripMenuItem.Click += new System.EventHandler(this.TaskToolStripMenuItem_Click);
            // 
            // GrammarToolStripMenuItem
            // 
            this.GrammarToolStripMenuItem.Name = "GrammarToolStripMenuItem";
            this.GrammarToolStripMenuItem.Size = new System.Drawing.Size(428, 34);
            this.GrammarToolStripMenuItem.Text = "Грамматика";
            this.GrammarToolStripMenuItem.Click += new System.EventHandler(this.GrammarToolStripMenuItem_Click);
            // 
            // GrammarClassificToolStripMenuItem
            // 
            this.GrammarClassificToolStripMenuItem.Name = "GrammarClassificToolStripMenuItem";
            this.GrammarClassificToolStripMenuItem.Size = new System.Drawing.Size(428, 34);
            this.GrammarClassificToolStripMenuItem.Text = "Классификация грамматики";
            this.GrammarClassificToolStripMenuItem.Click += new System.EventHandler(this.GrammarClassificToolStripMenuItem_Click);
            // 
            // AnalisysMethodToolStripMenuItem
            // 
            this.AnalisysMethodToolStripMenuItem.Name = "AnalisysMethodToolStripMenuItem";
            this.AnalisysMethodToolStripMenuItem.Size = new System.Drawing.Size(428, 34);
            this.AnalisysMethodToolStripMenuItem.Text = "Метод анализа";
            this.AnalisysMethodToolStripMenuItem.Click += new System.EventHandler(this.AnalisysMethodToolStripMenuItem_Click);
            // 
            // ErrorDiagToolStripMenuItem
            // 
            this.ErrorDiagToolStripMenuItem.Name = "ErrorDiagToolStripMenuItem";
            this.ErrorDiagToolStripMenuItem.Size = new System.Drawing.Size(428, 34);
            this.ErrorDiagToolStripMenuItem.Text = "Диагностика и нейтрализация ошибок";
            this.ErrorDiagToolStripMenuItem.Click += new System.EventHandler(this.ErrorDiagToolStripMenuItem_Click);
            // 
            // TestExampleToolStripMenuItem
            // 
            this.TestExampleToolStripMenuItem.Name = "TestExampleToolStripMenuItem";
            this.TestExampleToolStripMenuItem.Size = new System.Drawing.Size(428, 34);
            this.TestExampleToolStripMenuItem.Text = "Тестовый пример";
            this.TestExampleToolStripMenuItem.Click += new System.EventHandler(this.TestExampleToolStripMenuItem_Click);
            // 
            // LiteratureToolStripMenuItem
            // 
            this.LiteratureToolStripMenuItem.Name = "LiteratureToolStripMenuItem";
            this.LiteratureToolStripMenuItem.Size = new System.Drawing.Size(428, 34);
            this.LiteratureToolStripMenuItem.Text = "Список литературы";
            this.LiteratureToolStripMenuItem.Click += new System.EventHandler(this.LiteratureToolStripMenuItem_Click);
            // 
            // CodeToolStripMenuItem
            // 
            this.CodeToolStripMenuItem.Name = "CodeToolStripMenuItem";
            this.CodeToolStripMenuItem.Size = new System.Drawing.Size(428, 34);
            this.CodeToolStripMenuItem.Text = "Исходный код программы";
            this.CodeToolStripMenuItem.Click += new System.EventHandler(this.CodeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(67, 29);
            this.toolStripMenuItem4.Text = "Пуск";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowContentsToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(97, 29);
            this.toolStripMenuItem5.Text = "Справка";
            // 
            // ShowContentsToolStripMenuItem
            // 
            this.ShowContentsToolStripMenuItem.Name = "ShowContentsToolStripMenuItem";
            this.ShowContentsToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.ShowContentsToolStripMenuItem.Text = "Вызов справки";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.AboutToolStripMenuItem.Text = "О программе";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // SettingsToolStripMenuItem1
            // 
            this.SettingsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestSizeToolStripMenuItem,
            this.LanguageToolStripMenuItem});
            this.SettingsToolStripMenuItem1.Name = "SettingsToolStripMenuItem1";
            this.SettingsToolStripMenuItem1.Size = new System.Drawing.Size(123, 29);
            this.SettingsToolStripMenuItem1.Text = "Параметры";
            // 
            // TestSizeToolStripMenuItem
            // 
            this.TestSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.text11,
            this.text12,
            this.text14,
            this.text16,
            this.text18,
            this.text20});
            this.TestSizeToolStripMenuItem.Name = "TestSizeToolStripMenuItem";
            this.TestSizeToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.TestSizeToolStripMenuItem.Text = "Размер текста";
            // 
            // text11
            // 
            this.text11.Name = "text11";
            this.text11.Size = new System.Drawing.Size(134, 34);
            this.text11.Text = "11";
            this.text11.Click += new System.EventHandler(this.text11_Click);
            // 
            // text12
            // 
            this.text12.Name = "text12";
            this.text12.Size = new System.Drawing.Size(134, 34);
            this.text12.Text = "12";
            this.text12.Click += new System.EventHandler(this.text12_Click);
            // 
            // text14
            // 
            this.text14.Name = "text14";
            this.text14.Size = new System.Drawing.Size(134, 34);
            this.text14.Text = "14";
            this.text14.Click += new System.EventHandler(this.text14_Click);
            // 
            // text16
            // 
            this.text16.Name = "text16";
            this.text16.Size = new System.Drawing.Size(134, 34);
            this.text16.Text = "16";
            this.text16.Click += new System.EventHandler(this.text16_Click);
            // 
            // text18
            // 
            this.text18.Name = "text18";
            this.text18.Size = new System.Drawing.Size(134, 34);
            this.text18.Text = "18";
            this.text18.Click += new System.EventHandler(this.text18_Click);
            // 
            // text20
            // 
            this.text20.Name = "text20";
            this.text20.Size = new System.Drawing.Size(134, 34);
            this.text20.Text = "20";
            this.text20.Click += new System.EventHandler(this.text20_Click);
            // 
            // LanguageToolStripMenuItem
            // 
            this.LanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RussanToolStripMenuItem,
            this.EnglishToolStripMenuItem});
            this.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
            this.LanguageToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.LanguageToolStripMenuItem.Text = "Язык";
            // 
            // RussanToolStripMenuItem
            // 
            this.RussanToolStripMenuItem.Name = "RussanToolStripMenuItem";
            this.RussanToolStripMenuItem.Size = new System.Drawing.Size(209, 34);
            this.RussanToolStripMenuItem.Text = "Русский";
            this.RussanToolStripMenuItem.Click += new System.EventHandler(this.RussanToolStripMenuItem_Click);
            // 
            // EnglishToolStripMenuItem
            // 
            this.EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem";
            this.EnglishToolStripMenuItem.Size = new System.Drawing.Size(209, 34);
            this.EnglishToolStripMenuItem.Text = "Английский";
            this.EnglishToolStripMenuItem.Click += new System.EventHandler(this.EnglishToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InfoButton);
            this.panel1.Controls.Add(this.AboutButton);
            this.panel1.Controls.Add(this.RunButton);
            this.panel1.Controls.Add(this.PasteButton);
            this.panel1.Controls.Add(this.CutButton);
            this.panel1.Controls.Add(this.CopyButton);
            this.panel1.Controls.Add(this.RepeatButton);
            this.panel1.Controls.Add(this.ReturnButton);
            this.panel1.Controls.Add(this.SaveFileButton);
            this.panel1.Controls.Add(this.OpenFileButton);
            this.panel1.Controls.Add(this.CreateFileButton);
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1619, 73);
            this.panel1.TabIndex = 1;
            // 
            // InfoButton
            // 
            this.InfoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InfoButton.BackgroundImage")));
            this.InfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InfoButton.Location = new System.Drawing.Point(783, 2);
            this.InfoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(72, 66);
            this.InfoButton.TabIndex = 0;
            this.InfoButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AboutButton.BackgroundImage")));
            this.AboutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AboutButton.Location = new System.Drawing.Point(705, 2);
            this.AboutButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(72, 66);
            this.AboutButton.TabIndex = 0;
            this.AboutButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RunButton.BackgroundImage")));
            this.RunButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RunButton.Location = new System.Drawing.Point(627, 2);
            this.RunButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(72, 66);
            this.RunButton.TabIndex = 0;
            this.RunButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // PasteButton
            // 
            this.PasteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PasteButton.BackgroundImage")));
            this.PasteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PasteButton.Location = new System.Drawing.Point(549, 2);
            this.PasteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PasteButton.Name = "PasteButton";
            this.PasteButton.Size = new System.Drawing.Size(72, 66);
            this.PasteButton.TabIndex = 0;
            this.PasteButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.PasteButton.UseVisualStyleBackColor = true;
            this.PasteButton.Click += new System.EventHandler(this.PasteButton_Click);
            // 
            // CutButton
            // 
            this.CutButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CutButton.BackgroundImage")));
            this.CutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CutButton.Location = new System.Drawing.Point(471, 2);
            this.CutButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CutButton.Name = "CutButton";
            this.CutButton.Size = new System.Drawing.Size(72, 66);
            this.CutButton.TabIndex = 0;
            this.CutButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.CutButton.UseVisualStyleBackColor = true;
            this.CutButton.Click += new System.EventHandler(this.CutButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CopyButton.BackgroundImage")));
            this.CopyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyButton.Location = new System.Drawing.Point(393, 2);
            this.CopyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(72, 66);
            this.CopyButton.TabIndex = 0;
            this.CopyButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // RepeatButton
            // 
            this.RepeatButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RepeatButton.BackgroundImage")));
            this.RepeatButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RepeatButton.Location = new System.Drawing.Point(315, 2);
            this.RepeatButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RepeatButton.Name = "RepeatButton";
            this.RepeatButton.Size = new System.Drawing.Size(72, 66);
            this.RepeatButton.TabIndex = 0;
            this.RepeatButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.RepeatButton.UseVisualStyleBackColor = true;
            this.RepeatButton.Click += new System.EventHandler(this.RepeatButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ReturnButton.BackgroundImage")));
            this.ReturnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReturnButton.Location = new System.Drawing.Point(237, 2);
            this.ReturnButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(72, 66);
            this.ReturnButton.TabIndex = 0;
            this.ReturnButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveFileButton.BackgroundImage")));
            this.SaveFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveFileButton.Location = new System.Drawing.Point(159, 2);
            this.SaveFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(72, 66);
            this.SaveFileButton.TabIndex = 0;
            this.SaveFileButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.SaveFileButton.UseVisualStyleBackColor = true;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.BackgroundImage")));
            this.OpenFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenFileButton.Location = new System.Drawing.Point(81, 2);
            this.OpenFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(72, 66);
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.OpenFileButton.UseVisualStyleBackColor = true;
            // 
            // CreateFileButton
            // 
            this.CreateFileButton.AccessibleDescription = "";
            this.CreateFileButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CreateFileButton.BackgroundImage")));
            this.CreateFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreateFileButton.Location = new System.Drawing.Point(3, 2);
            this.CreateFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateFileButton.Name = "CreateFileButton";
            this.CreateFileButton.Size = new System.Drawing.Size(72, 66);
            this.CreateFileButton.TabIndex = 0;
            this.CreateFileButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.CreateFileButton.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Cascadia Mono", 14F);
            this.richTextBox1.Location = new System.Drawing.Point(64, 2);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1537, 398);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox3);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(1605, 626);
            this.splitContainer1.SplitterDistance = 402;
            this.splitContainer1.SplitterWidth = 12;
            this.splitContainer1.TabIndex = 2;
            // 
            // richTextBox3
            // 
            this.richTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox3.Enabled = false;
            this.richTextBox3.Font = new System.Drawing.Font("Cascadia Mono", 14F);
            this.richTextBox3.Location = new System.Drawing.Point(3, 2);
            this.richTextBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(69, 398);
            this.richTextBox3.TabIndex = 0;
            this.richTextBox3.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(0, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 62;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(1603, 193);
            this.dataGridView1.TabIndex = 1;
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 30);
            this.tabControl1.Location = new System.Drawing.Point(3, 112);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1619, 668);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1611, 630);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Новый документ *";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 500;
            this.toolTip1.ShowAlways = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1622, 779);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(812, 679);
            this.Name = "MainForm";
            this.Text = "Compiler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem CreateToolStripMenuItem;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem SaveAsToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem CancelToolStripMenuItem;
        private ToolStripMenuItem RepeatToolStripMenuItem;
        private ToolStripMenuItem CutToolStripMenuItem;
        private ToolStripMenuItem CopyToolStripMenuItem;
        private ToolStripMenuItem PasteToolStripMenuItem;
        private ToolStripMenuItem DeleteToolStripMenuItem;
        private ToolStripMenuItem SelectAllToolStripMenuItem;
        private ToolStripMenuItem TaskToolStripMenuItem;
        private ToolStripMenuItem GrammarToolStripMenuItem;
        private ToolStripMenuItem GrammarClassificToolStripMenuItem;
        private ToolStripMenuItem AnalisysMethodToolStripMenuItem;
        private ToolStripMenuItem ErrorDiagToolStripMenuItem;
        private ToolStripMenuItem TestExampleToolStripMenuItem;
        private ToolStripMenuItem LiteratureToolStripMenuItem;
        private ToolStripMenuItem CodeToolStripMenuItem;
        private ToolStripMenuItem ShowContentsToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private Panel panel1;
        private RichTextBox richTextBox1;
        private Button CreateFileButton;
        private Button OpenFileButton;
        private Button ReturnButton;
        private Button SaveFileButton;
        private Button RepeatButton;
        private Button CopyButton;
        private Button CutButton;
        private Button RunButton;
        private Button PasteButton;
        private Button AboutButton;
        private Button InfoButton;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem SettingsToolStripMenuItem1;
        private ToolStripMenuItem TestSizeToolStripMenuItem;
        private ToolStripMenuItem LanguageToolStripMenuItem;
        private ToolStripMenuItem параметрыToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ToolStripMenuItem CloseFileToolStripMenuItem;
        private ToolStripMenuItem text11;
        private ToolStripMenuItem text12;
        private ToolStripMenuItem text14;
        private ToolStripMenuItem text16;
        private ToolStripMenuItem text18;
        private ToolStripMenuItem text20;
        private ToolStripMenuItem RussanToolStripMenuItem;
        private ToolStripMenuItem EnglishToolStripMenuItem;
        private ToolTip toolTip1;
        private RichTextBox richTextBox3;
        private DataGridView dataGridView1;
    }
}
