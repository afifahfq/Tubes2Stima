// C# program to print BFS traversal 
// from a given source vertex. 
using System;
using System.Collections.Generic;
using System.Linq;

class Graph{
    static int nEdges, nVertices;
    static List<(char, string)> edgeList;
    static List<(int, int)> eL;
    static Dictionary<char, int> SimpulInt;
    static LinkedList<int>[] _adj; 
    //INI
    static string[] lines, line;
    static char[] simpulArray;
    static List<(int, char)> simpulAngka;
    static List<char> uniqueList;
    static int namaAkunInt, namaExploreInt, i, j;
	static int[] succ, pred;
    static char namaAkun, namaExplore;

    public Graph(int V) {
        _adj = new LinkedList<int>[V];
        for(int i = 0; i < _adj.Length; i++) {
            _adj[i] = new LinkedList<int>();
        }
        nVertices = V;
    }
    public void AddEdge1(int v, int w) {		 
        _adj[v].AddLast(w);
    }
    public void BFS(int s){ 
        bool[] visited = new bool[nVertices];
        for(int i = 0; i < nVertices; i++)
            visited[i] = false;
        
        LinkedList<int> queue = new LinkedList<int>();
        
        visited[s] = true;
        queue.AddLast(s);         
    
        while(queue.Any()){
            s = queue.First();
            Console.Write(s + " " );
            queue.RemoveFirst();
            
            LinkedList<int> list = _adj[s];
    
            foreach (var val in list){
                if (!visited[val]){
                    visited[val] = true;
                    queue.AddLast(val);
                }
            }
        }
    }
    static void InputInt(){
        lines = System.IO.File.ReadAllLines("input.txt");
        simpulAngka = new List<(int, char)>();
        uniqueList = new List<char>();

        nEdges = Int32.Parse(lines[0]);
        List<char> simpul = new List<char>();
        for (int i = 1; i <= nEdges; i++){
            line = lines[i].Split(' ');
            /* string items = string.Join(",", line);
            Console.WriteLine(items); */
            char u = lines[i][0];
            string v = line[1];
            // System.Console.WriteLine("Simpul Asal   : " + u);
            // System.Console.WriteLine("Simpul Tujuan : " + v);
            simpul.Add(u);
            simpul.Add(v[0]);
            //Console.WriteLine(simpul[i] + "{0}", i); 

            uniqueList = simpul.Distinct().ToList();
            //uniqueList.ForEach(i => Console.WriteLine($"{i}"));
        }

        /*string s_simpul = string.Join(",", simpul);
        Console.WriteLine(s_simpul);

        string s_unique = string.Join(",", uniqueList);
        Console.WriteLine(s_unique);

        string s_lines = string.Join(",", lines);
        Console.WriteLine(s_lines); */

        //INI SIMPUL
        simpulArray = uniqueList.ToArray(); //INI ABJAD
        //Console.WriteLine(simpulArray);
        Array.Sort(simpulArray);
        nVertices = simpulArray.Length;   // INI JUMLAH SIMPUL
        /* for (int i = 0; i < nVertices; i++){
            //Console.Write(simpulArray[i]);
            //Console.WriteLine("INI SIMPUL ARRAY : {0}", simpulArray.Length);
            //newsimpul = simpulArray.Distinct().ToArray();
        } */
        //Console.WriteLine();
        for (int i = 0; i < nVertices; i++){
            simpulAngka.Add((i+1, simpulArray[i]));
            //Console.WriteLine("{0}", i+1 + " = " + simpulArray[i]);
        }

        /*string s_angka = string.Join(",", simpulAngka);
        Console.WriteLine(s_angka); */

        // foreach (var a in simpulAngka){
        //     Console.WriteLine(a);
        // }

        SimpulInt = new Dictionary<char, int>();
        for (int i = 0; i < nVertices; i++){
            line = lines[i].Split(' ');
            SimpulInt[simpulArray[i]] = i;
            // Console.Write(SimpulInt[simpulArray[i]] + " "); // ini dalam bentuk integer
            // Console.WriteLine(simpulArray[i]); // ini abjadnya
        }

        //char awal = simpulArray[0];
        //Console.WriteLine(awal);
        //int root = SimpulInt[simpulArray[0]];
        //Console.WriteLine(root);
        //Console.WriteLine("INI " + SimpulInt[line[0]]);
        //Console.WriteLine("INI l0" + line[0]); // line[0] == c
        //int m = Int32.Parse(line[0]); // 13, m = nEdges
        eL = new List<(int, int)>();

        int uAngka;
        int vAngka;
        for (int i = 1; i <= nEdges; i++){
            line = lines[i].Split(' ');
            uAngka = SimpulInt[lines[i][0]];
            //Console.WriteLine("ini line1" + line[1][0]);
            vAngka = SimpulInt[line[1][0]];
            eL.Add((uAngka, vAngka));
            //Console.WriteLine("ini u : " + a);
            //Console.WriteLine("ini v : " + b);
        }
        // foreach((int a, int b) in eL){
        //      Console.WriteLine(a + " -> " + b);
        // } 
    }
    static void InputChar(){
        string[] lines, line;
        char[] simpulArray;
        List<(int, char)> simpulAngka;
        List<char> uniqueList;

        lines = System.IO.File.ReadAllLines("input.txt");
        edgeList = new List<(char, string)>();
        simpulAngka = new List<(int, char)>();
        uniqueList = new List<char>();
        
        nEdges = Int32.Parse(lines[0]);
        List<char> simpul = new List<char>();
        for (int i = 1; i <= nEdges; i++){
            line = lines[i].Split(' ');
            char u = lines[i][0];
            string v = line[1];//;lines[i]
            //System.Console.WriteLine("Simpul Asal   : " + u);
            //System.Console.WriteLine("Simpul Tujuan : " + v);
            edgeList.Add((u, v));
            simpul.Add(u);
            simpul.Add(v[0]);
            //Console.WriteLine(simpul[i] + "{0}", i); 

            uniqueList = simpul.Distinct().ToList();
            //uniqueList.ForEach(i => Console.WriteLine($"{i}"));
        }

        //INI SIMPUL BROK
        simpulArray = uniqueList.ToArray();
        Array.Sort(simpulArray);
        nVertices = simpulArray.Length;   // INI JUMLAH SIMPUL
        for (int i = 0; i < nVertices; i++){
            Console.Write(simpulArray[i]);
            //Console.WriteLine("INI SIMPUL ARRAY : {0}", simpulArray.Length);
            //newsimpul = simpulArray.Distinct().ToArray();
        }
        Console.WriteLine();
        for (int i = 0; i < nVertices; i++){
            simpulAngka.Add((i+1, simpulArray[i]));
            //Console.Write("{0}", simpulArrayHuruf + " = " + simpulArray[i]);
        }

        // foreach (var a in simpulAngka){
        //     Console.WriteLine(a);
        // }
                
        // foreach (var a in edgeList){
        //     Console.WriteLine(a);
        //     Console.WriteLine(a.Item1);
        //     Console.WriteLine(a.Item2);
        // }

        // foreach ((char a, string b) in edgeList){
        //     Console.WriteLine(a + " -> " + b);
        // }
    }
    static void ExploreFriends() {
        Console.Write("Choose Account : ");
        namaAkun = Console.ReadLine()[0];

        Console.Write("Explore friends with : ");
        namaExplore = Console.ReadLine()[0];
        Console.WriteLine();

        for (int i = 1; i <= nEdges; i++){
            line = lines[i].Split(' ');
            if (namaAkun == lines[i][0]){
                namaAkunInt = SimpulInt[lines[i][0]];
            }
            if (namaExplore == line[1][0]){
                namaExploreInt = SimpulInt[line[1][0]];
            }
        }
    }
     private static void addEdge(List<List<int>> adj, int i, int j){
		adj[i].Add(j);
		adj[j].Add(i);
	}
	private static void printShortestDistance(List<List<int>> adj) {
		pred = new int[nVertices];
		succ = new int[nVertices];
		
		Console.WriteLine("Nama akun: " + namaAkun + " dan " + namaExplore);
		if (BFS(adj) == false) {
            System.Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
            System.Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
			return;
		}
		
		List<int> path = new List<int>();
		int crawl = namaExploreInt;
		path.Add(crawl);
		
		while (pred[crawl] != -1){
			path.Add(pred[crawl]);
			crawl = pred[crawl];
		}
		
		if (succ[namaExploreInt] == 1){
            System.Console.WriteLine(succ[namaExploreInt]-1 + "st-degree connection");
        }
        else if (succ[namaExploreInt] == 2){
            System.Console.WriteLine(succ[namaExploreInt]-1 + "nd-degree connection");
        }
        else{
            System.Console.WriteLine(succ[namaExploreInt]-1 + "th-degree connection");
        }
        // if (namaAkun == lines[i][0]){A == A -> lines[i][0] = abjad
        //         namaAkunInt = SimpulInt[lines[i][0]]; -> integer
        //     }
		for (i = path.Count - 1; i >= 0; i--) {
			if (path[i] == namaExploreInt){
				Console.Write(path[i]);
				break;
			}
			Console.Write(path[i] + " -> ");
		}
	}
	private static bool BFS(List<List<int>> adj) {
		List<int> queue = new List<int>();
		bool []visited = new bool[nVertices];
		
		for (int i = 0; i < nVertices; i++){
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
     static void Main(string[] args) {
        InputInt();
        Graph g = new Graph(nVertices);
        //Console.WriteLine(nVertices);

        // foreach((int a, int b) in eL){
        //     Console.WriteLine(a + " -> " + b);
        //     g.AddEdge1(a-1 ,b-1);
        // }

        ExploreFriends();
		
		List<List<int>> adj = new List<List<int>>(nVertices);
		
		for (i = 0; i < nVertices; i++){
			adj.Add(new List<int>());
		}

        foreach((int a, int b) in eL){
            //Console.WriteLine(a + " -> " + b);
            addEdge(adj, a, b);
        }
		printShortestDistance(adj);

                     
    }
}