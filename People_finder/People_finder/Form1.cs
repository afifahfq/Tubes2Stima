using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People_finder
{
	public partial class Form1 : Form
    {
        // Controls 
        private Button BrowseButton = new Button();
        private String FileName = "";

        public Form1()
		{
			InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Form Sizing 
            const int width = 500;
            const int length = 600;
            this.Size = new Size(width, length);

            // Random Codes i found on the internet 
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Attributes 
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.Location = new System.Drawing.Point(10, 20);
            this.BrowseButton.Click += browseFile;

            // Layout 
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Location = new System.Drawing.Point(width / 2, length);


            this.Controls.Add(BrowseButton);
        }

        public void browseFile(Object sender, EventArgs e)
        {
            Console.WriteLine("Clicked");
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files To Turn Into Graphs",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.FileName = openFileDialog1.FileName;
            }
            Console.WriteLine(this.FileName);
        }
    }
}
