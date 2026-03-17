
using System;
using System.Collections.Generic;
public class Jucarie
{
    public string Nume { get; set; }
    public double Pret { get; set; }
    public string Categorie { get; set; }
    public int Stoc { get; set; }

    public Jucarie(string nume, double pret, string categorie, int stoc)
    {
        Nume = nume;
        Pret = pret;
        Categorie = categorie;
        Stoc = stoc;
    }

    public void Afiseaza()
    {
        Console.WriteLine($"Nume: {Nume}, Pret: {Pret}, Categorie: {Categorie}, Stoc: {Stoc}");
    }
}


class Program
{
    static void Main()
    {
        List<Jucarie> magazin = new List<Jucarie>();
        bool ruleaza = true;

        while (ruleaza)
        {
            Console.WriteLine("\n--- MENIU ---");
            Console.WriteLine("1. Adauga jucarie");
            Console.WriteLine("2. Afiseaza jucarii");
            Console.WriteLine("3. Cauta jucarie dupa nume");
            Console.WriteLine("0. Iesire");

            Console.Write("Alege optiunea: ");
            int opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    AdaugaJucarie(magazin);
                    break;

                case 2:
                    AfiseazaJucarii(magazin);
                    break;

                case 3:
                    CautaJucarie(magazin);
                    break;

                case 0:
                    ruleaza = false;
                    break;

                default:
                    Console.WriteLine("Optiune invalida!");
                    break;
            }
        }
    }

    static void AdaugaJucarie(List<Jucarie> magazin)
    {
        Console.Write("Nume: ");
        string nume = Console.ReadLine();

        Console.Write("Pret: ");
        double pret = Convert.ToDouble(Console.ReadLine());

        Console.Write("Categorie: ");
        string categorie = Console.ReadLine();

        Console.Write("Stoc: ");
        int stoc = Convert.ToInt32(Console.ReadLine());

        magazin.Add(new Jucarie(nume, pret, categorie, stoc));

        Console.WriteLine("Jucarie adaugata!");
    }

    static void AfiseazaJucarii(List<Jucarie> magazin)
    {
        if (magazin.Count == 0)
        {
            Console.WriteLine("Nu exista jucarii!");
            return;
        }

        foreach (var j in magazin)
        {
            j.Afiseaza();
        }
    }

    static void CautaJucarie(List<Jucarie> magazin)
    {
        Console.Write("Introdu numele: ");
        string nume = Console.ReadLine();

        bool gasit = false;

        foreach (var j in magazin)
        {
            if (j.Nume.ToLower() == nume.ToLower())
            {
                j.Afiseaza();
                gasit = true;
            }
        }

        if (!gasit)
        {
            Console.WriteLine("Jucaria nu a fost gasita!");
        }
    }
}
