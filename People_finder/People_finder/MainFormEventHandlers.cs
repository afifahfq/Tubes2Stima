using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace People_finder
{
    public partial class MainForm
    {
        // Main Menu 
        public void browseFile(Object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                // Change this in the final commit 
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
                this.BrowseFilename.Text = this.FileName;
            }
        }

        public void openFile(Object sender, EventArgs e)
        {
            try {
                this.currentGraph.InputInt(this.FileName);
                this.currentGraph.inputFile(this.FileName);
            } catch(Exception err)
            {
                Console.WriteLine(err);
                return;
            }

            this.SuspendLayout();
            // Handling Dropdown Changes
            string[] accounts = this.currentGraph.getNodes().ToArray();
            this.firstPerson = accounts[0];
            this.secondPerson = accounts[1];
            this.ChooseAccountDropdown.Items.AddRange(accounts);
            this.ExploreAccountDropdown.Items.AddRange(accounts);
            this.ChooseAccountDropdown.SelectedItem = firstPerson;
            this.ExploreAccountDropdown.SelectedItem = secondPerson;


            this.visualizeGraph();
            this.ResumeLayout();
        }
        public void algorithmDropdownChange(Object sender, EventArgs e)
        {
            this.currentAlgorithm = this.AlgorithmDropdown.SelectedItem.ToString();
        }
        public void visualizeGraph()
        {
            this.visualizerGraph = new Microsoft.Msagl.Drawing.Graph("graph");
            foreach (var node in this.currentGraph.getNodes())
            {
                List<string> connection = this.currentGraph.getConnectionList()[node];
                foreach (var connectedNode in connection)
                {
                    this.visualizerGraph.AddEdge(node, connectedNode);
                    this.visualizerGraph.AddEdge(connectedNode, node);
                }
            }

            viewer.Graph = this.visualizerGraph;
        }

        // Sub Menu 
        public void firstAccountDropdownChange(Object sender, EventArgs e)
        {
            this.firstPerson = this.ChooseAccountDropdown.SelectedItem.ToString();
        }

        public void secondAccountDropdownChange(Object sender, EventArgs e)
        {
            this.secondPerson = this.ExploreAccountDropdown.SelectedItem.ToString();
        }

        public void submitData(Object sender, EventArgs e)
        {
            try
            {
                if (this.firstPerson == this.secondPerson)
                {
                    throw new Exception("Invalid input. The Current Account and Target Account cannot be the same person");
                }
            } catch (Exception err)
            {
                Console.WriteLine(err);
                return;
            }
            
            this.currentGraph.InputAkun(this.firstPerson.ToCharArray()[0], this.secondPerson.ToCharArray()[0]);
            
            // Friends Recomendation 
            Dictionary<char, string> result = this.currentGraph.FriendsRecom();
            this.FriendRecomendationBox.Controls.Clear();

            // +4 is a safe valve, 3 for the explore functions, and idk why i need an extra 1 
            this.FriendRecomendationBox.RowCount = result.Count()+4;

            string exploredText = "";
            int Degree = 0;
            // Explore Account 
            if (this.currentAlgorithm == "DFS")
            {
                this.currentGraph.DFS();
                if(this.currentGraph.hasilDFS[0].Item2 > 0)
                {
                    for (int i = 0; i < this.currentGraph.hasilDFS[0].Item1.Count(); i++)
                    {
                        char item = this.currentGraph.hasilDFS[0].Item1[i];
                        if ( i == this.currentGraph.hasilDFS[0].Item1.Count() - 1)
                        {
                            exploredText += item;
                        } else
                        {
                            exploredText += item + " -> ";
                        }
                        
                    }
                    Degree = this.currentGraph.hasilDFS[0].Item2;
                }
                else
                {
                    exploredText = "Tidak ada jalur koneksi yang tersedia atau koneksi langsung";
                }

            } else
            {
                this.currentGraph.exploreFriendUsingBFS();
                if (this.currentGraph.hasilBFS[0].Item2 > 0)
                {
                    for (int i = 0; i < this.currentGraph.hasilBFS[0].Item1.Count(); i++)
                    {
                        char item = this.currentGraph.hasilBFS[0].Item1[i];
                        if (i == this.currentGraph.hasilBFS[0].Item1.Count() - 1)
                        {
                            exploredText += item;
                        }
                        else
                        {
                            exploredText += item + " -> ";
                        }
                    }
                    Degree = this.currentGraph.hasilBFS[0].Item2;
                } else
                {
                    exploredText = "Tidak ada jalur koneksi yang tersedia atau koneksi langsung";
                }
            }

            //Explored Person
            Label newExplored = new Label
            {
                Text = exploredText,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true,
            };
            Label newDegree = new Label
            {
                Text = Degree + " degree connection",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true,
            };
            this.FriendRecomendationBox.RowStyles.Add(new RowStyle(SizeType.Absolute, 15));
            this.FriendRecomendationBox.RowStyles.Add(new RowStyle(SizeType.Absolute, 15));
            this.FriendRecomendationBox.Controls.Add(newExplored);
            this.FriendRecomendationBox.Controls.Add(newDegree);


            // Add the explored account first  
            int totalVertices = this.currentGraph.countVertices(result[this.secondPerson.ToCharArray()[0]]);
            if(totalVertices > 0)
            {
                Label newRecomendation = new Label
                {
                    Text = this.secondPerson + " is recomended with " + totalVertices + " Mutual Friends : " + result[this.secondPerson.ToCharArray()[0]],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true,
                };
                this.FriendRecomendationBox.RowStyles.Add(new RowStyle(SizeType.Absolute, 15));
                this.FriendRecomendationBox.Controls.Add(newRecomendation);
            }
            

            // Remove explored account
            result.Remove(this.secondPerson.ToCharArray()[0]);

            foreach (var node in result)
            {
                char key = node.Key;
                String value = node.Value;
                //Boolean check = this.currentGraph.getConnectionList()[this.firstPerson].Contains(key.ToString());
                totalVertices = this.currentGraph.countVertices(value);
                if (totalVertices > 0)
                {
                    Label newRecomendation = new Label
                    {
                        Text = key.ToString() + " is recomended with " + totalVertices + " Mutual Friends : " + value,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleLeft,
                        AutoSize = true,
                    };
                    this.FriendRecomendationBox.RowStyles.Add(new RowStyle(SizeType.Absolute, 15));
                    this.FriendRecomendationBox.Controls.Add(newRecomendation);
                }
            }
            this.FriendRecomendationBox.Visible = true;
        }
    }
}
