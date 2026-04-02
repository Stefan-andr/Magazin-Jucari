using System;
using System.Globalization;

// Enum 1: Categoria jucariei
public enum CategorieJucarie
{
    Vehicule = 1,
    Papusi = 2,
    Constructie = 3,
    Educational = 4,
    Sport = 5,
    Electronic = 6
}

// Enum 2: Optiuni extra (Flag - pot fi combinate)
[Flags]
public enum OptiuniJucarie
{
    Niciuna = 0,
    RecomantatCopii = 1,
    Promotie = 2,
    NoutateSeason = 4,
    Bestseller = 8
}

public class Jucarie
{
    private const char SEPARATOR = ';';

    public string Nume { get; set; }
    public double Pret { get; set; }
    public string Categorie { get; set; }
    public int Stoc { get; set; }
    public CategorieJucarie TipCategorie { get; set; }
    public OptiuniJucarie Optiuni { get; set; }

    public Jucarie(string nume, double pret, string categorie, int stoc,
                   CategorieJucarie tipCategorie, OptiuniJucarie optiuni)
    {
        Nume = nume;
        Pret = pret;
        Categorie = categorie;
        Stoc = stoc;
        TipCategorie = tipCategorie;
        Optiuni = optiuni;
    }

    public Jucarie(string linieFisier)
    {
        string[] date = linieFisier.Split(SEPARATOR);
        Nume = date[0];
        Pret = double.Parse(date[1], CultureInfo.InvariantCulture);
        Categorie = date[2];
        Stoc = int.Parse(date[3]);
        TipCategorie = (CategorieJucarie)int.Parse(date[4]);
        Optiuni = (OptiuniJucarie)int.Parse(date[5]);
    }

    public string ConversieLaSir()
    {
        return $"{Nume}{SEPARATOR}" +
               $"{Pret.ToString(CultureInfo.InvariantCulture)}{SEPARATOR}" +
               $"{Categorie}{SEPARATOR}" +
               $"{Stoc}{SEPARATOR}" +
               $"{(int)TipCategorie}{SEPARATOR}" +
               $"{(int)Optiuni}";
    }

    public void Afiseaza()
    {
        Console.WriteLine($"Nume: {Nume}, Pret: {Pret:F2} lei, " +
                          $"Categorie: {Categorie}, Stoc: {Stoc}");
        Console.WriteLine($"  Tip: {TipCategorie}, Optiuni: {Optiuni}");
    }
}