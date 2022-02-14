using System;
using System.Text;

/// @author Kaisa Koski
/// @version 1.2.2021
/// <summary>
/// Ohjelmassa demonstroidaan pinon operaatioita aliohjelmien avulla.
/// </summary>
public class Pino
{
    /// <summary>
    /// Testataan ja esitellään pino-operaatioiden mukaisia aliohjelmia.
    /// </summary>
    public static void Main()
    {
        int[] pino = new int[5];
        Console.WriteLine("Pino tyhjä: " + IsEmpty(pino));
        Console.WriteLine("Aluksi pino on tyhjä: " + Mj(pino));
        Console.WriteLine("Silloin pinon koko on: " + Size(pino));
        Console.WriteLine("Laitetaan pinoon numeroita seuraavassa järjestyksessä: 5, 3, 8, 4, 2 ");
        Push(pino, 5);
        Push(pino, 3);
        Push(pino, 8);
        Push(pino, 4);
        Push(pino, 2);
        Console.WriteLine("Nyt pinossa on: " + Mj(pino));
        Console.WriteLine("Nyt pinon koko on: " + Size(pino));
        Console.WriteLine("Pino tyhjä: " + IsEmpty(pino));
        Console.WriteLine("Otetaan pinon päällimmäinen: " + Pop(pino));
        Console.WriteLine("Nyt pinossa on: " + Mj(pino));
        Console.WriteLine("Katsotaan mikä pinon päällimmäisenä on nyt: " + Top(pino));
        Console.WriteLine("Mutta tätä ei otettu kuitenkaan pinosta pois: " + Mj(pino));

    }


    /// <summary>
    /// Aliohjelma tekee taulukosta merkkijonon, josta pelkät nollat on poistettu.
    /// </summary>
    /// <param name="t">Taulukko(pino) joka muutetaan merkkijonoksi</param>
    /// <returns>Taulukko merkkijonona ilman nollia</returns>
    public static string Mj(int[] t)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < t.Length; i++)
        {
            int luku = t[i];
            if (luku == 0) continue;
            sb.Append(luku + " ");
        }
        return sb.ToString().Trim();
    }

    /// <summary>
    /// Aliohjelma etsii kokonaislukutaulukon viimeisen kohdan, jossa
    /// on nolla (=pinon päällimmäinen kohta), ja laittaa parametrina 
    /// annetun luvun siihen. 
    /// </summary>
    /// <param name="t">Kokonaislukutaulukko (pino)</param>
    /// <param name="luku">Luku, joka laitetaan pinon päällimmäiseksi</param>
    public static void Push(int[] t, int luku)
    {
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == 0)
            {
                t[i] = luku;
                break;
            }
        }
    }


    /// <summary>
    /// Aliohjelma etsii kokonaislukutaulukon viimeisen kohdan, jossa
    /// on joku muu luku kuin nolla (=pinon päällimmäinen kohta), poistaa
    /// luvun taulukosta ja palauttaa sen.
    /// </summary>
    /// <param name="t">Kokonaislukutaulukko (pino)</param>
    /// <returns>Pinon päällimmäinen</returns>
    public static int Pop(int[] t)
    {
        int paallimmainen = t[^1];
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == 0)
            {
                paallimmainen = t[i - 1];
                t[i - 1] = 0;
                return paallimmainen;
            }
        }
        t[^1] = 0;
        return paallimmainen;
    }


    /// <summary>
    /// Aliohjelma etsii, onko kokonaislukutaulukossa pelkkiä nollia
    /// (=onko pino tyhjä).
    /// </summary>
    /// <param name="t">Kokonaislukutaulukko (pino)</param>
    /// <returns>Onko pino tyhjä (taulukossa pelkkiä nollia)</returns>
    public static Boolean IsEmpty(int[] t)
    {
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] != 0) return false;
        }
        return true;
    }


    /// <summary>
    /// Aliohjelma palauttaa kuinka monta nollasta poikkkeavaa arvoa
    /// taulukossa on (=pinon koko).
    /// </summary>
    /// <param name="t">taulukko (pino)</param>
    /// <returns>Pinon koko eli nollasta poikkeavien arvojen määrä</returns>
    public static int Size(int[] t)
    {
        int koko = 0;
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == 0) break;
            koko++;
        }
        return koko;
    }


    /// <summary>
    /// Aliohjelma etsii kokonaislukutaulukon viimeisen kohdan, jossa
    /// on joku muu luku kuin nolla (=pinon päällimmäinen kohta), ja palauttaa sen,
    /// mutta ei poista sitä taulukosta/pinosta.
    /// </summary>
    /// <param name="t">taulukko (pino)</param>
    /// <returns>Taulukon viimeinen nollasta poikkeava luku eli pinon päällimmäinen</returns>
    public static int Top(int[] t)
    {
        int paallimmainen = t[^1];
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == 0)
            {
                paallimmainen = t[i - 1];
                break;
            }
        }
        return paallimmainen;
    }

}
