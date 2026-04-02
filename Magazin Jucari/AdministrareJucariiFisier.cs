using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AdministrareJucariiFisier : IStocareData
{
    private readonly string numeFisier;

    public AdministrareJucariiFisier(string numeFisier)
    {
        this.numeFisier = numeFisier;
        File.Open(numeFisier, FileMode.OpenOrCreate).Close();
    }

    public void AddJucarie(Jucarie j)
    {
        using (StreamWriter sw = new StreamWriter(numeFisier, append: true))
        {
            sw.WriteLine(j.ConversieLaSir());
        }
    }

    public List<Jucarie> GetJucarii()
    {
        List<Jucarie> lista = new List<Jucarie>();
        using (StreamReader sr = new StreamReader(numeFisier))
        {
            string linie;
            while ((linie = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(linie))
                    lista.Add(new Jucarie(linie));
            }
        }
        return lista;
    }

    public void SalveazaTot(List<Jucarie> lista)
    {
        using (StreamWriter sw = new StreamWriter(numeFisier, append: false))
        {
            foreach (var j in lista)
                sw.WriteLine(j.ConversieLaSir());
        }
    }

    // Tema 3: metoda cu LINQ — cauta dupa nume si returneaza lista
    public List<Jucarie> CautaDupaNume(List<Jucarie> lista, string nume)
    {
        return lista
            .Where(j => j.Nume.ToLower().Contains(nume.ToLower()))
            .ToList();
    }

    // LINQ — filtrare dupa categorie enum
    public List<Jucarie> CautaDupaCategorie(List<Jucarie> lista, CategorieJucarie tip)
    {
        return lista
            .Where(j => j.TipCategorie == tip)
            .ToList();
    }
}