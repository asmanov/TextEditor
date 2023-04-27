using System.Windows.Forms;
using System.Drawing;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;
using System.IO;
using System;

namespace TextEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "TextEditor";

            #region text window
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Size = new System.Drawing.Size(this.Width, this.Height - 80);
            textBox.Location = new System.Drawing.Point(0, 20);
            //textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientSizeChanged += TextBox_ClientSizeChanged;
            //textBox.Text = "Hello";
            //textBox.KeyPress += TextBox_KeyPress;
            textBox.TextChanged += TextBox_TextChanged;
            #endregion
            

            btn = new Button();
            btn.Location = new System.Drawing.Point(0, 0);
            btn.Text = "Font";
            btn.Click += Btn_Click;



            save_btn = new System.Windows.Forms.Button();
            save_btn.Location = new Point(btn.Location.X + btn.Width, btn.Location.Y);
            save_btn.Text = "Save";
            save_btn.Click += Save_btn_Click;

           
            open_btn = new Button();
            open_btn.Location = new Point(save_btn.Location.X + save_btn.Width, save_btn.Location.Y);
            open_btn.Text = "Open";
            open_btn.Click += Open_btn_Click;


            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.OverwritePrompt = true;



            textBox2 = new TextBox();   
            textBox2.Location = new System.Drawing.Point(0, y: textBox.Location.Y + textBox.Height);
            textBox2.Width = 115;


            Image openImage = Image.FromFile("open-document.png");
            Image saveImage = Image.FromFile("save-file-icon.png");
            Image printImage = Image.FromFile("print.png");
            Image fontImage = Image.FromFile("font-size.png");
            Image colorImage = Image.FromFile("icons-color.png");


            MenuStrip menu = new MenuStrip();
            ToolStripMenuItem fileItem = new ToolStripMenuItem();
            fileItem.Text = "FILE";
            ToolStripMenuItem open = new ToolStripMenuItem("OPEN", openImage, Open_btn_Click) { ShortcutKeys = Keys.Control | Keys.O};
            ToolStripMenuItem save = new ToolStripMenuItem("SAVE", saveImage, Save_btn_Click) { ShortcutKeys = Keys.Control | Keys.S};
            ToolStripMenuItem print = new ToolStripMenuItem("PRINT", printImage, Print_Click) { ShortcutKeys = Keys.Control | Keys.P };
            ToolStripMenuItem exit = new ToolStripMenuItem("EXIT", null, Exit_Click);
            ToolStripSeparator line = new ToolStripSeparator();
            fileItem.DropDownItems.AddRange((new ToolStripItem[] { open, save, print, line, exit }));

            ToolStripMenuItem viewItem = new ToolStripMenuItem();
            viewItem.Text = "VIEW";
            ToolStripMenuItem font = new ToolStripMenuItem("FONT", fontImage, Btn_Click);
            ToolStripMenuItem color = new ToolStripMenuItem("COLOR", colorImage, Color_Click);
            viewItem.DropDownItems.AddRange((new ToolStripItem[] { font, color }));

            menu.Items.Add(fileItem);
            menu.Items.Add(viewItem);
            this.Controls.Add(textBox);
            //this.Controls.Add(btn);
            this.Controls.Add(textBox2);
            //this.Controls.Add(save_btn);
            //this.Controls.Add(open_btn);
            this.Controls.Add(menu);
        }

        private void Print_Click(object sender, EventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Printing.PrintDocument document = dialog.Document;
            }
        }

        private void Color_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = dialog.Color;
                textBox.BackColor = dialog.Color;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Open_btn_Click(object sender, System.EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string filename =openFileDialog.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            textBox.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void Save_btn_Click(object sender, System.EventArgs e)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string filename = saveFileDialog.FileName;
            File.WriteAllText(filename, textBox.Text);
            MessageBox.Show("File writed");
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            //fontDialog.ShowDialog();
            if (fontDialog.ShowDialog() == DialogResult.Cancel) return;
            textBox.Font = fontDialog.Font;
            textBox.ForeColor = fontDialog.Color;
           
        }

        private void TextBox_TextChanged(object sender, System.EventArgs e)
        {
            textBox2.Text = $"Кол-во сим-лов {textBox.Text.Length}";
        }

        private void TextBox_ClientSizeChanged(object sender, System.EventArgs e)
        {
            //textBox.Text = "Hello";
            textBox.Width = this.Width;
            textBox.Height = this.Height -80;
        }

        TextBox textBox;
        Button btn;
        TextBox textBox2;
        Button save_btn;
        Button open_btn;
        //MenuStrip menu;
        #endregion
    }
}





//private void TextBox_KeyDown(object sender, KeyEventArgs e)
//{
//    string text;
//    if (!Char.IsWhiteSpace((char)e.KeyValue))
//    {
//        text = textBox.Text;
//    }
//    else text = textBox.Text.Remove(textBox.Text.Length - 1);
//    textBox2.Text = $"Кол-во сим-лов {text.Length + 1}";
//}

//private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
//{
//    string text;

//    if (Char.IsWhiteSpace(e.KeyChar))
//    {
//        text = textBox.Text.Remove(textBox.Text.Length - 1);
//    }
//    else text = textBox.Text;
//    textBox2.Text = $"Кол-во сим-лов {text.Length}";
//}