namespace s27387.Models;

public class Zwierze
{
    static int ZwierzeId = 0;
    private int Id { get; set; }
    public String Imie {get; set;}
    public String Kategoria {get; set;}
    public double Masa {get; set;}
    public String KolorSiersci {get; set;}
    public List<Wizyta> Wizyty { get; set; } = new();

    public Zwierze(String Imie, String Kategoria, double Masa, String KolorSiersci)
    {
        Id = ZwierzeId++;
        this.Imie = Imie;
        this.Kategoria = Kategoria;
        this.Masa = Masa;
        this.KolorSiersci = KolorSiersci;
    }
    
}