﻿using System;
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
        private int width = 800;
        private int length =800;


        // Adjust This Later 
        private char firstPerson = 'A';
        private char secondPerson = 'B';

        // Controls 
        private Label Title = new Label {
            Text = "People Finder",
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Arial", 20, FontStyle.Bold),
            Dock = DockStyle.Fill,
        };


        // Main Menu 

        TableLayoutPanel MainMenuPanel = new TableLayoutPanel
        {
            ColumnCount = 3,
            RowCount = 2,
            Dock = DockStyle.Fill,
            Location = new Point(0, 0),
            BorderStyle = BorderStyle.FixedSingle,
        };


        // Browse File Section 
        private Button BrowseButton = new Button
        {
            Text = "Browse",
            Dock = DockStyle.Fill,
            AutoSize = true
        };
        private Label BrowseLabel = new Label
        {
            Text = "Browse File : ",
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
            AutoSize = true
        };
        private Label BrowseFilename = new Label
        {
            Text = "",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = true,
        };

        //Algorithm 
        private Label AlgorithmLabel = new Label
        {
            Text = "Algorithm : ",
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            AutoSize = true
        };

        private Button OpenFileButton = new Button
        {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "OpenFile",
            Dock = DockStyle.Fill,
            AutoSize = true
        };


        // Sub Menu 
        TableLayoutPanel SubMenuPanel = new TableLayoutPanel
        {
            ColumnCount = 3,
            RowCount = 2,
            Dock = DockStyle.Fill,
            Location = new Point(0, 0),
            BorderStyle = BorderStyle.FixedSingle,
        };


        // Choose Account
        private Label ChooseAccountLabel = new Label
        {
            Text = "Choose Account : ",
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            AutoSize = true
        };

        // Explore Friends 
        private Label ExploreLabel = new Label
        {
            Text = "Explore Friends : ",
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            AutoSize = true
        };

        // Submit Button 
        private Button SubmitButton = new Button
        {
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Submit",
            Dock = DockStyle.None,
            AutoSize = true
        };

        // Friends Recommendation 

        public Form1()
		{
			InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");


            // DropDown Menu 

            //this.ComboBox1 = new ComboBox();
            //this.ComboBox1.Location = new System.Drawing.Point(128, 48);
            //this.ComboBox1.Name = "ComboBox1";
            //this.ComboBox1.Size = new System.Drawing.Size(100, 21);
            //this.ComboBox1.TabIndex = 0;
            //this.ComboBox1.Text = "Typical";
            //string[] installs = new string[] { "Typical", "Compact", "Custom" };
            //ComboBox1.Items.AddRange(installs);
            //this.Controls.Add(this.ComboBox1);


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
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));

            MainMenuPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            MainMenuPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            MainMenuPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            MainMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            MainMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            MainMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

            SubMenuPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            SubMenuPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            SubMenuPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

            // Add Controls to MainMenuPanel
            MainMenuPanel.Controls.Add(BrowseLabel);
            MainMenuPanel.Controls.Add(BrowseFilename);
            MainMenuPanel.Controls.Add(BrowseButton);
            MainMenuPanel.Controls.Add(AlgorithmLabel);
            MainMenuPanel.Controls.Add(OpenFileButton, 0, 2);

            // Add Controls to SubMenuPanel
            SubMenuPanel.Controls.Add(ChooseAccountLabel);
            SubMenuPanel.Controls.Add(ExploreLabel);
            SubMenuPanel.Controls.Add(SubmitButton);

      

            // Add Controls to Layout
            panel.Controls.Add(Title, 0, 0);
            panel.Controls.Add(MainMenuPanel, 0, 1);
            panel.Controls.Add(viewer, 0, 2);
            panel.Controls.Add(SubMenuPanel);

            this.Controls.Add(panel);
        }

        public void browseFile(Object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"E:\Project\College\Strategi Algoritma\Tugas Besar 2 - People You May Know",
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
                this.BrowseFilename.Text = this.FileName;
            }
            Console.Out.WriteLine(this.FileName);
        }
    }

}
