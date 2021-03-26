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
        private int length = 800;
        private Graph currentGraph = new Graph();

        // Needed for Controls Logics 
        private string[] Algorithms = new string[] {"BFS", "DFS" };
        private string currentAlgorithm;
        private string firstPerson;
        private string secondPerson;
        

        public MainForm()
		{
			InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {


            
            // Bind the graph to the viewer 
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

            this.currentAlgorithm = this.Algorithms[0];
            this.AlgorithmDropdown.Items.AddRange(this.Algorithms);
            this.AlgorithmDropdown.SelectedItem = this.currentAlgorithm;

            // Control Events 
            // Buttons
            this.BrowseButton.Click += browseFile;
            this.OpenFileButton.Click += openFile;
            this.SubmitButton.Click += submitData;
            // Dropdowns
            this.ChooseAccountDropdown.SelectedIndexChanged += firstAccountDropdownChange;
            this.ExploreAccountDropdown.SelectedIndexChanged += secondAccountDropdownChange;
            this.AlgorithmDropdown.SelectedIndexChanged += algorithmDropdownChange;


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

            // Add Controls to MainMenuPanel
            MainMenuPanel.Controls.Add(BrowseLabel);
            MainMenuPanel.Controls.Add(BrowseFilename);
            MainMenuPanel.Controls.Add(BrowseButton);
            MainMenuPanel.Controls.Add(AlgorithmLabel);
            MainMenuPanel.Controls.Add(AlgorithmDropdown);
            MainMenuPanel.Controls.Add(OpenFileButton, 0, 2);

            // Add Controls to SubMenuPanel
            SubMenuPanel.Controls.Add(ChooseAccountLabel, 0, 0);
            SubMenuPanel.Controls.Add(ChooseAccountDropdown, 1, 0);
            SubMenuPanel.Controls.Add(ExploreLabel, 0, 1);
            SubMenuPanel.Controls.Add(ExploreAccountDropdown, 1, 1);
            SubMenuPanel.Controls.Add(SubmitButton, 1, 2);
            SubMenuPanel.Controls.Add(FriendRecomendationBox, 0, 3);
            
            // Add Controls to Layout
            panel.Controls.Add(Title, 0, 0);
            panel.Controls.Add(MainMenuPanel, 0, 1);
            panel.Controls.Add(viewer, 0, 2);
            panel.Controls.Add(SubMenuPanel, 0, 3);

            this.Controls.Add(panel);
        }
    }

}
