using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author Kaisa Koski
/// @version 14.2.2020
///
/// Algoritmit 1
/// Ohjelmointitehtävä O4
/// Kirjoita ohjelma, joka toteuttaa kaksi erilaista lajittelualgoritmia kokonaislukutaulukoille. 
/// Testaa menetelmiä satunnaisilla taulukoilla. Varmista, että menetelmät toimivat oikein toisistaan 
/// riippumatta, eli testaa niitä eri taulukoilla.
///
public class Lajittelu
{
    /// <summary>
    /// Testataan erilaisten lajittelualiohjelmien toimintaa.
    /// </summary>
    public static void Main()
    {
        int[] t1 = new int[10];
        int[] t2 = new int[10];
        int min = 0, max = 10;
        Random rand = new Random();
        for (int i = 0; i < t1.Length; i++)
        {
            t1[i] = rand.Next(min, max);
            t2[i] = rand.Next(min, max);
        }

        Console.WriteLine("Ensimmäinen taulukko aluksi:");
        Console.WriteLine(String.Join(" ", t1));
        Kuplalajittelu(t1);
        Console.WriteLine("Kuplalajittelun jälkeen:");
        Console.WriteLine(String.Join(" ", t1));
        Console.WriteLine();

        Console.WriteLine("Toinen taulukko aluksi:");
        Console.WriteLine(String.Join(" ", t2));
        Lisayslajittelu(t2);
        Console.WriteLine("Lajittelun jälkeen:");
        Console.WriteLine(String.Join(" ", t2));
    }


    /// <summary>
    /// Aliohjelma lajittelee kokonaislukutaulukun kuplalajittelulla.
    /// </summary>
    /// <param name="t">Kokonaislukutaulukko</param>
    /// <example>
    /// <pre name="test">
    ///  int[] t1 = new int[]{5, 1, 4, 2, 3};
    ///  Kuplalajittelu(t1);
    ///  String.Join(" ", t1) === "1 2 3 4 5";
    ///  int[] t2 = new int[]{4, 3, 2, 5, 1};
    ///  Kuplalajittelu(t2);
    ///  String.Join(" ", t2) === "1 2 3 4 5";
    ///  int[] t3 = new int[]{1, 2, 3, 4, 5};
    ///  Kuplalajittelu(t3);
    ///  String.Join(" ", t3) === "1 2 3 4 5";
    ///  int[] t4 = new int[]{5, 4, 3, 2, 1};
    ///  Kuplalajittelu(t4);
    ///  String.Join(" ", t4) === "1 2 3 4 5";
    /// </pre>
    /// </example>
    public static void Kuplalajittelu(int[] t)
    {
        for (int i = 0; i < t.Length-1; i++)
        {
            for (int j = t.Length - 2; j >= i; j--)
            {
                if (t[j + 1] < t[j])
                {
                    int apu = t[j];
                    t[j] = t[j + 1];
                    t[j + 1] = apu;
                }
            }
        }
    }


    /// <summary>
    ///  Aliohjelma lajittelee kokonaislukutaulukun lisäyslajittelulla.
    /// </summary>
    /// <param name="t">Kokonaislukutaulukko</param>
    /// <example>
    /// <pre name="test">
    ///  int[] t1 = new int[]{5, 1, 4, 2, 3};
    ///  Lisayslajittelu(t1);
    ///  String.Join(" ", t1) === "1 2 3 4 5";
    ///  int[] t2 = new int[]{4, 3, 2, 5, 1};
    ///  Lisayslajittelu(t2);
    ///  String.Join(" ", t2) === "1 2 3 4 5";
    ///  int[] t3 = new int[]{1, 2, 3, 4, 5};
    ///  Lisayslajittelu(t3);
    ///  String.Join(" ", t3) === "1 2 3 4 5";
    ///  int[] t4 = new int[]{5, 4, 3, 2, 1};
    ///  Lisayslajittelu(t4);
    ///  String.Join(" ", t4) === "1 2 3 4 5";
    ///  int[] t5 = new int[]{5, 1, 4, 3, 2};
    ///  Lisayslajittelu(t5);
    ///  String.Join(" ", t5) === "1 2 3 4 5";
    /// </pre>
    /// </example>
    public static void Lisayslajittelu(int[] t)
    {
        for (int i = 1; i < t.Length; i++)
        {
            int luku = t[i];
            for (int j = i - 1; j >= 0; j--)
            {
                if (t[j] > luku)
                {
                    t[j + 1] = t[j];
                }
                else
                {
                    t[j + 1] = luku;
                    break;
                }
               t[j] = luku;
            }
        }
    }

}
