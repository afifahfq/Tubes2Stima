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
        //Attributes
        private String FileName = "";
        private int width = 500;
        private int length = 600;

        // Controls 

        private Label Title = new Label {
            Text = "People Finder",
            Anchor = AnchorStyles.Top,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Arial", 10, FontStyle.Bold)
            //Size = new Size(20, 20)
        };
        private Button BrowseButton = new Button
        {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Browse",
            Location = new Point(10, 20),
        };
        private Label BrowseLabel = new Label
        {
            Text = "Browse : ",
            Anchor = AnchorStyles.Top,
            TextAlign = ContentAlignment.MiddleCenter,
            //Size = new Size(20, 20)
        };

        public Form1()
		{
			InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Form Sizing 
            this.MinimumSize = new Size(this.width, this.length);
            this.AutoSize = true;

            // Random Codes i found on the internet 
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Controls
            this.BrowseButton.Click += browseFile;

            // Layout 
            TableLayoutPanel panel = new TableLayoutPanel();
            //panel.Location = new Point(50, 50);
            panel.MinimumSize = new Size(width-100, length-100);
            panel.AutoSize = true;
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            panel.ColumnCount = 1;
            panel.RowCount = 3;
            panel.Padding = new Padding(50);
            //panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            //panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            //panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            //panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            //panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            //panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));

            TableLayoutPanel MainMenuPanel = new TableLayoutPanel
            {
                Padding = new Padding(10, 5, 10, 5),
                RowCount = 2,
                ColumnCount = 3,
            };

            // Add Controls to MainMenuPanel
            MainMenuPanel.Controls.Add(BrowseLabel, 0, 0);
            MainMenuPanel.Controls.Add(BrowseButton, 1, 0);

            // Add Controls to Layout
            panel.Controls.Add(Title, 0, 0);
            panel.Controls.Add(MainMenuPanel);

            this.Controls.Add(panel);
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
        }

        public void openFile()
        {

        }
    }
}
