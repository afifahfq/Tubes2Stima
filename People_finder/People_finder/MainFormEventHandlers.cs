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
