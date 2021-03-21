using System;

namespace tubes_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var G = new Graph(4);
            G.AddEdge(0,2);
            G.Display();
        }
    }
}
