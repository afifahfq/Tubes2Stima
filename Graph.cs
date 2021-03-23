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

    public Graph(int V) {
        _adj = new LinkedList<int>[V];
        for(int i = 0; i < _adj.Length; i++) {
            _adj[i] = new LinkedList<int>();
        }
        nVertices = V;
    }
    public void AddEdge(int v, int w) {		 
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
        string[] lines, line;
        char[] simpulArray;
        char namaAkun, namaExplore;
        List<(int, char)> simpulAngka;
        List<char> uniqueList;

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
            /*System.Console.WriteLine("Simpul Asal   : " + u);
            System.Console.WriteLine("Simpul Tujuan : " + v); */
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

        //INI SIMPUL BROK
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
            SimpulInt[simpulArray[i]] = i+1;
            Console.Write(SimpulInt[simpulArray[i]] + " "); // ini dalam bentuk integer
            Console.WriteLine(simpulArray[i]); // ini abjadnya
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
        foreach((int a, int b) in eL){
             Console.WriteLine(a + " -> " + b);
        } 
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

        foreach (var a in simpulAngka){
            Console.WriteLine(a);
        }
                
        // foreach (var a in edgeList){
        //     Console.WriteLine(a);
        //     Console.WriteLine(a.Item1);
        //     Console.WriteLine(a.Item2);
        // }

        foreach ((char a, string b) in edgeList){
            Console.WriteLine(a + " -> " + b);
        }
    }

    static void ExploreFriends() {
        char namaAkun, namaExplore;

        Console.WriteLine();
        Console.Write("Choose Account : ");
        namaAkun = Console.ReadLine()[0];

        Console.Write("Explore friends with : ");
        namaExplore = Console.ReadLine()[0];
        Console.WriteLine();


        Boolean found1 = false; 
        Boolean found2 = false;
        foreach ((char a, string b) in edgeList){
            if ((namaAkun == a) || (namaAkun == b[0])){
                found1 = true;
                //System.Console.WriteLine("ini namaAkun Sama : " + namaAkun);
            }
            if ((namaExplore == a) || (namaExplore == b[0])){
                found2 = true;
                //System.Console.WriteLine("ini namaExplore Sama : " + namaExplore);
            }
        }

        if (found1 && found2){
            System.Console.WriteLine("Nama Akun : " + namaAkun + " dan " + namaExplore);
            System.Console.WriteLine("Ini Ada 2 2 nya");
            System.Console.WriteLine(namaAkun + "->" + namaExplore);
        }
        else{
            System.Console.WriteLine("Nama Akun : " + namaAkun + " dan " + namaExplore);
            System.Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
            System.Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
        }
    }

    static void ABFS(int jarak) {
        if (jarak == 1){
            System.Console.WriteLine(jarak + "st-degree connection");
        }
        else if (jarak == 2){
            System.Console.WriteLine(jarak + "nd-degree connection");
        }
        else{
            System.Console.WriteLine(jarak + "th-degree connection");
        }
        
        // foreach (var a in edgeList){
        //     Console.WriteLine(a);
        //     isisimpul1 = a.Item1;
        //     string isisimpul2 = a.Item2;
            //Console.WriteLine(a.Item1);
            //Console.WriteLine(a.Item2);
        //}
        //Console.WriteLine(isisimpul1);


    }
 
    static void Main(string[] args) {
        //BFS(5);
        InputInt();
        Graph g = new Graph(nVertices);
        Console.WriteLine(nVertices);

        foreach((int a, int b) in eL){
            Console.WriteLine(a + " -> " + b);
            g.AddEdge(a-1 ,b-1);
        }

        /* Cek isi _adj
        for(int i=0; i<nVertices; i++ ){
            foreach (var vertice in _adj[i]) {
                Console.Write(vertice);
            }            
            Console.WriteLine();
        } */
        //g.BFS(2);
                
    }
}