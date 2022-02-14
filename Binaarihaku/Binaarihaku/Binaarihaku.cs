using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author Kaisa Koski
/// @version 24.2.2021
///
/// Algoritmit 1
/// Ohjelmointitehtävä O5
/// Kirjoita ohjelma, joka toteuttaa binäärihaun (puolitushaun) kokonaislukutaulukoille. 
/// Testaa ohjelmaasi satunnaisella (mutta järjestetyllä!) taulukolla.


public class Binaarihaku
{
    /// <summary>
    /// Testataan binäärihakua
    /// </summary>
    public static void Main()
    {
        int[] t1 = new int[100];
        int min = 0, max = 100;
        Random rand = new Random();
        for (int i = 0; i < t1.Length; i++)
        {
            t1[i] = rand.Next(min, max);
        }

        Array.Sort(t1);

        Console.WriteLine("Taulukon numerot:");
        Console.WriteLine(String.Join(" ", t1));
        int luku = 13;
        int indeksi = BinHaku(t1, luku);
        if (indeksi != -1) Console.WriteLine("Luku " + luku + " löytyy indeksistä " + indeksi);
        else Console.WriteLine("Ei löytynyt lukua " + luku);
    }
    /// <summary>
    ///  Etsii pyydettyä lukua järjestetystä taulukosta binäärihaun avulla. 
    ///  Palauttaa joko luvun indeksin tai -1 jos lukua ei löydy.
    /// </summary>
    /// <param name="t">Kokonaislukutaulukko</param>
    /// <returns>Etsityn luvun indeksi</returns>
    /// <example>
    /// <pre name="test">
    ///  int[] t1 = new int[]{1,2,3,5,6,7,8};
    ///  BinHaku(t1, 2) === 1;
    ///  BinHaku(t1, 1) === 0;
    ///  BinHaku(t1, 7) === 5;
    ///  BinHaku(t1, 9) === -1;
    ///  BinHaku(t1, 4) === -1;
    /// </pre>
    /// </example>
    public static int BinHaku(int[] t, int luku)
    {
        int indeksi = -1;
        int alaraja = -1;
        int ylaraja = t.Length;

        while (ylaraja - alaraja > 1)
        {
            int puolivali = (alaraja + ylaraja) / 2;
            if (luku <= t[puolivali]) ylaraja = puolivali;
            else alaraja = puolivali;
        }
        if (ylaraja < t.Length && t[ylaraja] == luku) indeksi = ylaraja;
        return indeksi;
    }

}
