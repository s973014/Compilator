using Compilator;
using Compilator.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Resources;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static Compilator.POLIZLexer;
using static Compilator.POLIZParser;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;


namespace Compilator
{
    public partial class MainForm : Form
    {
        


        public List<Document> documents;


        public int index = 0;
        private bool change;
        private int fontsize = 14;
        private string SaveFileStr1 = "Сохранить файл";
        private string SaveFileStr2 = "Сохранение файла";
        private string FileSaved = "Файл успешно сохранен.";
        private string FileOpened = "Файл успешно открыт.";
        private string ErrorStr = "Ошибка";
        private string FileErrorStr = "Невозможно открыть файл.";


        private string lastText = "";

        public string containtment;
        public bool isCut;
        public bool isDelete;
        public bool isPaste;


        

        public MainForm()
        {

            InitializeComponent();
            richTextBox3.Clear();
            richTextBox3.Text = string.Empty;

            Document doc = new Document();
            doc.filename = "New File";
            tabControl1.TabPages[tabControl1.SelectedIndex].Text = "* " + doc.filename;
            doc.full_path = "";
            doc.rtb1_text = "";
            lastText = "";
            doc.tokens = new List<Token>();
            doc.errors = new List<Error>();
            doc.rtb3_text = "";
            doc.saved = true;
            doc.savedAs = false;

            Font commonFont = new Font("Times New Roman", 14);

            richTextBox1.Font = commonFont;

            richTextBox3.Font = commonFont;


            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



            /*
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                
                HeaderText = "",
                Width = 40,
                
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Path",
                HeaderText = "Путь",
                Width = 450
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Line",
                HeaderText = "Строка",
                Width = 85
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Column",
                HeaderText = "Колонка",
                Width = 90
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Message",
                HeaderText = "Сообщение",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            */

            //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            //{

            //    HeaderText = "",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,

            //});
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Position",
                HeaderText = "Местопложение",
                Width = 170,

            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Line",
                HeaderText = "Строка",
                Width = 100,
                

            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Column",
                HeaderText = "Столбец",
                Width = 100,

            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Message",
                HeaderText = "Сообщение",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            });
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(
                dataGridView1.Font.FontFamily,   
                dataGridView1.Font.Size,         
                FontStyle.Regular            
            );

            this.AllowDrop = true;
            richTextBox1.AllowDrop = true;

            richTextBox1.WordWrap = false;



            CreateFileButton.Click += CreateToolStripMenuItem_Click;
            OpenFileButton.Click += OpenToolStripMenuItem_Click;
            SaveFileButton.Click += SaveToolStripMenuItem_Click;

            CancelToolStripMenuItem.Click += ReturnButton_Click;
            RepeatToolStripMenuItem.Click += RepeatButton_Click;
            CutToolStripMenuItem.Click += CutButton_Click;
            CopyToolStripMenuItem.Click += CopyButton_Click;
            PasteToolStripMenuItem.Click += PasteButton_Click;
            InfoButton.Click += ShowContentsToolStripMenuItem_Click;
            ShowContentsToolStripMenuItem.Click += AboutButton_Click;

            toolStripMenuItem4.Click += RunButton_Click;


            richTextBox3.ReadOnly = true;
            richTextBox3.BackColor = richTextBox1.BackColor;
            richTextBox3.ForeColor = richTextBox1.ForeColor;
            richTextBox3.Font = richTextBox1.Font;
            richTextBox3.WordWrap = false;

            richTextBox3.ScrollBars = RichTextBoxScrollBars.None;

            documents = new List<Document>();



            richTextBox1.VScroll += RichTextBox1_VScroll;
            richTextBox1.TextChanged += RichTextBox1_TextChanged;

            richTextBox1.DragEnter += new DragEventHandler(MainForm_DragEnter);
            richTextBox1.DragDrop += new DragEventHandler(MainForm_DragDrop);



            UpdateLineNumbers();

            this.documents.Add(doc);


