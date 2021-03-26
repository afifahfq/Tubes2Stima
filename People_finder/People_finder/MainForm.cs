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
	public partial class MainForm : Form
    {
        //Attributes
        private String FileName = "";
        private int width = 800;
        private int length =800;
        private Graph currentGraph;


        // Adjust This Later 
        private char firstPerson = 'A';
        private char secondPerson = 'B';

        public MainForm()
		{
			InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");


            // DropDown Menu 
            string[] accounts = new string[] { "A", "B", "C" };
            ComboBox ChooseAccountDropdown = new ComboBox
            {
                Name = "Choose Account",
                Dock = DockStyle.Fill,
                Margin = new Padding(20)
            };
            ChooseAccountDropdown.Items.AddRange(accounts);

            ComboBox ExploreAccountDropdown = new ComboBox
            {
                Name = "Explore Account",
                Dock = DockStyle.Fill,
                Margin = new Padding(20)
            };
            ExploreAccountDropdown.Items.AddRange(accounts);

            // Bind the graph to the viewer 
            viewer.Graph = graph;
            viewer.Dock = DockStyle.Fill;


            // Form Sizing 
            this.Size = new Size(this.width, this.length);
            //this.AutoSize = true;

            // Random Codes i found on the internet 
            //this.MaximizeBox = true;
            //this.MinimizeBox = true;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Control Events 
            this.BrowseButton.Click += browseFile;

            // Layout 
            TableLayoutPanel panel = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 3,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Padding = new Padding(10),
                //CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                AutoScroll = true

            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));

            MainMenuPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            MainMenuPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            MainMenuPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            MainMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            MainMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            MainMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));

            SubMenuPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            SubMenuPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            SubMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            SubMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            SubMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            SubMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));

            FlowLayoutPanel groupBox1 = new FlowLayoutPanel {
                FlowDirection = FlowDirection.RightToLeft
            };

            RadioButton radioButton1 = new RadioButton {
                Text = "DFS"
            };
            RadioButton radioButton2 = new RadioButton { 
                Text = "BFS"
            };
            RadioButton selectedrb = new RadioButton();
            //Button getSelectedRB;

            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            //groupBox1.Controls.Add(getSelectedRB);
            //groupBox1.Text = "Radio Buttons";


            // Add Controls to MainMenuPanel
            MainMenuPanel.Controls.Add(BrowseLabel);
            MainMenuPanel.Controls.Add(BrowseFilename);
            MainMenuPanel.Controls.Add(BrowseButton);
            MainMenuPanel.Controls.Add(AlgorithmLabel);
            MainMenuPanel.Controls.Add(groupBox1);
            MainMenuPanel.Controls.Add(OpenFileButton, 0, 2);

            // Add Controls to SubMenuPanel
            SubMenuPanel.Controls.Add(ChooseAccountLabel, 0, 0);
            SubMenuPanel.Controls.Add(ChooseAccountDropdown, 1, 0);
            SubMenuPanel.Controls.Add(ExploreLabel, 0, 1);
            SubMenuPanel.Controls.Add(ExploreAccountDropdown, 1, 1);
            SubMenuPanel.Controls.Add(SubmitButton, 1, 2);

            TableLayoutPanel newPanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 3,
                MinimumSize = new Size(200, 200),
            };

            SubMenuPanel.Controls.Add(newPanel, 0, 3);
            // Add Controls to Layout
            panel.Controls.Add(Title, 0, 0);
            panel.Controls.Add(MainMenuPanel, 0, 1);
            panel.Controls.Add(viewer, 0, 2);
            panel.Controls.Add(SubMenuPanel, 0, 3);

            this.Controls.Add(panel);
        }
    }

}
