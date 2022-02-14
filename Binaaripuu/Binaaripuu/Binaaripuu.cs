using System;
using System.Text;

/// @author Kaisa Koski
/// @version 9.2.2021
/// 
/// Algoritmit 1
/// Ohjelmointitehtävä O3
/// Määritellään binääripuun solmut esimerkiksi seuraavasti:
///
///  public class Solmu {
///    public int key;
///    public Solmu left;
///    public Solmu right;
///  }
/// Kirjoita ohjelma, jolla voidaan käydä läpi tällaisen binääripuun solmut esijärjestyksessä,
/// sisäjärjestyksessä ja jälkijärjestyksessä. Muodosta binääripuu (vähintään 10 solmua) ja 
/// tulosta puun avainkenttien arvot jokaisessa em. järjestyksessä. Puun voi muodostaa "käsin" 
/// sijoittamalla solmujen kenttiin yksitellen sopivat arvot. Binääripuiden lisäys-, haku- 
/// tai poisto-operaatioita ei siis tarvitse toteuttaa.
/// 
/// <summary>
/// Kokonaislukuja sisältävän binääripuun muodostaminen ja sen lukujen
/// tulostaminen eri järjestyksissä.
/// </summary>
public class Solmu
{
    public int key;
    public Solmu left;
    public Solmu right;


    /// <summary>
    /// Solmun muodostaminen, uudella solmulla ei vielä syntyessään lapsisolmuja.
    /// </summary>
    /// <param name="key">Solmun arvo</param>
    public Solmu(int key)
    {
        this.key = key;
        this.left = null;
        this.left = null;
    }


    /// <summary>
    /// Lisätään solmulle vasen lapsisolmu
    /// </summary>
    /// <param name="lapsisolmu">Lapsisolmu</param>
    public void LisaaVasenLapsi(Solmu lapsisolmu)
    {
        this.left = lapsisolmu;
    }


    /// <summary>
    /// Lisätään solmulle oikea lapsisolmu
    /// </summary>
    /// <param name="lapsisolmu">Lapsisolmu</param>
    public void LisaaOikeaLapsi(Solmu lapsisolmu)
    {
        this.right = lapsisolmu;
    }


    /// <summary>
    /// Luo StringBuilderin, jossa on pyydetystä solmun lapsisolmustoon kuuluvien 
    /// solmujen järjestys esijärjestyksessä
    /// </summary>
    /// <param name="sb">StringBuilder, johon arvot kootaan oikeaan järjestykseen</param>
    /// <returns>StringBuilder arvoista</returns>
    public StringBuilder Esijarjestys(StringBuilder sb)
    {
        sb.Append(this.key + " ");
        if (this.left != null) this.left.Esijarjestys(sb);
        if (this.right != null) this.right.Esijarjestys(sb);
        return sb;
    }


    /// <summary>
    /// Luo StringBuilderin, jossa on pyydetystä solmun lapsisolmustoon kuuluvien 
    /// solmujen järjestys sisäjärjestyksessä
    /// </summary>
    /// <param name="sb">StringBuilder, johon arvot kootaan oikeaan järjestykseen</param>
    /// <returns>StringBuilder arvoista</returns>
    public StringBuilder Sisajarjestys(StringBuilder sb)
    {
        if (this.left != null) this.left.Sisajarjestys(sb);
        sb.Append(this.key + " ");
        if (this.right != null) this.right.Sisajarjestys(sb);
        return sb;
    }


    /// <summary>
    /// Luo StringBuilderin, jossa on pyydetystä solmun lapsisolmustoon kuuluvien 
    /// solmujen järjestys jälkijärjestyksessä
    /// </summary>
    /// <param name="sb">StringBuilder, johon arvot kootaan oikeaan järjestykseen</param>
    /// <returns>StringBuilder arvoista</returns>
    public StringBuilder Jalkijarjestys(StringBuilder sb)
    {
        if (this.left != null) this.left.Jalkijarjestys(sb);
        if (this.right != null) this.right.Jalkijarjestys(sb);
        sb.Append(this.key + " ");
        return sb;
    }


    /// <summary>
    /// Tulostaa parametrina annetun StringBuilderin.
    /// </summary>
    /// <param name="sb">StringBuilder</param>
    public static void TulostaJarjestys(StringBuilder sb)
    {
        Console.WriteLine(sb.ToString().Trim() + "\n");
    }


    /// <summary>
    ///  Binääripuun tulostusten testaaminen.
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("Luodaan samanlainen binääripuu kuin Demo3:n Kuva 1:ssä. \n");
        Solmu juurisolmu = new Solmu(25);
        Solmu s2 = new Solmu(15);
        Solmu s3 = new Solmu(12);
        Solmu s4 = new Solmu(13);
        Solmu s5 = new Solmu(20);
        Solmu s6 = new Solmu(18);
        Solmu s7 = new Solmu(21);
        Solmu s8 = new Solmu(27);
        Solmu s9 = new Solmu(30);
        Solmu s10 = new Solmu(28);
        juurisolmu.LisaaVasenLapsi(s2);
        s2.LisaaVasenLapsi(s3);
        s3.LisaaOikeaLapsi(s4);
        s2.LisaaOikeaLapsi(s5);
        s5.LisaaVasenLapsi(s6);
        s5.LisaaOikeaLapsi(s7);
        juurisolmu.LisaaOikeaLapsi(s8);
        s8.LisaaOikeaLapsi(s9);
        s9.LisaaVasenLapsi(s10);

        StringBuilder esi = new StringBuilder();
        StringBuilder sisa = new StringBuilder();
        StringBuilder jalki = new StringBuilder();

        Console.WriteLine("Binääripuun arvot esijärjestyksessä:");
        TulostaJarjestys(juurisolmu.Esijarjestys(esi));

        Console.WriteLine("Binääripuun arvot sisäjärjestyksessä:");
        TulostaJarjestys(juurisolmu.Sisajarjestys(sisa));

        Console.WriteLine("Binääripuun arvot jälkijärjestyksessä:");
        TulostaJarjestys(juurisolmu.Jalkijarjestys(jalki));

    }

}
