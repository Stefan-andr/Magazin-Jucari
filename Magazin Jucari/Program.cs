using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {
        IStocareData admin = new AdministrareJucariiFisier("jucarii.txt");
        List<Jucarie> magazin = admin.GetJucarii();

        bool ruleaza = true;

        while (ruleaza)
        {
            Console.WriteLine("\n--- MENIU ---");
            Console.WriteLine("1. Adauga");
            Console.WriteLine("2. Afiseaza");
            Console.WriteLine("3. Cauta dupa nume");
            Console.WriteLine("4. Modifica");
            Console.WriteLine("5. Cauta dupa categorie");
            Console.WriteLine("0. Iesire");

            int opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    var j = CitesteJucarie();
                    magazin.Add(j);
                    admin.AddJucarie(j);
                    break;

                case 2:
                    foreach (var x in magazin)
                        x.Afiseaza();
                    break;

                case 3:
                    // Tema 3: LINQ in cautare
                    CautaJucarie(magazin, (AdministrareJucariiFisier)admin);
                    break;

                case 4:
                    ModificaJucarie(magazin, admin);
                    break;

                case 5:
                    // Tema 3: LINQ filtrare dupa enum
                    CautaDupaCategorie(magazin, (AdministrareJucariiFisier)admin);
                    break;

                case 0:
                    ruleaza = false;
                    break;
            }
        }
    }

    static Jucarie CitesteJucarie()
    {
        Console.Write("Nume: ");
        string nume = Console.ReadLine();

        Console.Write("Pret: ");
        double pret = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Categorie (text): ");
        string categorie = Console.ReadLine();

        Console.Write("Stoc: ");
        int stoc = int.Parse(Console.ReadLine());

        // Tema 2: citire enum CategorieJucarie cu tratare exceptii
        CategorieJucarie tipCategorie = CitesteCategorie();

        // Tema 2: citire enum Flags OptiuniJucarie
        OptiuniJucarie optiuni = CitesteOptiuni();

        return new Jucarie(nume, pret, categorie, stoc, tipCategorie, optiuni);
    }

    // Tema 2 + Tema 3 exceptii: citire enum cu try-catch
    static CategorieJucarie CitesteCategorie()
    {
        Console.WriteLine("\nAlege tipul categoriei:");
        foreach (CategorieJucarie val in Enum.GetValues(typeof(CategorieJucarie)))
        {
            Console.WriteLine($"  {(int)val} - {val}");
        }

        while (true)
        {
            try
            {
                Console.Write("Optiune: ");
                int optiune = int.Parse(Console.ReadLine());

                if (Enum.IsDefined(typeof(CategorieJucarie), optiune))
                    return (CategorieJucarie)optiune;
                else
                    Console.WriteLine("Valoare invalida. Incearca din nou.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Eroare: Trebuie sa introduci un numar valid.");
            }
        }
    }

    // Tema 2: citire enum Flags (pot fi combinate mai multe optiuni)
    static OptiuniJucarie CitesteOptiuni()
    {
        Console.WriteLine("\nAlege optiunile (pot fi combinate, ex: 1+2=3):");
        foreach (OptiuniJucarie val in Enum.GetValues(typeof(OptiuniJucarie)))
        {
            if (val != OptiuniJucarie.Niciuna)
                Console.WriteLine($"  {(int)val} - {val}");
        }

        while (true)
        {
            try
            {
                Console.Write("Optiuni (suma valorilor): ");
                int optiune = int.Parse(Console.ReadLine());
                return (OptiuniJucarie)optiune;
            }
            catch (FormatException)
            {
                Console.WriteLine("Eroare: Trebuie sa introduci un numar valid.");
            }
        }
    }

    // Tema 3: LINQ in cautare dupa nume
    static void CautaJucarie(List<Jucarie> magazin, AdministrareJucariiFisier admin)
    {
        Console.Write("Introdu numele: ");
        string nume = Console.ReadLine();

        List<Jucarie> rezultate = admin.CautaDupaNume(magazin, nume);

        if (rezultate.Count == 0)
            Console.WriteLine("Nu s-au gasit rezultate.");
        else
            foreach (var j in rezultate)
                j.Afiseaza();
    }

    // Tema 3: LINQ filtrare dupa categorie enum
    static void CautaDupaCategorie(List<Jucarie> magazin, AdministrareJucariiFisier admin)
    {
        CategorieJucarie tip = CitesteCategorie();

        List<Jucarie> rezultate = admin.CautaDupaCategorie(magazin, tip);

        if (rezultate.Count == 0)
            Console.WriteLine("Nu s-au gasit jucarii in aceasta categorie.");
        else
            foreach (var j in rezultate)
                j.Afiseaza();
    }

    static void ModificaJucarie(List<Jucarie> magazin, IStocareData admin)
    {
        Console.Write("Numele jucariei: ");
        string nume = Console.ReadLine();

        var j = magazin.FirstOrDefault(x => x.Nume.ToLower() == nume.ToLower());

        if (j != null)
        {
            Console.Write("Pret nou: ");
            j.Pret = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Stoc nou: ");
            j.Stoc = int.Parse(Console.ReadLine());

            admin.SalveazaTot(magazin);
            Console.WriteLine("Modificat si salvat!");
        }
        else
        {
            Console.WriteLine("Nu exista!");
        }
    }
}