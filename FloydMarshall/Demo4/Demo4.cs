using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author Omanimi
/// @version Päivämäärä
/// <summary>
/// 
/// </summary>
public class Demo4
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int max = 99;
        int[,] m = new int[4, 4] { { 0, 15, 40, 18 },
                                   {25, 0, 23, max },
                                   {max, max, 0, 10},
                                   {max, 32, 8, 0 } };
        Print2DArray(m);
        Console.WriteLine();
        while (FloMa(m))
        {
            Print2DArray(m);
        }
    }

    public static Boolean FloMa(int[,] m)
    {
        Boolean muuttuu = false;
        for (int k = 0; k < m.GetLength(0); k++)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(0); j++)
                {
                    if (m[i, k] + m[k, j] < m[i, j])
                    {
                        Console.WriteLine(@"Reitillä {0} -> {2} -> {1} lyhemmän reitin pituus on {3}", i, j, k, (m[i, k] + m[k, j]));
                        m[i, j] = m[i, k] + m[k, j];
                        muuttuu = true;
                    }
                }
            }
        }
        Console.WriteLine();
        return muuttuu;
    }

    static public void Print2DArray(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                //put a single value
                Console.Write(matrix[i, k]+"  ");
            }
            //next row
            Console.WriteLine();
        }
    }

}
