using System;

public class Jucarie
{
    public string Nume { get; set; }
    public double Pret { get; set; }
    public string Categorie { get; set; }
    public int Stoc { get; set; }

    public Jucarie(string nume, double pret, string categorie, int stoc)
    {
     
    }

    public void Afiseaza()
    {
        Console.WriteLine("Nume: " + Nume);
        Console.WriteLine("Pret: " + Pret + " lei");
        Console.WriteLine("Categorie: " + Categorie);
        Console.WriteLine("Stoc: " + Stoc);
    }
}

