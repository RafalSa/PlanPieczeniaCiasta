using System;
using System.Collections;
using System.Collections.Generic;

// Klasa Ciasto
public class Ciasto
{
    public string Nazwa { get; set; }
    public string Rodzaj { get; set; }
    public List<string> Skladniki { get; set; }

    public Ciasto(string nazwa, string rodzaj, List<string> skladniki)
    {
        Nazwa = nazwa;
        Rodzaj = rodzaj;
        Skladniki = skladniki;
    }
}

// Interfejs IFabrykaCiasta
public interface IFabrykaCiasta
{
    Ciasto StworzCiasto();
}

// Fabryka ciasta czekoladowego
public class FabrykaCiastaCzekoladowego : IFabrykaCiasta
{
    public Ciasto StworzCiasto()
    {
        var skladniki = new List<string> { "Czekolada", "Mąka", "Jajka", "Masło" };
        return new Ciasto("Czekoladowe", "Kruche", skladniki);
    }
}

// Fabryka ciasta jabłkowego
public class FabrykaCiastaJablkowego : IFabrykaCiasta
{
    public Ciasto StworzCiasto()
    {
        var skladniki = new List<string> { "Jabłka", "Cynamon", "Mąka", "Cukier" };
        return new Ciasto("Jabłkowe", "Drożdżowe", skladniki);
    }
}

// Klasa PlanPieczenia
public class PlanPieczenia : IEnumerable<Ciasto>
{
    private List<Ciasto> ciasta = new List<Ciasto>();

    public void DodajCiasto(IFabrykaCiasta fabryka)
    {
        Ciasto ciasto = fabryka.StworzCiasto();
        ciasta.Add(ciasto);
    }

    public void WyświetlPlan()
    {
        foreach (var ciasto in ciasta)
        {
            Console.WriteLine($"Nazwa: {ciasto.Nazwa}, Rodzaj: {ciasto.Rodzaj}, Składniki: {string.Join(", ", ciasto.Skladniki)}");
        }
    }

    public IEnumerator<Ciasto> GetEnumerator()
    {
        return ciasta.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Program główny
class Program
{
    static void Main(string[] args)
    {
        var planPieczenia = new PlanPieczenia();

        var fabrykaCzekoladowego = new FabrykaCiastaCzekoladowego();
        var fabrykaJablkowego = new FabrykaCiastaJablkowego();

        planPieczenia.DodajCiasto(fabrykaCzekoladowego);
        planPieczenia.DodajCiasto(fabrykaJablkowego);

        Console.WriteLine("Plan pieczenia ciast:");
        planPieczenia.WyświetlPlan();
    }
}
