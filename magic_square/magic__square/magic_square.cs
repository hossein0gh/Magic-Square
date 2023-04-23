using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace magic_square
{
    public class magic_square
    {
        // Function to generate odd sized magic squares
        public static int[,] OddSquare(int n)
        {
            int[,] magicSquare = new int[n, n];

            // Initialize position for 1
            int i = n / 2;
            int j = n - 1;

            // One by one put all values in magic square
            for (int num = 1 ; num <= n * n ; )
            {
                if (i == -1 && j == n) // 3rd condition
                {
                    j = n - 2;
                    i = 0;
                }
                else
                {
                    // 1st condition helper if next number
                    // goes to out of square's right side
                    if (j == n)
                        j = 0;

                    // 1st condition helper if next number is
                    // goes to out of square's upper side
                    if (i < 0)
                        i = n - 1;
                }

                // 2nd condition
                if (magicSquare[i, j] != 0)
                {
                    j -= 2;
                    i++;
                    continue;
                }
                else
                    // set number
                    magicSquare[i, j] = num++;

                // 1st condition
                j++;
                i--;
            }
            return magicSquare;
        }

        // Function to generate (4n) Even sized magic squares
        public static int[,] EvenSquare1(int n)
        {
            int[,] MagicSquare = new int[n, n];
            int i, j;

            // filling matrix with its count
            // value starting from 1;
            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                    MagicSquare[i, j] = (n * i) + j + 1;

            // symmetrical swap 
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (i < n / 4 && n / 4 <= j && j < 3 * n / 4) { } // Top section isn't swaped.
                    else if (i >= 3 * n / 4 && n / 4 <= j && j < 3 * n / 4) { } //Bottom section isn't swaped.
                    else if (i >= n / 4 && i < 3 * n / 4 && j < n / 4) { } // Left section isn't swaped.
                    else if (i >= n / 4 && i < 3 * n / 4 && j >= 3 * n / 4) { } // Write section isn't swaped.
                    else MagicSquare[i, j] = (n * n + 1) - MagicSquare[i, j]; // Otherwise is swaped.
                }
            }
            return MagicSquare;
        }

        // Function to generate (4n+2) Even sized magic squares
        public static int[,] EvenSquare2(int n)
        {
            int[,] MagicSquare = new int[n, n];
            int i, j;
            int halfN = n / 2;
            int k = (n - 2) / 4;
            int temp=0;

            int[,] minimagic = new int[halfN, halfN];
            minimagic=OddSquare(halfN);
            for (i = 0; i < halfN; i++)
            {
                for (j = 0; j < halfN; j++)
                {
                    MagicSquare[i, j] = minimagic[i, j];
                    MagicSquare[i + halfN, j + halfN] = minimagic[i, j] + halfN * halfN;
                    MagicSquare[i, j + halfN] = minimagic[i, j] + 2 * halfN * halfN;
                    MagicSquare[i + halfN, j] = minimagic[i, j] + 3 * halfN * halfN;
                }
            }
            //swap elements in the left parts
            for(i=0;i<n/2;i++)
            {
                for(j=0;j<=k;j++)
                {
                    temp = MagicSquare[i + halfN, j];
                    MagicSquare[i + halfN, j] = MagicSquare[i, j];
                    MagicSquare[i, j] = temp;
                }
            }
            ///
            temp = MagicSquare[n/4, 0];
            MagicSquare[n/4, 0] = MagicSquare[n / 4 + halfN, 0];
            MagicSquare[n / 4 + halfN, 0] = temp;
            ///
            temp = MagicSquare[n / 4, k+1];
            MagicSquare[n / 4, k+1] = MagicSquare[n / 4 + halfN, k+1];
            MagicSquare[n / 4 + halfN, k+1] = temp;
            ///

            //swap elements in the write parts
            if (n > 6)
            {
                for (i = 0; i < n / 2; i++)
                {
                    for (j = n - k + 1; j < n; j++)
                    {
                        temp = MagicSquare[i + halfN, j];
                        MagicSquare[i + halfN, j] = MagicSquare[i, j];
                        MagicSquare[i, j] = temp;
                    }
                }
            }
            return MagicSquare;
        }
    }
}