            saveFileDialog1.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";



            toolTip1.SetToolTip(this.CreateFileButton, "Создать");
            toolTip1.SetToolTip(this.OpenFileButton, "Открыть");
            toolTip1.SetToolTip(this.SaveFileButton, "Сохранить");
            toolTip1.SetToolTip(this.ReturnButton, "Отменить");
            toolTip1.SetToolTip(this.RepeatButton, "Повторить");
            toolTip1.SetToolTip(this.CopyButton, "Копировать");
            toolTip1.SetToolTip(this.CutButton, "Вырезать");
            toolTip1.SetToolTip(this.PasteButton, "Вставить");
            toolTip1.SetToolTip(this.RunButton, "Пуск");
            toolTip1.SetToolTip(this.AboutButton, "Вызов справки");
            toolTip1.SetToolTip(this.InfoButton, "О программе");

        }




        private void UpdateLineNumbers()
        {
            try
            {
                int lineCount = richTextBox1.Lines.Length;
                richTextBox3.Text = "";
                for (int i = 1; i <= lineCount; i++)
                {
                    richTextBox3.Text += i + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                UpdateLineNumbers();
                //HighlighSyntax(richTextBox1);

                int firstVisibleLine = richTextBox1.GetLineFromCharIndex(richTextBox1.GetCharIndexFromPosition(new Point(0, 0)));
                richTextBox3.SelectionStart = richTextBox3.GetFirstCharIndexFromLine(firstVisibleLine);
                richTextBox3.ScrollToCaret();

                int index = tabControl1.SelectedIndex;

                if (change)
                {
                    change = false;
                    return;
                }

                if (index >= 0)
                {
                    if (documents[index].saved == true)
                    {
                        documents[index].saved = false;
                        tabControl1.TabPages[tabControl1.SelectedIndex].Text = "* " + documents[tabControl1.SelectedIndex].filename;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                if (!richTextBox1.Focused) return;

                string newText = richTextBox1.Text;
                int cursorPos = richTextBox1.SelectionStart;

                if (lastText == null) lastText = "";
                if (newText.Length > lastText.Length)
                {
                    int diff = newText.Length - lastText.Length;
                    string insertedText = newText.Substring(cursorPos - (newText.Length - lastText.Length), newText.Length - lastText.Length);
                    if (diff == 1)
                    {
                        containtment = insertedText;
                        isCut = false;
                        isDelete = false;
                        isPaste = false;
                    }
                    else
                    {
                        containtment = insertedText;
                        isCut = false;
                        isDelete = false;
                        isPaste = true;


                    }
                }
                else if (newText.Length < lastText.Length)
                {
                    int diff = lastText.Length - newText.Length;
                    string deletedText = lastText.Substring(cursorPos, diff);
                    if (diff == 1)
                    {
                        containtment = deletedText;
                        isCut = false;
                        isDelete = true;
                        isPaste = false;

                    }
                    else
                    {
                        containtment = null;
                        isCut = false;
                        isDelete = false;
                        isPaste = false;

                    }
                }
                lastText = newText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RichTextBox1_VScroll(object sender, EventArgs e)
        {

            try
            {
                int firstVisibleLine = richTextBox1.GetLineFromCharIndex(richTextBox1.GetCharIndexFromPosition(new Point(0, 0)));
                richTextBox3.SelectionStart = richTextBox3.GetFirstCharIndexFromLine(firstVisibleLine);
                richTextBox3.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }




        private void AddNewTabPage(string filename)
        {

            try
            {
                TabPage newTab = new TabPage(filename);
                newTab.Controls.Add(this.splitContainer1);
                tabControl1.TabPages.Add(newTab);
                splitContainer1.SplitterDistance = tabControl1.Height / 2;

                tabControl1.SelectedTab = newTab;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }




        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Document doc = new Document();
                doc.filename = "New File";
                doc.saved = false;
                doc.savedAs = false;
                doc.tokens = new List<Token>();
                doc.errors = new List<Error>();
                this.documents.Add(doc);
                AddNewTabPage("* New File");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            /*
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, "");
            this.Text = "Compiler" + saveFileDialog1.FileName;
            this.filename = filename;
            MessageBox.Show("Файл успешно создан.");
            */
        }



        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SaveFile()
        {

            try
            {
                //MessageBox.Show(Convert.ToString(documents.Count));
                if (documents[tabControl1.SelectedIndex].full_path != "" && documents[tabControl1.SelectedIndex].full_path != null)
                {
                    System.IO.File.WriteAllText(documents[tabControl1.SelectedIndex].full_path, richTextBox1.Text);
                    //MessageBox.Show("Файл успешно сохранен.");
                    documents[tabControl1.SelectedIndex].saved = true;
                    tabControl1.TabPages[tabControl1.SelectedIndex].Text = documents[tabControl1.SelectedIndex].filename;
                }
                else
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;

                    string filepath = saveFileDialog1.FileName;
                    string filename = Path.GetFileName(saveFileDialog1.FileName);
                    
                    documents[tabControl1.SelectedIndex].full_path = filepath;
                    documents[tabControl1.SelectedIndex].filename = filename;
                    tabControl1.TabPages[tabControl1.SelectedIndex].Text = filename;


                    System.IO.File.WriteAllText(filepath, richTextBox1.Text);
                    //MessageBox.Show("Файл успешно сохранен.");
                    documents[tabControl1.SelectedIndex].saved = true;
                    documents[tabControl1.SelectedIndex].savedAs = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void OpenFile()
        {

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                string filename = openFileDialog1.SafeFileName;

                string file_path = openFileDialog1.FileName;


                for (int i = 0; i < documents.Count; i++)
                {
                    if (documents[i].full_path == file_path)
                    {
                        tabControl1.SelectedIndex = i;
                        return;
                    }
                }




                string fileText = System.IO.File.ReadAllText(file_path);

                Document doc = new Document();

                doc.filename = filename;
                doc.full_path = file_path;
                doc.tokens = new List<Token>();
                doc.errors = new List<Error>();
                doc.rtb1_text = fileText;
                doc.saved = true;
                doc.savedAs = true;

                lastText = fileText;

                documents.Add(doc);

                AddNewTabPage(filename);

                UpdateLineNumbers();



                MessageBox.Show(FileOpened);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                string filepath = saveFileDialog1.FileName;
                string filename = Path.GetFileName(saveFileDialog1.FileName);

                documents[tabControl1.SelectedIndex].full_path = filepath;
                documents[tabControl1.SelectedIndex].filename = filename;
                tabControl1.TabPages[tabControl1.SelectedIndex].Text = filename;


                System.IO.File.WriteAllText(filepath, richTextBox1.Text);
                MessageBox.Show(FileSaved);
                documents[tabControl1.SelectedIndex].saved = true;
                documents[tabControl1.SelectedIndex].savedAs = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (var file in documents)
                {
                    if (file.saved == false)
                    {
                        DialogResult result = MessageBox.Show(
                            SaveFileStr1 + $" \"{file.filename}\"?",
                            SaveFileStr2,
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            SaveFile();
                        }
                        else if (result == DialogResult.No)
                        {

                        }
                        else
                        {
                            return;
                        }
                    }
                }


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (richTextBox1.CanUndo)
                {
                    richTextBox1.Undo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void RepeatButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (isDelete == false)
                {
                    int position = richTextBox1.SelectionStart;
                    if (containtment == null) return;
                    richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, containtment);
                    lastText = richTextBox1.Text;
                    richTextBox1.Focus();
                    richTextBox1.SelectionStart = position + containtment.Length;
                }
                else
                {
                    if (richTextBox1.SelectionStart > 0)
                    {
                        int position = richTextBox1.SelectionStart;
                        richTextBox1.Text = richTextBox1.Text.Remove(position - 1, 1);
                        lastText = richTextBox1.Text;
                        richTextBox1.Focus();
                        richTextBox1.SelectionStart = position - containtment.Length;
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Cut();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PasteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    richTextBox1.Paste();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.SelectedText.Length > 0)
                {
                    richTextBox1.SelectedText = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Document doc = new Document();

            doc.rtb1_text = richTextBox1.Text;

            doc.tokens = new List<Token>();
            doc.errors = new List<Error>();
            //doc.rtb2_text = richTextBox2.Text;


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var row = dataGridView1.Rows[i];

                var error = new Error()
                {
                    Position = row.Cells[0].Value?.ToString(),
                    Line = row.Cells[1].Value?.ToString(),
                    Column = row.Cells[2].Value?.ToString(),
                    Message = row.Cells[3].Value?.ToString()
                };

                doc.errors.Add(error);
            }



            doc.rtb3_text = richTextBox3.Text;



            tabControl1.TabPages[tabControl1.SelectedIndex].Controls.Add(this.splitContainer1);

            documents[this.index].rtb1_text = doc.rtb1_text;
            documents[this.index].errors = doc.errors;
            //AddErrsToDocs(this.index);
            documents[this.index].rtb3_text = doc.rtb3_text;

            //MessageBox.Show(Convert.ToString(documents[tabControl1.SelectedIndex].errors.Count));

            change = true;
            richTextBox1.Text = documents[tabControl1.SelectedIndex].rtb1_text;
            lastText = documents[tabControl1.SelectedIndex].rtb1_text;
            //richTextBox2.Text = documents[tabControl1.SelectedIndex].rtb2_text;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < documents[tabControl1.SelectedIndex].errors.Count; i++)
            {
                dataGridView1.Rows.Add(

                    documents[tabControl1.SelectedIndex].errors[i].Position,
                    documents[tabControl1.SelectedIndex].errors[i].Line,
                    documents[tabControl1.SelectedIndex].errors[i].Column,
                    documents[tabControl1.SelectedIndex].errors[i].Message);
                //documents[tabControl1.SelectedIndex].errors[i].location);
            }


            richTextBox3.Text = documents[tabControl1.SelectedIndex].rtb3_text;


            this.index = tabControl1.SelectedIndex;
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void CloseFile()
        {
            try
            {
                if (!documents[tabControl1.SelectedIndex].saved)
                {
                    DialogResult result = MessageBox.Show(
                            SaveFileStr1 + $" \"{documents[tabControl1.SelectedIndex].filename}\"?",
                            SaveFileStr2,
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question
                        );

                    if (result == DialogResult.Yes)
                    {
                        SaveFile();
                    }
                    else if (result == DialogResult.No)
                    {

                    }
                    else
                    {
                        return;
                    }
                }



                if (tabControl1.TabPages.Count == 1)
                {
                    documents[0].saved = true;
                    this.Close();
                }
                else if (tabControl1.SelectedIndex == 0)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.SelectedIndex + 1];
                    tabControl1.TabPages.RemoveAt(index - 1);
                    documents.RemoveAt(index - 1);
                }
                else
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.SelectedIndex - 1];
                    tabControl1.TabPages.RemoveAt(index + 1);
                    documents.RemoveAt(index + 1);
                }

                this.index = tabControl1.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CloseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == (Keys.Control | Keys.S))
                {
                    SaveFile();
                    return true;
                }
                else if (keyData == (Keys.Control | Keys.O))
                {
                    OpenFile();
                    return true;
                }
                else if (keyData == (Keys.Control | Keys.N))
                {
                    Document doc = new Document();
                    doc.filename = "New File";
                    doc.saved = false;
                    doc.savedAs = false;
                    doc.tokens = new List<Token>();
                    doc.errors = new List<Error>();
                    this.documents.Add(doc);
                    AddNewTabPage("* New File");
                }
                else if (keyData == (Keys.Control | Keys.W))
                {
                    CloseFile();
                }
                else if (keyData == Keys.F5)
                {
                    RunButton_Click(this, EventArgs.Empty);
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return base.ProcessCmdKey(ref msg, keyData);
            }

        }

        private void text11_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 11F);
                richTextBox3.Font = new Font("Cascadia Mono", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void text12_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 12F);
                richTextBox3.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void text14_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 14F);
                richTextBox3.Font = new Font("Cascadia Mono", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void text16_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 16F);
                richTextBox3.Font = new Font("Cascadia Mono", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void text18_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 18F);
                richTextBox3.Font = new Font("Cascadia Mono", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void text20_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 20F);
                richTextBox3.Font = new Font("Cascadia Mono", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ShowContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {




        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                foreach (var file in documents)
                {
                    if (file.saved == false)
                    {
                        DialogResult result = MessageBox.Show(
                            SaveFileStr1 + $" \"{file.filename}\"?",
                            SaveFileStr2,
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            SaveFile();
                        }
                        else if (result == DialogResult.No)
                        {

                        }
                        else
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateControlsText(Control control, ResourceManager res)
        {
            try
            {
                toolTip1.SetToolTip(this.CreateFileButton, res.GetString("ToolTip_CreateFileButton"));
                toolTip1.SetToolTip(this.OpenFileButton, res.GetString("ToolTip_OpenFileButton"));
                toolTip1.SetToolTip(this.SaveFileButton, res.GetString("ToolTip_SaveFileButton"));
                toolTip1.SetToolTip(this.ReturnButton, res.GetString("ToolTip_ReturnButton"));
                toolTip1.SetToolTip(this.RepeatButton, res.GetString("ToolTip_RepeatButton"));
                toolTip1.SetToolTip(this.CopyButton, res.GetString("ToolTip_CopyButton"));
                toolTip1.SetToolTip(this.CutButton, res.GetString("ToolTip_CutButton"));
                toolTip1.SetToolTip(this.PasteButton, res.GetString("ToolTip_PasteButton"));
                toolTip1.SetToolTip(this.RunButton, res.GetString("ToolTip_RunButton"));
                toolTip1.SetToolTip(this.AboutButton, res.GetString("ToolTip_AboutButton"));
                toolTip1.SetToolTip(this.InfoButton, res.GetString("ToolTip_InfoButton"));

                SaveFileStr1 = res.GetString("SaveFileStr1");
                SaveFileStr2 = res.GetString("SaveFileStr2");

                FileSaved = res.GetString("FileSaved");
                FileOpened = res.GetString("FileOpened");

                ErrorStr = res.GetString("ErrorStr");
                FileErrorStr = res.GetString("FileErrorStr");


                foreach (var item in this.dataGridView1.Columns)
                {
                    if (item is DataGridViewTextBoxColumn menuItem)
                    {
                        if (!string.IsNullOrEmpty(menuItem.Name))
                        {
                            string newText = res.GetString(menuItem.Name);
                            if (!string.IsNullOrEmpty(newText))
                                menuItem.HeaderText = newText;
                        }
                    }
                }


                foreach (var item in this.MainMenuStrip.Items)
                {
                    if (item is ToolStripMenuItem menuItem)
                    {
                        UpdateMenuItems(menuItem, res);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateMenuItems(ToolStripMenuItem menuItem, ResourceManager res)
        {
            try
            {
                if (!string.IsNullOrEmpty(menuItem.Name))
                {
                    string newText = res.GetString(menuItem.Name);
                    if (!string.IsNullOrEmpty(newText))
                        menuItem.Text = newText;
                }


                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    if (subItem is ToolStripMenuItem subMenuItem)
                    {
                        UpdateMenuItems(subMenuItem, res);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                ResourceManager res = new ResourceManager("Compilator.Properties.Resources", typeof(MainForm).Assembly);
                UpdateControlsText(this, res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void RussanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");

                ResourceManager res = new ResourceManager("Compilator.Properties.Resources", typeof(MainForm).Assembly);
                UpdateControlsText(this, res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {

            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string filePath in files)
                {
                    if (File.Exists(filePath))
                    {

                        string filename = Path.GetFileName(filePath);

                        string file_path = filePath;


                        string fileText = System.IO.File.ReadAllText(file_path);

                        Document doc = new Document();

                        doc.filename = filename;
                        doc.full_path = file_path;
                        doc.rtb1_text = fileText;
                        doc.tokens = new List<Token>();
                        doc.errors = new List<Error>();
                        doc.saved = true;
                        doc.savedAs = true;

                        for (int i = 0; i < documents.Count; i++)
                        {
                            if (documents[i].full_path == file_path)
                            {
                                tabControl1.SelectedIndex = i;
                                return;
                            }
                        }

                        documents.Add(doc);

                        AddNewTabPage(filename);

                        UpdateLineNumbers();

                    }
                    else
                    {
                        MessageBox.Show(FileErrorStr, ErrorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                byte[] chmBytes = Resources.Contents;


                string tempPath = Path.Combine(Path.GetTempPath(), "Contents.chm");
                File.WriteAllBytes(tempPath, chmBytes);


                Help.ShowHelp(this, tempPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void HighlightSubstring(RichTextBox richTextBox, int start, int end)
        {
            if (start < 0 || end > richTextBox.Text.Length || start >= end)
                return; // Проверяем корректность границ
            richTextBox1.SelectionBackColor = Color.White;
            // Запоминаем текущую позицию курсора
            int selectionStart = richTextBox.SelectionStart;

            if (start == end)
            {
                richTextBox.Select(start, start + 1);
                richTextBox.SelectionBackColor = Color.Red;
            }
            else
            {
                // Выделяем подстроку и меняем цвет фона
                richTextBox.Select(start, end - start);
                richTextBox.SelectionBackColor = Color.Red;
            }


            // Сбрасываем выделение
            richTextBox.Select(0, 0);
        }



        private void RunButton_Click(object sender, EventArgs e)
        {
            documents[tabControl1.SelectedIndex].tokens.Clear();
            documents[tabControl1.SelectedIndex].errors.Clear();
            Scaner scaner = new Scaner(richTextBox1.Text, documents[tabControl1.SelectedIndex].tokens);
            scaner.Analyze();

            documents[tabControl1.SelectedIndex].tokens = scaner.tokens;

            string s = "";
            foreach (var t in scaner.tokens)
            {
                s += t.token_type + " ";
            }
            //MessageBox.Show(s); 

            Parser parser = new Parser(scaner.tokens, scaner.input);

            parser.Parse();

            documents[tabControl1.SelectedIndex].errors = parser.errors;

            dataGridView1.Rows.Clear();


            for (int i = 0; i < documents[tabControl1.SelectedIndex].errors.Count; i++)
            {
                dataGridView1.Rows.Add(
                    documents[tabControl1.SelectedIndex].errors[i].Position,
                    documents[tabControl1.SelectedIndex].errors[i].Line,
                    documents[tabControl1.SelectedIndex].errors[i].Column,
                    documents[tabControl1.SelectedIndex].errors[i].Message
                    //documents[tabControl1.SelectedIndex].errors[i].location
                    );
            }
            if (documents[tabControl1.SelectedIndex].errors.Count != 0)
            {
                foreach (var err in documents[tabControl1.SelectedIndex].errors)
                {
                    //HighlightSubstring(richTextBox1,err.Start, err.End);
                }

            }


            //dataGridView1.Rows.Add(1,2,3,4,5);
            //AddErrsToDocs(tabControl1.SelectedIndex);

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(@"Куросвая работа на тему
Разработка синтаксического анализатора (парсера) для целочисленных констант языка Pascal.
Демченко Степан Сергеевич АВТ-214", "О программе");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(@"Куросвая работа на тему
Разработка синтаксического анализатора (парсера) для целочисленных констант языка Pascal.
Демченко Степан Сергеевич АВТ-214", "О программе");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenHTML(string file)
        {
            

            string htmlContent = file;

            // Сохраняем его во временный файл
            string tempFilePath = Path.Combine(Path.GetTempPath(), "tempfile.html");
            File.WriteAllText(tempFilePath, htmlContent);

            // Открываем HTML файл в браузере
            Process.Start(new ProcessStartInfo
            {
                FileName = tempFilePath,
                UseShellExecute = true // Использует системную ассоциацию для открытия (например, в браузере)
            });
            // Извлекаем HTML файл из ресурсов
            
        }


        private void TaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenHTML(Resources.HTM1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }

        private void GrammarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenHTML(Resources.HTM2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GrammarClassificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenHTML(Resources.HTM3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AnalisysMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string htmlContent = Resources.HTM4; 

                
                string tempDir = Path.Combine(Path.GetTempPath(), "CompImgs");
                Directory.CreateDirectory(tempDir);

               
                var imageBitmaps = new (Bitmap bitmap, string name)[]
                {
            (Resources.Graph, "Graph.png")
                };

                
                foreach (var (bitmap, fileName) in imageBitmaps)
                {
                    string imagePath = Path.Combine(tempDir, fileName);
                    bitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);

                    
                    htmlContent = htmlContent.Replace(fileName, imagePath.Replace("\\", "/"));
                }

                
                string htmlPath = Path.Combine(tempDir, "tempfile.html");
                File.WriteAllText(htmlPath, htmlContent);

                
                Process.Start(new ProcessStartInfo
                {
                    FileName = htmlPath,
                    UseShellExecute = true
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ErrorDiagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string htmlContent = Resources.HTM5;


                string tempDir = Path.Combine(Path.GetTempPath(), "CompImgs");
                Directory.CreateDirectory(tempDir);


                var imageBitmaps = new (Bitmap bitmap, string name)[]
                {
            (Resources.parsing_tree, "parsing_tree.png"),
            (Resources.error_tree, "error_tree.png")
                };


                foreach (var (bitmap, fileName) in imageBitmaps)
                {
                    string imagePath = Path.Combine(tempDir, fileName);
                    bitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);


                    htmlContent = htmlContent.Replace(fileName, imagePath.Replace("\\", "/"));
                }


                string htmlPath = Path.Combine(tempDir, "tempfile.html");
                File.WriteAllText(htmlPath, htmlContent);


                Process.Start(new ProcessStartInfo
                {
                    FileName = htmlPath,
                    UseShellExecute = true
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TestExampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string htmlContent = Resources.HTM6;


                string tempDir = Path.Combine(Path.GetTempPath(), "CompImgs");
                Directory.CreateDirectory(tempDir);


                var imageBitmaps = new (Bitmap bitmap, string name)[]
                {
            (Resources.test1, "test1.png"),
            (Resources.test2, "test2.png"),
            (Resources.test3, "test3.png"),
            (Resources.test4, "test4.png"),
            (Resources.test5, "test5.png"),
            (Resources.test6, "test6.png"),
                };


                foreach (var (bitmap, fileName) in imageBitmaps)
                {
                    string imagePath = Path.Combine(tempDir, fileName);
                    bitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);


                    htmlContent = htmlContent.Replace(fileName, imagePath.Replace("\\", "/"));
                }


                string htmlPath = Path.Combine(tempDir, "tempfile.html");
                File.WriteAllText(htmlPath, htmlContent);


                Process.Start(new ProcessStartInfo
                {
                    FileName = htmlPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LiteratureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenHTML(Resources.HTM7);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenHTML(Resources.HTM8);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void POLIZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var polizer = new POLIZParser(richTextBox1.Text);
            var messages = polizer.AnalyzeAndBuildPOLIZ();

            dataGridView1.Rows.Clear();

            foreach(var mess in messages) dataGridView1.Rows.Add(mess);


        }
    }
}
