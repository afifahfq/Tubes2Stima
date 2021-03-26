using System;
using System.Collections.Generic;
using System.Linq;

namespace Tubes2Stima{
    public class program{
        public class Tubes2Stima{
            public static int nEdges, nVertices, count, namaAkunInt, namaExploreInt, uAngka, vAngka, i, j;
            public static List<(char, string)> edgeList;
            public static List<(int, int)> eL;
            public static Dictionary<char, int> SimpulInt;
            public static string[] lines, line;
            public static char[] simpulArray;
            public static List<(int, char)> simpulAngka;
            public static List<char> uniqueList;
            public static int[] succ, pred;
            public static char namaAkun, namaExplore;
            public static Dictionary<char, string> mutuals, sortedMutuals;
            public static List<int> myFriends, currFriends;
            public static List<int>[] adj1;
            
            public static void InputInt(){
                lines = System.IO.File.ReadAllLines("input.txt");
                simpulAngka = new List<(int, char)>();
                uniqueList = new List<char>();

                nEdges = Int32.Parse(lines[0]);
                List<char> simpul = new List<char>();
                for (int i = 1; i <= nEdges; i++){
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
                for (int i = 0; i < nVertices; i++){
                    simpulAngka.Add((i+1, simpulArray[i]));
                }

                SimpulInt = new Dictionary<char, int>();
                for (int i = 0; i < nVertices; i++){
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

                for (int i = 1; i <= nEdges; i++){
                    line = lines[i].Split(' ');
                    uAngka = SimpulInt[lines[i][0]];
                    vAngka = SimpulInt[line[1][0]];
                    eL.Add((uAngka, vAngka));
                }
            }
                     
            public static void addEdge(List<List<int>> adj, int v, int w){
                adj[v].Add(w);
                adj[w].Add(v);
            }
            public static void addEdge1(List<int>[] adj1, int v, int w){
                adj1[v].Add(w);
            }
            public static void exploreFriendUsingDFS(List<int>[] adj1, int v, bool[] visited){
                visited[v] = true;
                if (v == namaExploreInt){
                    Console.WriteLine(Tubes2Stima.namaExplore);
                    if (count == 0){
                        System.Console.WriteLine("No-degree connection");
                    }
                    else if (count == 1){
                        System.Console.WriteLine(count + "st-degree connection");
                    }
                    else if (count == 2){
                        System.Console.WriteLine(count + "nd-degree connection");
                    }
                    else{
                        System.Console.WriteLine(count + "th-degree connection");
                    }
                    for (i = 0; i < nVertices; ++i){
                        visited[i] = true;
                    }
                }
                else{
                    if (v == namaAkunInt){
                        Console.Write(namaAkun + " -> ");
                    }
                    else{
                        for (int j = 0; j < nVertices; j++){
                            if (v == SimpulInt[simpulArray[j]]){
                                Console.Write(simpulArray[j] + " -> ");
                                count += 1;
                            }
                        }
                    }
                    foreach(int i in adj1[v]){
                        if (!visited[i]){
                            exploreFriendUsingDFS(adj1, i, visited);
                        }
                    }
                }
            }
            public static void DFS(List<int>[] adj1){
                bool[] visited = new bool[nVertices];
                for (i = 0; i < nVertices; ++i){
                    if (!visited[i]){
                        exploreFriendUsingDFS(adj1, i, visited);
                    }
                }
            }
            public static void exploreFriendUsingBFS(List<List<int>> adj) {
                int tempNamaExploreInt;

                pred = new int[nVertices];
                succ = new int[nVertices];
                
                Console.WriteLine("\nNama akun: " + namaAkun + " dan " + namaExplore);
                if (BFS(adj) == false) {
                    System.Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
                    System.Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
                }
                	
                List<int> path = new List<int>();
                tempNamaExploreInt = namaExploreInt;
                path.Add(tempNamaExploreInt);
                
                while (pred[tempNamaExploreInt] != -1){
                    path.Add(pred[tempNamaExploreInt]);
                    tempNamaExploreInt = pred[tempNamaExploreInt];
                }
                
                if (succ[namaExploreInt] == 1){
                    System.Console.WriteLine("0-degree connection");
                }
                else if (succ[namaExploreInt] == 2){
                    System.Console.WriteLine(succ[namaExploreInt]-1 + "st-degree connection");
                }
                else if (succ[namaExploreInt] == 3){
                    System.Console.WriteLine(succ[namaExploreInt]-1 + "nd-degree connection");
                }
                else{
                    System.Console.WriteLine(succ[namaExploreInt]-1 + "th-degree connection");
                }
                if (namaAkunInt < namaExploreInt){
                    for(i = path.Count - 1; i >= 0; i--){
                        if (path[i] == namaExploreInt){
                            Console.WriteLine(namaExplore);
                        }
                        else if (path[i] == namaAkunInt){
                            Console.Write(namaAkun + " -> ");
                        }
                        else{
                            for (int j = 0; j < nVertices; j++){
                                if (path[i] == SimpulInt[simpulArray[j]]){
                                    Console.Write(simpulArray[j] + " -> ");
                                }
                            }
                        }
                    }
                    
                }
                else{
                    for(i = path.Count - 1; i >= 0; i--){
                        if (path[i] == namaExploreInt){
                            Console.WriteLine(namaExplore);
                        }
                        else if (path[i] == namaAkunInt){
                            Console.Write(namaAkun + " -> ");
                        }
                        else{
                            for (int j = 0; j < nVertices; j++){
                                if (path[i] == SimpulInt[simpulArray[j]]){
                                    Console.Write(simpulArray[j] + " -> ");
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }
            public static bool BFS(List<List<int>> adj) {
                List<int> queue = new List<int>();
                bool []visited = new bool[nVertices];
                
                for (i = 0; i < nVertices; i++){
                    visited[i] = false;
                    succ[i] = int.MaxValue;
                    pred[i] = -1;
                }

                visited[namaAkunInt] = true;
                succ[namaAkunInt] = 0;
                queue.Add(namaAkunInt);
                
                while (queue.Count != 0){
                    j = queue[0];
                    queue.RemoveAt(0);
                    
                    for (i = 0; i < adj[j].Count; i++){
                        if (visited[adj[j][i]] == false){
                            visited[adj[j][i]] = true;
                            succ[adj[j][i]] = succ[j] + 1;
                            pred[adj[j][i]] = j;
                            queue.Add(adj[j][i]);
                    
                            if (adj[j][i] == namaExploreInt)
                            return true;
                        }
                    }
                }
                return false;
            }
            public static void InputAkun() {
                int pilih;
                List<List<int>> adj = new List<List<int>>(nVertices);
                List<int>[] adj1 = new List<int>[nVertices];
                
                for (i = 0; i < nVertices; i++){
                    adj.Add(new List<int>());
                }

                foreach((int a, int b) in eL){
                    addEdge(adj, a, b);
                }

                Console.Write("Choose Account : ");
                namaAkun = Console.ReadLine()[0];

                Console.Write("Explore friends with : ");
                namaExplore = Console.ReadLine()[0];
                Console.WriteLine();

                for (int i = 1; i <= nEdges; i++){
                    line = lines[i].Split(' ');
                    if (namaAkun == lines[i][0]){
                        namaAkunInt = SimpulInt[lines[i][0]];
                        //Console.WriteLine(i + "Ini 1 : " + namaAkun + namaAkunInt + SimpulInt[lines[i][0]]);
                    }
                    if (namaAkun == line[1][0]){
                        namaAkunInt = SimpulInt[line[1][0]];
                        //Console.WriteLine(i + "ini 2 : " + namaAkun + namaAkunInt + SimpulInt[line[1][0]]);
                    }
                    if (namaExplore == line[1][0]){
                        namaExploreInt = SimpulInt[line[1][0]];
                        //Console.WriteLine(i + "ini 3 : " + namaExplore + namaExploreInt + SimpulInt[line[1][0]]);
                    }
                    if (namaExplore == lines[i][0]){
                        namaExploreInt = SimpulInt[lines[i][0]];
                        //Console.WriteLine(i + "ini 4 : " + namaExplore + namaExploreInt + SimpulInt[lines[i][0]]);
                    }
                }

                Console.Write("Pencarian Dengan : \n1. BFS \n2. DFS \nMasukkan nomor pilihan :  ");
                pilih = Int32.Parse(Console.ReadLine());

                if (pilih == 1){
                    exploreFriendUsingBFS(adj);
                }
                else if (pilih == 2){
                    adj1 = new List<int>[nVertices];
                    for (i = 0; i < nVertices; ++i){
                        adj1[i] = new List<int>();
                    }
                    foreach((int a, int b) in eL){
                        addEdge1(adj1, a, b);
                    }

                    DFS(adj1);
                }
                else{
                    Boolean found = false;
                    while (!found){
                        Console.Write("Input Salah! \nSilahkan Masukkan ulang pilihan : ");
                        pilih = Int32.Parse(Console.ReadLine());
                        if (pilih == 1){
                            found = true;
                            Console.WriteLine();
                            exploreFriendUsingBFS(adj);
                        }
                        if (pilih == 2){
                            adj1 = new List<int>[nVertices];
                            for (i = 0; i < nVertices; ++i){
                                adj1[i] = new List<int>();
                            }
                            foreach((int a, int b) in eL){
                                addEdge1(adj1, a, b);
                            }

                            DFS(adj1);
                        }
                    }
                }
                FriendsRecom(adj);    
            }
            public static Dictionary<char, string> FriendsRecom(List<List<int>> adj) {
                myFriends = new List<int>();
                bool[] visited = new bool[nVertices];
                mutuals = new Dictionary<char, string>();

                myFriends.AddRange(adj[namaAkunInt]);
                
                //ATURAN PRINT
                //Console.WriteLine();
                //Console.WriteLine("Friends Recommendation for " + namaAkun + " :");

                foreach (var friend in myFriends) {
                    if (visited[friend] == false) {
                        visited[friend] = true;
                        var currKey = SimpulInt.FirstOrDefault(x => x.Value == friend).Key;
                
                        foreach(var vertice in adj[friend]) {
                            if (vertice != namaAkunInt && myFriends.Contains(vertice)==false && visited[vertice]==false) {
                                visited[vertice] = true;
                                getMutuals(adj, vertice);
                            }
                        }
                    }
                }

                Boolean found = false;
                foreach(var i in mutuals) {
                    if (i.Key == namaExplore) {
                        found = true;
                    }
                }

                if (!found) {
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
            public static void getMutuals(List<List<int>> adj, int vertice) {
                currFriends = new List<int>();
                currFriends.AddRange(adj[vertice]);

                var currV = SimpulInt.FirstOrDefault(x => x.Value == vertice).Key;

                var currMutuals = myFriends.Intersect(currFriends).ToList();  

                List<char> convertedMutuals = new List<char>();
                foreach (var i in currMutuals) {
                    var currKey = SimpulInt.FirstOrDefault(x => x.Value == i).Key;
                    convertedMutuals.Add(currKey);
                }

                string items = string.Join(",", convertedMutuals);

                mutuals.Add(currV, items);
            }
            public static int countVertices(string s) {
                int i = 0;

                for (int j=0; j<s.Length; j++) {
                    if (s[j] != ',') {
                        i++;
                    }
                }
                return i;
            }   
        }
        class utama{
            public static void Main(String[] args){
                Tubes2Stima.InputInt();
                Tubes2Stima.InputAkun();
            }
        }
    }
}

