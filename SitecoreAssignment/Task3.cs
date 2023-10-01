using System;
using System.Collections;
using System.Collections.Generic;

//References: (1) Aarthi Rathi https://www.geeksforgeeks.org/shortest-distance-two-cells-matrix-grid/
//            (2) 29AjayKumar https://www.geeksforgeeks.org/breadth-first-traversal-bfs-on-a-2d-array/


// QItem for current location and distance
// from source location
public class Node {
    public int row;
    public int col;
    public int dist;
    public Node prev;
   

    public Node(int x, int y, int w, Node prev) {
        this.row = x;
        this.col = y;
        this.dist = w;
        this.prev = prev;
    }

}

public static class GFG {

    static List<Node> tatoshkaStartPoints = new List<Node>();

    public static int minDistance(char[,] grid) {
        int N = grid.GetLength(0);
        int M = grid.GetLength(1);

        //directional vectors that also includes diagonal directions
        int[] dRow = { -1, 0, 1, 0, -1, 1, 1, -1 };
        int[] dCol = { 0, 1, 0, -1, 1, 1, -1, -1 };
        Node source = new Node(0, 0, 0, null);

        // To keep track of visited QItems. Marking
        // blocked cells as visited.
        bool[,] visited = new bool[N, M];


        for (int i = 0; i < N; i++) {
            for (int j = 0; j < M; j++) {
                if (grid[i, j] == '0') {
                    visited[i, j] = true;
                }
                else {
                    visited[i, j] = false;
                }

                // Finding source
                if (grid[i, j] == 's') {
                    source.row = i;
                    source.col = j;
                }
            }
        }
        int adjacency = 0;
        //check starting position for Tatoshka
        for (int i = 0; i < 8; i++) {
            int tatoshkaPosRow = source.row + dRow[i];
            int tatoshkaPosCol = source.col + dCol[i];
            if (isValid(visited, tatoshkaPosRow, tatoshkaPosCol, N, M)) {
                adjacency++;
                Console.WriteLine("Tatoshka: ({0},{1})", tatoshkaPosRow, tatoshkaPosCol);
                tatoshkaStartPoints.Add(new Node(tatoshkaPosRow, tatoshkaPosCol, 0, null));
            }
            
        }

        if (adjacency == 1) Console.WriteLine("No starting position for Tatoshka");

        // applying BFS on matrix cells starting from source
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(source);
        visited[source.row, source.col] = true;

        Node dest = null;
        Node p = null;

        while (q.Count > 0) {
            p = q.Peek();
            q.Dequeue();

            // Destination found;
            if (grid[p.row, p.col] == 'd') {
                dest = p;
                break;
            }

            for (int i = 0; i < 8; i++) {
                int adjx = p.row + dRow[i];
                int adjy = p.col + dCol[i];

                if (isValid(visited, adjx, adjy, N, M)) {
                    q.Enqueue(new Node(adjx, adjy, p.dist + 1, p));
                    visited[adjx, adjy] = true;
                }
            }

        }

        if (dest == null) {
            Console.WriteLine("there is no path.");
            return -1;
        }
        else {
            p = dest;
            //use recursion to print in reverse
            printPath(p);
           
            return dest.dist;
        }
    }

    public static void printPath(Node dest) {
        if (dest == null) return;

        // print list of head node
        printPath(dest.prev);

        // After everything else is printed
        
        Console.WriteLine("({0},{1}),", dest.row, dest.col);
    }

    public static bool isValid(bool[,] vis, int row, int col, int gridRow, int gridCol) {
        // If cell lies out of bounds
        if (row < 0 || col < 0 || row >= gridRow || col >= gridCol)
            return false;

        // If cell is already visited
        if (vis[row, col])
            return false;

        // Otherwise
        return true;
    }
}

