// C# program to print BFS traversal 
// from a given source vertex. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Graph{
    private int _V; 
    LinkedList<int>[] _adj; 

    public Graph(int V) {
        _adj = new LinkedList<int>[V];
        for(int i = 0; i < _adj.Length; i++) {
            _adj[i] = new LinkedList<int>();
        }
        _V = V;
    }

    public void AddEdge(int v, int w) {		 
        _adj[v].AddLast(w);
    }
    
    public void BFS(int s) {
        bool[] visited = new bool[_V];
        for(int i = 0; i < _V; i++)
            visited[i] = false;
        
        LinkedList<int> queue = new LinkedList<int>();
        
        visited[s] = true;
        queue.AddLast(s);		 

        while(queue.Any()) {
            s = queue.First();
            Console.Write(s + " " );
            queue.RemoveFirst();
            
            LinkedList<int> list = _adj[s];

            foreach (var val in list) {
                if (!visited[val]) {
                    visited[val] = true;
                    queue.AddLast(val);
                }
            }
        }
    }

    // public void input(int x){
    //     // Graph g = new Graph(13);
    //     /g.input(13);
    //     Graph g = new Graph(4); 
     
    //     g.AddEdge(0, 1); 
    //     g.AddEdge(0, 2); 
    //     g.AddEdge(1, 2); 
    //     g.AddEdge(2, 0); 
    //     g.AddEdge(2, 3); 
    //     g.AddEdge(3, 3);
        
    //     Console.Write("Ini BFS : ");
    //     g.BFS(2);

    //     System.Console.WriteLine();
    // }

    static void Main(string[] args) {
        int jumlahSimpul, i;
        char namaAkun, namaExplore;
        string[] lines = System.IO.File.ReadAllLines("input.txt");
        //char[] line;
        List<(char, char)> edgeList;
        edgeList = new List<(char, char)>();
        Boolean found1, found2;
        char[] friends;
        
        jumlahSimpul = Int32.Parse(lines[0]);

        for (i = 1; i <= jumlahSimpul; i++){
            //line = lines[i].Split(' ');
            char[] line = lines[i].ToCharArray();
            char u = lines[i][0];
            char v = line[2];//;lines[i]
            System.Console.WriteLine("Simpul Asal   : " + u);
            System.Console.WriteLine("Simpul Tujuan : " + v);
            edgeList.Add((u, v));
        }
        
        foreach (var a in edgeList){
            Console.WriteLine(a);
            //Console.WriteLine(a.Item1);
            
        }
    
        Console.Write("Choose Account : ");
        namaAkun = Console.ReadLine()[0];

        Console.Write("Explore friends with : ");
        namaExplore = Console.ReadLine()[0];
        Console.WriteLine();

        found1 = false; found2 = false;
        for (i = 1; i <= jumlahSimpul; i++) {
            if (namaAkun == lines[i][0]){
                found1 = true;
                //System.Console.WriteLine("ini namaAkun Sama : " + namaAkun);
            }

            if (namaExplore == lines[i][0]){
                found2 = true;
                //System.Console.WriteLine("ini namaExplore Sama : " + namaExplore);
            }
        }

        if (found1 && found2){
            System.Console.WriteLine("Nama Akun : " + namaAkun + " dan " + namaExplore);
            System.Console.WriteLine("Ini Ada 2 2 nya");
        }
        else{
            System.Console.WriteLine("Nama Akun : " + namaAkun + " dan " + namaExplore);
            System.Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
            System.Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
        }


    }
}
