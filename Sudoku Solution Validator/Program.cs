using System;
using System.Collections.Generic;

namespace Sudoku_Solution_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ValidateSolution(new int[][]
        {
          new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
          new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
          new int[] {1, 9, 8, 3, 0, 2, 5, 6, 7},
          new int[] {8, 5, 0, 7, 6, 1, 4, 2, 3},
          new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
          new int[] {7, 0, 3, 9, 2, 4, 8, 5, 6},
          new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
          new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
          new int[] {3, 0, 0, 2, 8, 6, 1, 7, 9},
        });
        }

        public static bool ValidateSolution(int[][] board)
        {
            bool result = true;
            int[] rows = new int[board.Length];
            int[] col = new int[board.Length];
            int[] testMas = new int[board.Length];
            int[] pattern = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            //check rows
            for (int i = 0; i < board.Length; i++)
            {
                for (int k = 0; k < board.Length; k++)
                {
                    rows[k] = board[i][k];
                }
                Array.Sort(rows);
                for (int j = 0; j < board.Length; j++)
                {
                    if (pattern[j] != rows[j])
                    {
                        result = false;
                        break;
                    }
                }
            }

            //check col
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    col[j] = board[j][i];
                }
                Array.Sort(col);
                for (int k = 0; k < board.Length; k++)
                {
                    if (pattern[k] != col[k])
                    {
                        result = false;
                        break;
                    }
                }

            }

            //check boxes
            int minRow = 0;
            int maxRow = 3;
            int minCol = 0;
            int maxCol = 3;
            
            while (maxCol <= 9)
            {
                for (int i = 0; i < 3; i++)
                {
                    List<int> list = new List<int>();
                    for (int k = minRow; k < maxRow; k++)
                    {
                        for (int j = minCol; j < maxCol; j++)
                        {
                            //testMas[j] = board[i][j];
                            list.Add(board[k][j]);
                        }

                    }
                    minRow = maxRow;
                    maxRow += 3;
                    testMas = list.ToArray();
                    Array.Sort(testMas);
                    for (int k = 0; k < board.Length; k++)
                    {
                        if (pattern[k] != testMas[k])
                        {
                            result = false;
                            break;
                        }
                    }
                }
                minRow = 0;
                maxRow = 3;
                minCol = maxCol;
                maxCol += 3;
                
            }
            

            if (result)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("NOT OK");
            }

            return result;
        }
    }
}
