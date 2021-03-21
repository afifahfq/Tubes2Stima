using System;

public abstract class Graph {
    protected int numV;
    protected int[,] matriks;

    public Graph(int numVertices) {
        this.numV = numVertices;
        this.matriks = new int[numV, numV];
        for (int row=0; row<numV; row++) {
            for (int col=0; col<numV; col++) {
                matriks[row, col] = 0;
            }
        }
    }

    public void AddEdge(int v1, int v2) {
        if (v1 >= this.numV || v2 >= this.numV || v1 < 0 || v2 < 0) {
            Console.Write("simpul invalid");
        }
        this.matriks[v1, v2] = 1;
        this.matriks[v2, v1] = 1;
    }

    public void Display() {
        int nRow = this.matriks.GetLength(0);
        int nCol = this.matriks.GetLength(1);

        for (int row=0; row<nRow; row++) {
            for (int col=0; col<nCol; col++) {
                Console.Write("{0}\t", this.matriks[row, col]);
            }
            Console.Write("\n\n");
        }
    }

}