using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author Kaisa Koski
/// @version 28.4.2021
/// <summary>
/// 
/// </summary>
public class RantatarvikeJoukko
{
    private Tarvike[] rantatarvikkeet = new Tarvike[]{null, new Tarvike("pyyhe", 2, 4),
                                                new Tarvike("kirja", 1, 2),
                                                new Tarvike("uimapuku", 3, 5),
                                                new Tarvike("eväät", 3, 4)};

    /// <returns>Palauttaa rantatarviketaulukon koon</returns>
    public int GetKoko()
    {
        return rantatarvikkeet.Length;
    }

    override
    public String ToString()
    {
        StringBuilder sb = new StringBuilder("");
        String vali = "";
        for (int i = 1; i < rantatarvikkeet.Length; i++)
        {
            sb.Append(vali + rantatarvikkeet[i].GetTarvike());
            vali = "\n";
        }
        return sb.ToString();
    }
    /// <summary>
    /// Palauttaa kapsäkkiongelman ratkaisuun käytettävän taulukon.
    /// </summary>
    /// <param name="k">Kuinka monesta tavarasta valitaan (indeksit 1-k)</param>
    /// <param name="r">Maksimikokonaispaino</param>
    /// <returns></returns>
    public int[,] KapsakkiTaulukko(int k, int r)
    {
        if (rantatarvikkeet.Length <= k) return null;
        int[,] s = new int[k + 1, r + 1];
        int i, j;
        for (i = 0; i < k + 1; i++)
        {
            s[i, 0] = 0;
        }
        for (j = 0; j < r + 1; j++)
        {
            s[0, j] = 0;
        }
        for (i = 1; i <= k; i++)
        {
            for (j = 1; j <= r; j++)
            {
                int p = rantatarvikkeet[i].GetHyoty();
                int w = rantatarvikkeet[i].GetPaino();
                if (w > j) s[i, j] = s[i - 1, j];
                else s[i, j] = Math.Max(s[i - 1, j], p + s[i - 1, j - w]);
            }

        }
        return s;
    }


    /// <summary>
    /// Palauttaa maksimihyödyn kapsäkkiongelman taulukkoratkaisun perusteella
    /// </summary>
    /// <param name="kapsakkiTaulukko">Taulukko kapsäkkiongelman arvoista</param>
    /// <returns>Maksimiarvo</returns>
    public int MaxHyoty(int[,] kapsakkiTaulukko)
    {
        int k = kapsakkiTaulukko.GetLength(0) - 1;
        int r = kapsakkiTaulukko.GetLength(1) - 1;
        return kapsakkiTaulukko[k, r];
    }

    private class Tarvike
    {
        private String nimi;
        private int p; //hyötyarvo
        private int w; //paino

        /// <summary>
        /// Tarvikkeen alustus
        /// </summary>
        /// <param name="nimi">Rantatarvikkeen nimi</param>
        /// <param name="hyoty">Rantatarvikkeen hyötyluku</param>
        /// <param name="paino">Rantatarvikkeen paino</param>
        public Tarvike(String nimi, int paino, int hyoty)
        {
            this.nimi = nimi;
            this.p = hyoty;
            this.w = paino;
        }

        /// <returns>Tarvikkeen nimi</returns>
        public string GetNimi()
        {
            return nimi;
        }

        /// <returns>Tarvikkeen hyöty</returns>
        public int GetHyoty()
        {
            return p;
        }

        /// <returns>Tarvikkeen paino</returns>
        public int GetPaino()
        {
            return w;
        }


        public string GetTarvike()
        {
            return String.Format("{0}, paino {1}, hyöty {2}", nimi, w, p);
        }


    }
    /// <summary>
    /// Testataan kapsäkkiongelman ratkaisua taulukoimalla
    /// </summary>
    public static void Main()
    {
        RantatarvikeJoukko rantatarvikkeet = new RantatarvikeJoukko();
        Console.WriteLine("Rantaretkelle valittavissa seuraavat tavarat:");
        Console.WriteLine(rantatarvikkeet.ToString() + "\n");
        Console.Write("Tarvikkeilla saatava maksimihyöty, kun valittavana kaikki tavarat ja maksimipaino on 5: ");
        int[,] kapsakkiT = rantatarvikkeet.KapsakkiTaulukko(4, 5);
        Console.WriteLine(rantatarvikkeet.MaxHyoty(kapsakkiT));
        for (int i = 0; i < kapsakkiT.GetLength(0); i++)
        {
            for (int j = 0; j < kapsakkiT.GetLength(1); j++)
            {
                Console.Write(kapsakkiT[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.Write("Tarvikkeilla saatava maksimihyöty, kun valittavana kaikki tavarat ja maksimipaino on 4: ");
        kapsakkiT = rantatarvikkeet.KapsakkiTaulukko(4, 4);
        Console.WriteLine(rantatarvikkeet.MaxHyoty(kapsakkiT));
        for (int i = 0; i < kapsakkiT.GetLength(0); i++)
        {
            for (int j = 0; j < kapsakkiT.GetLength(1); j++)
            {
                Console.Write(kapsakkiT[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.Write("Tarvikkeilla saatava maksimihyöty, kun valittavana kolme ensimmäistä tavaraa ja maksimipaino on 3: ");
        kapsakkiT = rantatarvikkeet.KapsakkiTaulukko(3, 3);
        Console.WriteLine(rantatarvikkeet.MaxHyoty(kapsakkiT));
        for (int i = 0; i < kapsakkiT.GetLength(0); i++)
        {
            for (int j = 0; j < kapsakkiT.GetLength(1); j++)
            {
                Console.Write(kapsakkiT[i, j] + " ");
            }
            Console.WriteLine();
        }
    }


}
