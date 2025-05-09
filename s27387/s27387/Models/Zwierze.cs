namespace s27387.Models;

public class Zwierze
{
    static int ZwierzeId = 0;
    public int Id { get; set; }
    public String Imie {get; set;}
    public String Kategoria {get; set;}
    public double Masa {get; set;}
    public String KolorSiersci {get; set;}
    public List<Wizyta> Wizyty { get; set; } = new();
    
}