using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author Kaisa Koski
/// @version 13.4.2021
/// <summary>
/// Hajautustaulukon toteutus avoimella osoitteenmuodostuksella
/// käyttäen lineaarista etsintää.
/// </summary>
public class Hajautus
{
    private const int VAPAA = 0;
    private const int POISTETTU = -1;
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int[] hajautustaulukko = new int[10];
        int[] apu = new int[10];
        Random ran = new Random();
        Console.WriteLine("Hajautustaulukko nyt: " + String.Join(" ", hajautustaulukko) + "\n");
        for (int i = 0; i < 11; i++)
        {
            int luku = ran.Next(1, 100);
            Console.WriteLine(Lisaa(hajautustaulukko, luku));
            Console.WriteLine("Hajautustaulukko nyt: " + String.Join(" ", hajautustaulukko) + "\n");
            if (i < 10) apu[i] = luku;
        }
        for (int j = 0; j < 6; j++)
        {
            int indeksi = ran.Next(10);
            Console.WriteLine(Poista(hajautustaulukko, apu[indeksi]));
            Console.WriteLine("Hajautustaulukko nyt: " + String.Join(" ", hajautustaulukko) + "\n");
        }
        for (int i = 0; i < 7; i++)
        {
            int luku = ran.Next(1, 100);
            Console.WriteLine(Lisaa(hajautustaulukko, luku));
            Console.WriteLine("Hajautustaulukko nyt: " + String.Join(" ", hajautustaulukko) + "\n");
        }

    }

    /// <summary>
    /// Hajautusfunktio, jolla muodostetaan alkion
    /// osoite avainarvon perusteella ottamalla
    /// avainarvosta hajautustaulukon koon jakojäännös.
    /// </summary>
    /// <param name="t">Hajautus</param>
    /// <param name="avain">Avainarvo</param>
    /// <returns>Avainarvon osoite</returns>
    /// <example>
    /// <pre name="test">
    ///  int[] t = new int[10];
    ///  Hajauta(t, 10) === 0;
    ///  Hajauta(t, 36) === 6;
    ///  Hajauta(t, 55) === 5;
    ///  Hajauta(t, 99) === 9;
    /// </pre>
    /// </example>
    public static int Hajauta(int[] t, int avain)
    {
        return avain % t.Length;
    }


    /// <summary>
    /// Lisää kokonaisluvun hajautustaulukkoon.
    /// Palauttaa merkkijonon joka kertoo, onnistuiko
    /// lisäys.
    /// </summary>
    /// <param name="t">Hajautustaulukko</param>
    /// <param name="lisattava">Lisättävä arvo</param>
    /// <returns>Merkkijono, joka kertoo onnistuiko</returns>
    /// <example>
    /// <pre name="test">
    ///  int[] t2 = new int[10];
    ///  Lisaa(t2, 5) === "Alkio 5 lisätty";
    ///  Lisaa(t2, 26) === "Alkio 26 lisätty";
    ///  Lisaa(t2, 36) === "Alkio 36 lisätty";
    ///  Lisaa(t2, 44) === "Alkio 44 lisätty";
    ///  Lisaa(t2, 88) === "Alkio 88 lisätty";
    ///  Lisaa(t2, 10) === "Alkio 10 lisätty";
    ///  String.Join(" ", t2) === "10 0 0 0 44 5 26 36 88 0";
    /// </pre>
    /// </example>
    public static String Lisaa(int[] t, int lisattava)
    {
        int aloitus = Hajauta(t, lisattava);
        int i = aloitus;
        while (i < t.Length)
        {
            if (t[i] == VAPAA || t[i] == POISTETTU)
            {
                t[i] = lisattava;
                return "Alkio " + lisattava + " lisätty";
            }
            i++;
        }
        i = 0;
        while (i < aloitus)
        {
            if (t[i] == VAPAA || t[i] == POISTETTU)
            {
                t[i] = lisattava;
                return "Alkio " + lisattava + " lisätty";
            }
            i++;
        }
        return "Alkiota " + lisattava + " ei voitu lisätä, taulukko täynnä";
    }


    /// <summary>
    /// Poistaa kokonaisluvun hajautustaulukosta. Palauttaa
    /// merkkijonon joka kertoo, onnistuiko poisto. Jos alkioita
    /// on useampi samaa, poistaa vain ensimmäisen (hajautusarvon 
    /// perusteella ensimmäisen).
    /// </summary>
    /// <param name="t">Hajautustaulukko</param>
    /// <param name="poistettava">Poistettava luku</param>
    /// <returns>Merkkijono, joka kertoo onnistuiko</returns>
    /// <example>
    /// <pre name="test">
    ///  int[] t3 = new int[10];
    ///  Lisaa(t3, 5) === "Alkio 5 lisätty";
    ///  Lisaa(t3, 26) === "Alkio 26 lisätty";
    ///  Lisaa(t3, 36) === "Alkio 36 lisätty";
    ///  Lisaa(t3, 44) === "Alkio 44 lisätty";
    ///  Lisaa(t3, 88) === "Alkio 88 lisätty";
    ///  Lisaa(t3, 10) === "Alkio 10 lisätty";
    ///  Lisaa(t3, 10) === "Alkio 10 lisätty";
    ///  String.Join(" ", t3) === "10 10 0 0 44 5 26 36 88 0";
    ///  Poista(t3, 5) === "Alkio 5 poistettu";
    ///  Poista(t3, 5) === "Alkiota 5 ei löydy";
    ///  Poista(t3, 44) === "Alkio 44 poistettu";
    ///  Poista(t3, 88) === "Alkio 88 poistettu";
    ///  Poista(t3, 10) === "Alkio 10 poistettu";
    ///  String.Join(" ", t3) === "-1 10 0 0 -1 -1 26 36 -1 0";
    /// </pre>
    /// </example>
    public static String Poista(int[] t, int poistettava)
    {
        int aloitus = Hajauta(t, poistettava);
        int i = aloitus;
        while (i < t.Length)
        {
            if (t[i] == poistettava)
            {
                t[i] = POISTETTU;
                return "Alkio " + poistettava + " poistettu";
            }
            if (t[i] == VAPAA) return "Alkiota " + poistettava + " ei löydy";
            i++;
        }
        i = 0;
        while (i < aloitus)
        {
            if (t[i] == poistettava)
            {
                t[i] = POISTETTU;
                return "Alkio " + poistettava + " poistettu";
            }
            if (t[i] == VAPAA) return "Alkiota " + poistettava + " ei löydy";
            i++;
        }
        return "Alkiota " + poistettava + " ei löydy";
    }

}
