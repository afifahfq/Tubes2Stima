using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace People_finder
{
    public partial class MainForm 
    {

        // Controls 
        private Label Title = new Label
        {
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
            Padding = new Padding(10),
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
            Padding = new Padding(10),
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
            Anchor = AnchorStyles.Top,
            AutoSize = true
        };

        // Friends Recommendation 

    }
}
