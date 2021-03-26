using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
        public class Tubes2Stima
        {
            public static int nEdges, nVertices, count, namaAkunInt, namaExploreInt, uAngka, vAngka, i, j;
            public static List<(char, string)> edgeList;
            public static List<(int, int)> eL;
            public static Dictionary<char, int> SimpulInt;
            public static string[] lines, line;
            public static char[] simpulArray;
            public static List<(int, char)> simpulAngka;
            public static List<char> uniqueList, pathChar, pathCharDFS;
            public static int[] degree, pred;
            public static char namaAkun, namaExplore;
            public static Dictionary<char, string> mutuals, sortedMutuals;
            public static List<int> myFriends, currFriends;
            public static List<int>[] adj1;
            public static List<(List<char>, int)> hasilBFS, hasilDFS;

            public static void InputInt()
            {
                lines = System.IO.File.ReadAllLines("input.txt");
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
                /* for (int i = 0; i < nVertices; i++){
                    //Console.Write(simpulArray[i]);
                    //Console.WriteLine("INI SIMPUL ARRAY : {0}", simpulArray.Length);
                    //newsimpul = simpulArray.Distinct().ToArray();
                } */
                //Console.WriteLine();
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

                //char awal = simpulArray[0];
                //Console.WriteLine(awal);
                //int root = SimpulInt[simpulArray[0]];
                //Console.WriteLine(root);
                //Console.WriteLine("INI " + SimpulInt[line[0]]);
                //Console.WriteLine("INI l0" + line[0]); // line[0] == c
                //int m = Int32.Parse(line[0]); // 13, m = nEdges
                eL = new List<(int, int)>();

                for (int i = 1; i <= nEdges; i++)
                {
                    line = lines[i].Split(' ');
                    uAngka = SimpulInt[lines[i][0]];
                    vAngka = SimpulInt[line[1][0]];
                    eL.Add((uAngka, vAngka));
                }
            }
            public static void addEdge(List<List<int>> adj, int v, int w)
            {
                adj[v].Add(w);
                adj[w].Add(v);
            }
            public static void addEdge1(List<int>[] adj1, int v, int w)
            {
                adj1[v].Add(w);
            }
            public static List<(List<char>, int)> exploreFriendUsingDFS(List<int>[] adj1, int v, bool[] visited)
            {
                List<char> pathCharDFS = new List<char>();
                List<(List<char>, int)> hasilDFS = new List<(List<char>, int)>();
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
            public static void DFS(List<int>[] adj1)
            {
                bool[] visited = new bool[nVertices];
                for (i = 0; i < nVertices; ++i)
                {
                    if (!visited[i])
                    {
                        exploreFriendUsingDFS(adj1, i, visited);
                    }
                }
            }
            public static List<(List<char>, int)> exploreFriendUsingBFS(List<List<int>> adj)
            {
                List<int> pathInt = new List<int>();
                List<char> pathChar = new List<char>();
                List<(List<char>, int)> hasilBFS = new List<(List<char>, int)>();

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
            public static bool BFS(List<List<int>> adj)
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
            public static void InputAkun()
            {
                int pilih;
                List<List<int>> adj = new List<List<int>>(nVertices);
                List<int>[] adj1 = new List<int>[nVertices];

                for (i = 0; i < nVertices; i++)
                {
                    adj.Add(new List<int>());
                }

                foreach ((int a, int b) in eL)
                {
                    addEdge(adj, a, b);
                }

                // ATURAN PRINT (aku tandain (// INI : ) ya)
                // INI : Console.Write("Choose Account : ");
                namaAkun = Console.ReadLine()[0];

                // INI : Console.Write("Explore friends with : ");
                namaExplore = Console.ReadLine()[0];
                Console.WriteLine();

                for (int i = 1; i <= nEdges; i++)
                {
                    line = lines[i].Split(' ');
                    if (namaAkun == lines[i][0])
                    {
                        namaAkunInt = SimpulInt[lines[i][0]];
                    }
                    if (namaAkun == line[1][0])
                    {
                        namaAkunInt = SimpulInt[line[1][0]];
                    }
                    if (namaExplore == line[1][0])
                    {
                        namaExploreInt = SimpulInt[line[1][0]];
                    }
                    if (namaExplore == lines[i][0])
                    {
                        namaExploreInt = SimpulInt[lines[i][0]];
                    }
                }

                // INI : Console.Write("Pencarian Dengan : \n1. BFS \n2. DFS \nMasukkan nomor pilihan :  ");
                pilih = Int32.Parse(Console.ReadLine());

                if (pilih == 1)
                {
                    exploreFriendUsingBFS(adj);
                }
                else if (pilih == 2)
                {
                    adj1 = new List<int>[nVertices];
                    for (i = 0; i < nVertices; ++i)
                    {
                        adj1[i] = new List<int>();
                    }
                    foreach ((int a, int b) in eL)
                    {
                        addEdge1(adj1, a, b);
                    }

                    DFS(adj1);
                }
                else
                {
                    Boolean found = false;
                    while (!found)
                    {
                        // d. Console.Write("Input Salah! \nSilahkan Masukkan ulang pilihan : ");
                        pilih = Int32.Parse(Console.ReadLine());
                        if (pilih == 1)
                        {
                            found = true;
                            Console.WriteLine();
                            exploreFriendUsingBFS(adj);
                        }
                        if (pilih == 2)
                        {
                            adj1 = new List<int>[nVertices];
                            for (i = 0; i < nVertices; ++i)
                            {
                                adj1[i] = new List<int>();
                            }
                            foreach ((int a, int b) in eL)
                            {
                                addEdge1(adj1, a, b);
                            }
                            DFS(adj1);
                        }
                    }
                }
                FriendsRecom(adj);
            }
            public static Dictionary<char, string> FriendsRecom(List<List<int>> adj)
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
                    getMutuals(adj, Tubes2Stima.namaExploreInt);
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
            public static void getMutuals(List<List<int>> adj, int vertice)
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
            public static int countVertices(string s)
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
        class utama
        {
            public static void Main(String[] args)
            {
                Tubes2Stima.InputInt();
                Tubes2Stima.InputAkun();
            }
        }
    
}

