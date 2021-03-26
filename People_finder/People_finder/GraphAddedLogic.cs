using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Graph
{
    // Added 
    private List<string> nodes;
    private Dictionary<string, List<string>> connectionList = new Dictionary<string, List<string>>();

    // Getters 
    public List<string>  getNodes() {
        return this.nodes;
    }

    public Dictionary<string, List<string>> getConnectionList()
    {
        return this.connectionList;
    }

    public void inputFile(string Filename)
    {
        string[] lines;
        string[] line;
        lines = System.IO.File.ReadAllLines(Filename);

        this.nEdges = Int32.Parse(lines[0]);
        for (int i = 1; i <= nEdges; i++)
        {
            line = lines[i].Split(' ');
            string node = line[0];
            string connectedNode = line[1];
            if (!this.connectionList.ContainsKey(node))
            {
                this.connectionList.Add(node, new List<string>());
            }
            this.connectionList[node].Add(connectedNode);
        }
        this.nodes = new List<string>(this.connectionList.Keys);
    }

    public void printGraph()
    {
        foreach(var node in nodes)
        {
            Console.Write(node + " : ");
            List<string> connection = connectionList[node];
            foreach (var connectedNode in connection)
            {
                Console.Write(connectedNode + ", " );
            }
            Console.WriteLine();
        }
    }


}
