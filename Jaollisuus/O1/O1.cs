using System;
/// @author Kaisa Koski
/// @version 19.1.2021
public class O1
{
    /// Algoritmit 1
    /// Ohjelmointitehtävä O1
    /// Kirjoita ohjelma, jolla voidaan laskea, kuinka moni kokonaislukutaulukon alkioista on jaollinen 
    /// annetulla luvulla m.Muodosta taulukko, joka sisältää satunnaisia kokonaislukuja, ja laske kuinka 
    /// moni sen luvuista on jaollinen luvuilla m = 2, m= 3 ja m = 5.
    /// 
    /// <summary>
    /// Ohjelmassa luodaan satunnaisia lukuja sisältävä kokonaislukutaulukko
    /// ja lasketaan, kuinka monta taulukon alkioista on jaollisia luvuilla
    /// 2, 3 ja 5.
    /// </summary>
    public static void Main()
    {
        var rand = new Random();
        int min = 0;
        int max = 100;
        int[] t = new int[10];
        for (int i = 0; i < t.Length; i++)
        {
            t[i] = rand.Next(min, max);
        }
        int m2 = JaollistenMaara(t, 2);
        int m3 = JaollistenMaara(t, 3);
        int m5 = JaollistenMaara(t, 5);

        Console.WriteLine("Kokonaislukutaulukossa on seuraavat luvut:");
        Console.WriteLine(String.Join(" ", t));
        Console.WriteLine($"Kahdella jaollisten lukumäärä on {m2}");
        Console.WriteLine($"Kolmella jaollisten lukumäärä on {m3}");
        Console.WriteLine($"Viidellä jaollisten lukumäärä on {m5}");
    }


    /// <summary>
    /// Aliohjelma tutkii kuinka moni kokonaislukutaulukon arvoista on jaollinen 
    /// annetulla kokonaisluvulla.
    /// </summary>
    /// <param name="t">kokonaislukutaulukko</param>
    /// <param name="luku">kokonaisluku jolla jaetaan</param>
    /// <returns>jaollisten alkioiden määrä</returns>
    /// <example>
    /// <pre name="test">
    ///  int[] t = {1, 2, 3, 4, 5, 6};
    ///  JaollistenMaara(t, 2) === 3;
    ///  JaollistenMaara(t, 3) === 2;
    ///  JaollistenMaara(t, 5) === 1;
    ///  JaollistenMaara(t, 7) === 0;
    /// </pre>
    /// </example>
    public static int JaollistenMaara(int[] t, int luku)
    {
        int lkm = 0;
        foreach (int alkio in t)
        {
            if (alkio % luku == 0) lkm++;
        }
        return lkm;
    }
}
