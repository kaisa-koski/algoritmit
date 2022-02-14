using System;

/// @author Kaisa Koski
/// @version 30.3.2021
/// <summary>
/// Taulukon järjestäminen kekolajittelulla
/// </summary>
public class Kekolajittelu
{
    /// <summary>
    /// Kekolajittelun testaus
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

        Console.WriteLine("Kokonaislukutaulukossa on seuraavat luvut:");
        Console.WriteLine(String.Join(" ", t));
        Lajittele(t);
        Console.WriteLine("Luvut lajiteltuna:");
        Console.WriteLine(String.Join(" ", t));
    }

    /// <summary>
    /// Lajittelee kekolajittelulla kokonaislukutaulukon
    /// nousevaan suuruusjärjestykseen.
    /// </summary>
    /// <param name="t">Lajiteltava taulukko</param>
    /// <example>
    /// <pre name="test">
    ///  int[] t1 = new int[]{2,1,4,3,5};
    ///  Lajittele(t1);
    ///  String.Join(" ", t1) === "1 2 3 4 5";
    ///  int[] t2 = new int[]{3,2,1};
    ///  Lajittele(t2);
    ///  String.Join(" ", t2) === "1 2 3";
    ///  int[] t3 = new int[]{-1,5,-3,4,0};
    ///  Lajittele(t3);
    ///  String.Join(" ", t3) === "-3 -1 0 4 5";
    ///  int[] t4 = new int[]{};
    ///  Lajittele(t4);
    ///  String.Join(" ", t4) === "";
    /// </pre>
    /// </example>
    public static void Lajittele(int[] t)
    {
        int[] keko = new int[t.Length + 1];
        for (int i = 0; i < t.Length; i++)
        {
            LisaaKekoon(keko, t[i]);
        }
        LajitteleKeko(keko);
        for (int i = 0, j = keko.Length - 1; i < t.Length; i++, j--)
        {
            t[i] = keko[j];
        }
    }

    /// <summary>
    /// Lisää luvun kekoon oikealle paikalle
    /// (minimiprioriteetti)
    /// </summary>
    /// <param name="keko">Keko johon lisätään</param>
    /// <param name="luku">Lisättävä luku</param>
    /// <example>
    /// <pre name="test">
    ///  int[] t5 = new int[]{2,1,5,0,0};
    ///  LisaaKekoon(t5, 6);
    ///  String.Join(" ", t5) === "3 1 5 6 0";
    ///  LisaaKekoon(t5, 3);
    ///  String.Join(" ", t5) === "4 1 3 6 5";
    ///  LisaaKekoon(t5, 4);
    ///  String.Join(" ", t5) === "4 1 3 6 5";
    ///  int[] t6 = new int[]{};
    ///  LisaaKekoon(t6, 5);
    ///  String.Join(" ", t6) === "";    
    /// </pre>
    /// </example>
    public static void LisaaKekoon(int[] keko, int luku)
    {
        if (keko.Length == 0 || keko[0] >= keko.Length - 1) return;
        int i = ++keko[0];
        while ((i > 1) && (keko[i / 2] > luku))
        {
            keko[i] = keko[i / 2];
            i /= 2;
        }
        keko[i] = luku;
    }

    /// <summary>
    /// Korjaa kekorakenteen parametrina annetun indeksin osalta
    /// (siirtää indeksissä olevan luvun oikeaan kohtaan kekorakenteessa.
    /// </summary>
    /// <param name="keko"></param>
    /// <param name="i"></param>
    /// <example>
    /// <pre name="test">
    ///  int[] t7 = new int[]{3,3,1,2};
    ///  KorjaaKeko(t7, 1);
    ///  String.Join(" ", t7) === "3 1 3 2";
    ///  int[] t8 = new int[]{3,1,3,2,0,0};
    ///  KorjaaKeko(t8, 2);
    ///  String.Join(" ", t8) === "3 1 3 2 0 0";
    ///  int[] t9 = new int[]{6,1,2,5,3,4,3,0,0};
    ///  KorjaaKeko(t9, 3);
    ///  String.Join(" ", t9) === "6 1 2 3 3 4 5 0 0";
    /// </pre>
    /// </example>
    public static void KorjaaKeko(int[] keko, int i)
    {
        if (keko.Length == 0) return;
        int j = 2 * i;
        if (j > keko[0]) return;
        int alkio = keko[i];
        while (j <= keko[0])
        {
            if ((j < keko[0]) && (keko[j] > keko[j + 1])) j += 1;
            if (alkio <= keko[j]) break;
            keko[j / 2] = keko[j];
            j = 2 * j;
        }
        keko[j / 2] = alkio;
    }

    /// <summary>
    /// Lajittelee keon kekolajittelulla laskevaan 
    /// suuruusjärjestykseen. Huom. taulukko 
    /// ei tämän jälkeen ole enää 
    /// kekorakenteen mukainen.
    /// </summary>
    /// <param name="keko">Lajiteltava keko</param>
    /// <example>
    /// <pre name="test">
    ///  int[] t10 = new int[]{4,1,3,2,4};
    ///  LajitteleKeko(t10);
    ///  String.Join(" ", t10) === "0 4 3 2 1";
    ///  int[] t11 = new int[]{5,1,3,2,4,5,0,0};
    ///  LajitteleKeko(t11);
    ///  String.Join(" ", t11) === "0 5 4 3 2 1 0 0";
    /// </pre>
    /// </example>
    public static void LajitteleKeko(int[] keko)
    {
        if (keko.Length == 0) return;
        while (keko[0] > 0) PoistaPienin(keko);
    }

    /// <summary>
    /// Palauttaa keon pienimmän ja siirtää sen keon 
    /// ulkopuolelle eli viimeisen virallisen indeksin jälkeiseksi.
    /// </summary>
    /// <param name="keko">Keko</param>
    /// <returns>Keon pienin</returns>
    /// <example>
    /// <pre name="test">
    ///  int[] t11 = new int[]{4,1,3,2,4};
    ///  PoistaPienin(t11) === 1;
    ///  String.Join(" ", t11) === "3 2 3 4 1";
    ///  PoistaPienin(t11) === 2;
    ///  String.Join(" ", t11) === "2 3 4 2 1";
    ///  PoistaPienin(t11) === 3;
    ///  String.Join(" ", t11) === "1 4 3 2 1";
    ///  PoistaPienin(t11) === 4;
    ///  String.Join(" ", t11) === "0 4 3 2 1";
    /// </pre>
    /// </example>
    public static int PoistaPienin(int[] keko)
    {
        if (keko.Length == 0 || keko[0] == 0) return 999;
        int viimeisenI = keko[0];
        int pienin = keko[1];
        keko[1] = keko[viimeisenI];
        keko[viimeisenI] = pienin;
        keko[0]--;
        KorjaaKeko(keko, 1);
        return pienin;
    }

}
