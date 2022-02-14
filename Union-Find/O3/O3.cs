using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author Kaisa Koski
/// @version 20.4.2021
/// 
/// Algoritmit 2
/// Ohjelmointitehtävä O3
/// Perusjoukossa on n kappaletta erillisiä merkkijonoja, esimerkiksi:
///   {"banaani", "luumu", "omena", "persikka", "sitruuna"}
/// Kirjoita ohjelma, joka toteuttaa union-find-operaatiot tämän tyyppiselle perusjoukolle. 
/// Testaa operaatioiden toimivuus.
///
public class Alkio
{
    private int arvo;
    private String mj;

    public Alkio(String mj)
    {
        this.arvo = -1;
        this.mj = mj;
    }

    public void SetArvo(int uusiArvo)
    {
        arvo = uusiArvo;
    }

    public int GetArvo()
    {
        return this.arvo;
    }

    public override string ToString()
    {
        return arvo + " : " + mj;
    }

    /// <summary>
    /// Osajoukkojen union-find -operaatioiden testaaminen
    /// </summary>
    public static void Main()
    {
        Alkio[] pj = new Alkio[] { null, new Alkio("banaani"), new Alkio("luumu"),
                                   new Alkio("omena"), new Alkio("persikka"), new Alkio("sitruuna"),
                                   new Alkio("kirsikka"), new Alkio("päärynä"), new Alkio("avokado")};
        Console.WriteLine("Alkiot alussa:");
        for (int i = 1; i < pj.Length; i++)
        {
            Console.WriteLine("Indeksi " + i + " : " + pj[i].ToString());
        }
        Union(pj, 1, 5);
        Union(pj, 3, 4);
        Union(pj, 2, 8);
        Console.WriteLine("\nAlkiot kun yhdistetty (1,5), (3,4), (2,8):");
        for (int i = 1; i < pj.Length; i++)
        {
            Console.WriteLine("Indeksi " + i + " : " + pj[i].ToString());
        }
        Union(pj, 1, 2);
        Union(pj, 1, 3);
        Union(pj, 6, 7);
        Union(pj, 1, 6);
        Console.WriteLine("\nAlkiot kaikkien yhdistämisten jälkeen:");
        for (int i = 1; i < pj.Length; i++)
        {
            Console.WriteLine("Indeksi " + i + " : " + pj[i].ToString());
        }
        Find(pj, 7);
        Console.WriteLine("\nAlkiot kun tehty toiminto Find(7):");
        for (int i = 1; i < pj.Length; i++)
        {
            Console.WriteLine("Indeksi " + i + " : " + pj[i].ToString());
        }
        Find(pj, 4);
        Find(pj, 8);
        Console.WriteLine("\nAlkiot etsinnän ja hakupolun tiivistämisen jälkeen:");
        for (int i = 1; i < pj.Length; i++)
        {
            Console.WriteLine("Indeksi " + i + " : " + pj[i].ToString());
        }
    }

    /// <summary>
    /// Yhdistää kaksi osajoukkoa. Jos parametreina ei ole annettu
    /// juurisolmujen indeksejä, palaa tekemättä mitään.
    /// </summary>
    /// <param name="t">Perusjoukko taulukkomuodossa</param>
    /// <param name="i1">Ensimmäisen osajoukon juurisolmun indeksi</param>
    /// <param name="i2">Ensimmäisen osajoujon juursiolmun indeksi</param>
    public static void Union(Alkio[] t, int i1, int i2)
    {
        if (i1 <= 0 || i2 <= 0) return;
        Alkio a1 = t[i1];
        int arvo1 = a1.GetArvo();
        Alkio a2 = t[i2];
        int arvo2 = a2.GetArvo();
        if (arvo1 >= 0 || arvo2 >= 0) return;
        int k;
        k = arvo1 + arvo2;
        if (arvo1 <= arvo2)
        {
            a1.SetArvo(k);
            a2.SetArvo(i1);
        }
        else
        {
            a2.SetArvo(k);
            a1.SetArvo(i2);
        }
    }


    /// <summary>
    /// Palauttaa osajoukon juurisolmun ja tekee
    /// hakupolun tiivistyksen. Jos epäkelpo indeksi,
    /// palauttaa -999.
    /// </summary>
    /// <param name="t">Perusjoukko taulukkomuodossa</param>
    /// <param name="i">Indeksi</param>
    /// <returns>Juurisolmun indeksi</returns>
    public static int Find(Alkio[] t, int i)
    {
        if (i <= 0) return -999;
        int j, k;
        j = i;
        while (t[j].GetArvo() > 0)
        {
            j = t[j].GetArvo();
        }
        while (t[i].GetArvo() > 0)
        {
            k = i;
            i = t[i].GetArvo();
            t[k].SetArvo(j);
        }
        return j;
    }

}
