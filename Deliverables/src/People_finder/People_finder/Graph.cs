using System;
using System.Collections.Generic;
using System.Linq;

public partial class Graph
{
    private int nEdges, nVertices, count, namaAkunInt, namaExploreInt, uAngka, vAngka, i, j;

    // Edges
    private List<(char, string)> edgeList;
    private List<(int, int)> eL;

    // Simpul
    private Dictionary<char, int> SimpulInt;
    private char[] simpulArray;
    private List<(int, char)> simpulAngka;
    private List<char> uniqueList, pathChar, pathCharDFS;
    private int[] degree, pred;
    private char namaAkun, namaExplore;
    private Dictionary<char, string> mutuals, sortedMutuals;
    private List<int> myFriends, currFriends;
    private List<List<int>> adj;
    public List<(List<char>, int)> hasilBFS, hasilDFS;


    public void InputInt(string Filename)
    {
        string[] lines, line;
        lines = System.IO.File.ReadAllLines(Filename);
        simpulAngka = new List<(int, char)>();
        uniqueList = new List<char>();

        nEdges = Int32.Parse(lines[0]);
        List<char> simpul = new List<char>();
        for (int i = 1; i <= nEdges; i++)
        {
            line = lines[i].Split(' ');
            char u = lines[i][0];
            string v = line[1];
            simpul.Add(u);
            simpul.Add(v[0]);

            uniqueList = simpul.Distinct().ToList();
        }

        simpulArray = uniqueList.ToArray();
        Array.Sort(simpulArray);
        nVertices = simpulArray.Length;
        for (int i = 0; i < nVertices; i++)
        {
            simpulAngka.Add((i + 1, simpulArray[i]));
        }

        SimpulInt = new Dictionary<char, int>();
        for (int i = 0; i < nVertices; i++)
        {
            line = lines[i].Split(' ');
            SimpulInt[simpulArray[i]] = i;
        }

        eL = new List<(int, int)>();

        for (int i = 1; i <= nEdges; i++)
        {
            line = lines[i].Split(' ');
            uAngka = SimpulInt[lines[i][0]];
            vAngka = SimpulInt[line[1][0]];
            eL.Add((uAngka, vAngka));
        }
    }
    public void InputAkun(char firstAccount, char secondAccount)
    {
        this.adj = new List<List<int>>(nVertices);
        this.namaAkun = firstAccount;
        this.namaExplore = secondAccount;

        for (i = 0; i < nVertices; i++)
        {
            adj.Add(new List<int>());
        }

        foreach ((int a, int b) in eL)
        {
            addEdge(adj, a, b);
        }


        foreach (var node in this.nodes)
        {
            
            if (namaAkun == node.ToCharArray()[0])
            {
                namaAkunInt = SimpulInt[node.ToCharArray()[0]];
            }
            if (namaExplore == node.ToCharArray()[0])
            {
                namaExploreInt = SimpulInt[node.ToCharArray()[0]];
            }
        }

    }
    public void addEdge(List<List<int>> adj, int v, int w)
    {
        adj[v].Add(w);
        adj[w].Add(v);
    }
    public void addEdge1(List<int>[] adj1, int v, int w)
    {
        adj1[v].Add(w);
    }
    public List<(List<char>, int)> exploreFriendUsingDFS(List<int>[] adj1, int v, bool[] visited)
    {
        List<char> pathCharDFS = new List<char>();
        this.hasilDFS = new List<(List<char>, int)>();
        visited[v] = true;
        if (v == namaExploreInt)
        {
            pathCharDFS.Add(namaExplore);
            // INI : Console.WriteLine(namaExplore);
            if (count == 0)
            {
                // INI : System.Console.WriteLine("No-degree connection");
                hasilDFS.Add((pathCharDFS, count));
            }
            else if (count == 1)
            {
                // INI : System.Console.WriteLine(count + "st-degree connection");
                hasilDFS.Add((pathCharDFS, count));
            }
            else if (count == 2)
            {
                // INI : System.Console.WriteLine(count + "nd-degree connection");
                hasilDFS.Add((pathCharDFS, count));
            }
            else
            {
                // INI : System.Console.WriteLine(count + "th-degree connection");
                hasilDFS.Add((pathCharDFS, count));
            }
            for (i = 0; i < nVertices; ++i)
            {
                visited[i] = true;
            }
        }
        else
        {
            if (v == namaAkunInt)
            {
                pathCharDFS.Add(namaAkun);
                // INI : Console.Write(namaAkun + " -> ");
            }
            else
            {
                for (int j = 0; j < nVertices; j++)
                {
                    if (v == SimpulInt[simpulArray[j]])
                    {
                        pathCharDFS.Add(simpulArray[j]);
                        // INI : Console.Write(simpulArray[j] + " -> ");
                        count += 1;
                    }
                }
            }
            foreach (int i in adj1[v])
            {
                if (!visited[i])
                {
                    exploreFriendUsingDFS(adj1, i, visited);
                }
            }
        }
        return hasilDFS;
    }
    public void DFS()
    {
        bool[] visited = new bool[nVertices];
        for (i = 0; i < nVertices; ++i)
        {
            if (!visited[i])
            {
                exploreFriendUsingDFS(this.adj.ToArray(), i, visited);
            }
        }
    }
    public List<(List<char>, int)> exploreFriendUsingBFS()
    {
        List<int> pathInt = new List<int>();
        List<char> pathChar = new List<char>();
        this.hasilBFS = new List<(List<char>, int)>();

        pred = new int[nVertices];
        degree = new int[nVertices];

        // ATURAN PRINT (aku tandain (// INI : ) yaa)
        // INI : Console.WriteLine("\nNama akun: " + namaAkun + " dan " + namaExplore);
        if (BFS(adj) == false)
        {
            // INI : System.Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
            // INI : System.Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
        }
        else
        {
            pathInt.Add(namaExploreInt);

            int tempNamaExploreInt = namaExploreInt;
            while (pred[tempNamaExploreInt] != -1)
            {
                pathInt.Add(pred[tempNamaExploreInt]);
                tempNamaExploreInt = pred[tempNamaExploreInt];
                // Console.WriteLine(pred[tempNamaExploreInt]);
            }

            for (i = pathInt.Count - 1; i >= 0; i--)
            {
                if (pathInt[i] == namaExploreInt)
                {
                    pathChar.Add(namaExplore);
                    int Derajat = degree[namaExploreInt] - 1;
                    // INI : Console.WriteLine(namaExplore);
                    if (Derajat == 0)
                    {
                        // INI : System.Console.WriteLine("0-degree connection");
                        hasilBFS.Add((pathChar, Derajat));
                    }
                    else if (Derajat == 1)
                    {
                        // INI : System.Console.WriteLine(Derajat + "st-degree connection");
                        hasilBFS.Add((pathChar, Derajat));
                    }
                    else if (Derajat == 2)
                    {
                        // INI : System.Console.WriteLine(Derajat + "nd-degree connection");
                        hasilBFS.Add((pathChar, Derajat));
                    }
                    else
                    {
                        // INI : System.Console.WriteLine(Derajat + "th-degree connection");
                        hasilBFS.Add((pathChar, Derajat));
                    }
                }
                else if (pathInt[i] == namaAkunInt)
                {
                    pathChar.Add(namaAkun);
                    // INI : Console.Write(namaAkun + " -> ");
                }
                else
                {
                    for (j = 0; j < nVertices; j++)
                    {
                        if (pathInt[i] == SimpulInt[simpulArray[j]])
                        {
                            pathChar.Add(simpulArray[j]);
                            // INI : Console.Write(simpulArray[j] + " -> ");
                        }
                    }
                }
            }
            Console.WriteLine();
        }
        return hasilBFS;
    }
    public bool BFS(List<List<int>> adj)
    {
        List<int> queue = new List<int>();      // To Save SimpulInt
        bool[] visited = new bool[nVertices];

        // Inisialisasi All
        for (i = 0; i < nVertices; i++)
        {
            visited[i] = false;
            degree[i] = int.MaxValue;
            pred[i] = -1;
        }

        // Insialisasi untuk Akun
        visited[namaAkunInt] = true;
        degree[namaAkunInt] = 0;
        queue.Add(namaAkunInt);

        Boolean found = false;
        while (queue.Count != 0)
        {
            int simpulQueue = queue[0];
            queue.RemoveAt(0);

            for (i = 0; i < adj[simpulQueue].Count; i++)
            {
                if (!visited[adj[simpulQueue][i]])
                {
                    degree[adj[simpulQueue][i]] = degree[simpulQueue] + 1;
                    pred[adj[simpulQueue][i]] = simpulQueue;
                    visited[adj[simpulQueue][i]] = true;
                    queue.Add(adj[simpulQueue][i]);

                    // Akun yang di Explore ketemu
                    if (adj[simpulQueue][i] == namaExploreInt)
                    {
                        found = true;
                    }
                }
            }
        }
        return found;
    }
    public Dictionary<char, string> FriendsRecom()
    {
        myFriends = new List<int>();
        bool[] visited = new bool[nVertices];
        mutuals = new Dictionary<char, string>();

        myFriends.AddRange(adj[namaAkunInt]);

        //ATURAN PRINT
        //Console.WriteLine();
        //Console.WriteLine("Friends Recommendation for " + namaAkun + " :");

        foreach (var friend in myFriends)
        {
            if (visited[friend] == false)
            {
                visited[friend] = true;
                var currKey = SimpulInt.FirstOrDefault(x => x.Value == friend).Key;

                foreach (var vertice in adj[friend])
                {
                    if (vertice != namaAkunInt && myFriends.Contains(vertice) == false && visited[vertice] == false)
                    {
                        visited[vertice] = true;
                        getMutuals(adj, vertice);
                    }
                }
            }
        }

        Boolean found = false;
        foreach (var i in mutuals)
        {
            if (i.Key == namaExplore)
            {
                found = true;
            }
        }

        if (!found)
        {
            getMutuals(adj, this.namaExploreInt);
        }

        mutuals = mutuals.OrderByDescending(i => i.Value.Length).ToDictionary(i => i.Key, i => i.Value);

        /*//ATURAN PRINT
        // print dulu vertice yg di explore
        foreach((char key, string value) in mutuals) {
            if (key == Tubes2Stima.namaExplore) {
                Console.WriteLine(key);
                Console.WriteLine(countVertices(value) + " Mutual Friends : " + value);
            }
        }
        // baru print vertice sisanya
        foreach((char key, string value) in mutuals) {
            if (key != Tubes2Stima.namaExplore) {
                Console.WriteLine(key);
                Console.WriteLine(countVertices(value) + " Mutual Friends : " + value);
            }
        } */

        return mutuals;
    }
    public void getMutuals(List<List<int>> adj, int vertice)
    {
        currFriends = new List<int>();
        currFriends.AddRange(adj[vertice]);

        var currV = SimpulInt.FirstOrDefault(x => x.Value == vertice).Key;

        var currMutuals = myFriends.Intersect(currFriends).ToList();

        List<char> convertedMutuals = new List<char>();
        foreach (var i in currMutuals)
        {
            var currKey = SimpulInt.FirstOrDefault(x => x.Value == i).Key;
            convertedMutuals.Add(currKey);
        }

        string items = string.Join(",", convertedMutuals);

        mutuals.Add(currV, items);
    }
    public int countVertices(string s)
    {
        int i = 0;

        for (int j = 0; j < s.Length; j++)
        {
            if (s[j] != ',')
            {
                i++;
            }
        }
        return i;
    }

   
}