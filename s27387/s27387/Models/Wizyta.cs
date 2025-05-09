namespace s27387.Models;

public class Wizyta
{

public int Id { get; set; }
public DateTime Data { get; set; }
public string Opis { get; set; }
public decimal Cena { get; set; }

public int ZwierzeId { get; set; }

}