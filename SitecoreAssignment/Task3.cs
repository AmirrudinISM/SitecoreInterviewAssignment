using System;
using System.Collections;
using System.Collections.Generic;

//Algorithm obtained from Aarthi Rathi https://www.geeksforgeeks.org/shortest-distance-two-cells-matrix-grid/

// QItem for current location and distance
// from source location
public class QItem {
    public int row;
    public int col;
    public int dist;
    public QItem prev;
   

    public QItem(int x, int y, int w, QItem prev) {
        this.row = x;
        this.col = y;
        this.dist = w;
        this.prev = prev;
    }

}

public static class GFG {


    public static int minDistance(char[,] grid, int N, int M) {
        QItem source = new QItem(0, 0, 0, null);

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

        if (source.row - 1 >= 0 && visited[source.row - 1, source.col] == false) {
            Console.Write("Totoshka ({0},{1}),", source.row - 1, source.col);
            adjacency++;
        }

        // moving down
        if (source.row + 1 < N && visited[source.row + 1, source.col] == false) {
            Console.Write("Totoshka ({0},{1}),", source.row + 1, source.col);
            adjacency++;
        }

        //left
        if (source.col - 1 >= 0 && visited[source.row, source.col - 1] == false) {
            Console.Write("Totoshka ({0},{1}),", source.row, source.col - 1);
            adjacency++;
        }

        //right
        if (source.col + 1 < M && visited[source.row, source.col + 1] == false) {
            Console.Write("Totoshka ({0},{1}),", source.row, source.col + 1);
            adjacency++;
        }

        // upright
        if (source.row - 1 >= 0 && source.col + 1 < M && visited[source.row - 1, source.col + 1] == false) {
            Console.Write("Totoshka ({0},{1}),", source.row - 1, source.col + 1);
            adjacency++;
        }

        //move downright
        if (source.row + 1 < N && source.col + 1 < M && visited[source.row + 1, source.col + 1] == false) {
            Console.Write("Totoshka ({0},{1}),", source.row + 1, source.col + 1);
            adjacency++;
        }

        //move downleft

        if (source.row + 1 < N && source.col - 1 >= 0 && visited[source.row + 1, source.col - 1] == false) {
            Console.Write("Totoshka ({0},{1}),", source.row + 1, source.col - 1);
            adjacency++;
        }

        //move upleft
        if (source.row - 1 >= 0 && source.col - 1 >= 0 && visited[source.row - 1, source.col - 1] == false) {
            Console.Write("Totoshka ({0},{1}),", source.row - 1, source.col - 1);
            adjacency++;
        }
        Console.WriteLine();
        if (adjacency == 0) Console.WriteLine("No room for Tatoshka");

        // applying BFS on matrix cells starting from source
        Queue<QItem> q = new Queue<QItem>();
        q.Enqueue(source);
        visited[source.row, source.col] = true;
        QItem dest = null;
        QItem p = null;
        while (q.Count > 0) {
            p = q.Peek();
            q.Dequeue();
            // Destination found;
            if (grid[p.row, p.col] == 'd') {
                dest = p;
                break;
            }

            // moving up
            if (p.row - 1 >= 0 && visited[p.row - 1, p.col] == false) {
                q.Enqueue(new QItem(p.row - 1, p.col, p.dist + 1, p));
                visited[p.row - 1, p.col] = true;
            }

            // moving down
            if (p.row + 1 < N && visited[p.row + 1, p.col] == false) {
                q.Enqueue(new QItem(p.row + 1, p.col, p.dist + 1, p));
                visited[p.row + 1, p.col] = true;
            }

            // moving left
            if (p.col - 1 >= 0 && visited[p.row, p.col - 1] == false) {
                q.Enqueue(new QItem(p.row, p.col - 1, p.dist + 1, p));
                visited[p.row, p.col - 1] = true;
            }

            // moving right
            if (p.col + 1 < M && visited[p.row, p.col + 1] == false) {
                q.Enqueue(new QItem(p.row, p.col + 1, p.dist + 1, p));
                visited[p.row, p.col + 1] = true;
            }

            //move upright
            if (p.row - 1 >= 0 && p.col + 1 < M  && visited[p.row - 1, p.col + 1] == false) {
                q.Enqueue(new QItem(p.row - 1, p.col + 1, p.dist + 1, p));
                visited[p.row - 1, p.col + 1] = true;
            }

            //move downright
            if (p.row + 1 < N && p.col + 1 < M && visited[p.row + 1, p.col + 1] == false) {
                q.Enqueue(new QItem(p.row + 1, p.col + 1, p.dist + 1, p));
                visited[p.row + 1, p.col + 1] = true;
            }

            //move downleft
            if (p.row + 1 < N && p.col - 1 >= 0 && visited[p.row + 1, p.col - 1] == false) {
                q.Enqueue(new QItem(p.row + 1, p.col - 1, p.dist + 1, p));
                visited[p.row + 1, p.col - 1] = true;
            }

            //move upleft
            if (p.row - 1 >= 0 && p.col - 1 >= 0 && visited[p.row - 1, p.col - 1] == false) {
                q.Enqueue(new QItem(p.row - 1, p.col - 1, p.dist + 1, p));
                visited[p.row - 1, p.col - 1] = true;
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

    public static void printPath(QItem dest) {
        if (dest == null) return;

        // print list of head node
        printPath(dest.prev);

        // After everything else is printed
        Console.WriteLine("({0},{1}),", dest.row, dest.col);
    }
}

// This code is contributed by Aarti_Rathi
