using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Files (*.rtf)|*.rtf|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (System.IO.Path.GetExtension(openFileDialog.FileName).ToLower() == ".rtf")
                        {
                            richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                        }
                        else
                        {
                            richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi mở tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string currentFilePath = null;

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                            currentFilePath = saveFileDialog.FileName;
                            MessageBox.Show("Lưu tập tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Lưu tập tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripNewButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void toolStripSaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                            currentFilePath = saveFileDialog.FileName;
                            MessageBox.Show("Lưu tập tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Lưu tập tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bold_Click(object sender, EventArgs e)
        {
            FontStyle style = richTextBox1.SelectionFont.Style;
            style = richTextBox1.SelectionFont.Bold ? style & ~FontStyle.Bold : style | FontStyle.Bold;
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void italic_Click(object sender, EventArgs e)
        {
            FontStyle style = richTextBox1.SelectionFont.Style;
            style = richTextBox1.SelectionFont.Italic ? style & ~FontStyle.Italic : style | FontStyle.Italic;
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void underline_Click(object sender, EventArgs e)
        {
            FontStyle style = richTextBox1.SelectionFont.Style;
            style = richTextBox1.SelectionFont.Underline ? style & ~FontStyle.Underline : style | FontStyle.Underline;
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        
    }
}
