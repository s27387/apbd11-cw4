using Microsoft.AspNetCore.Mvc;
using s27387.Models;

[ApiController]
[Route("{controller}")]
public class ZwierzeController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(BazaDanych.Zwierzeta);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var zwierze = BazaDanych.Zwierzeta.FirstOrDefault(a => a.Id == id);
        return zwierze == null ? NotFound() : Ok(zwierze);
    }

    [HttpGet("search")]
    public IActionResult SearchByName([FromQuery] string name)
    {
        var results = BazaDanych.Zwierzeta
            .Where(a => a.Imie.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
        return Ok(results);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Zwierze zwierze)
    {
        zwierze.Id = BazaDanych.Zwierzeta.Count + 1;
        BazaDanych.Zwierzeta.Add(zwierze);
        return CreatedAtAction(nameof(GetById), new { id = zwierze.Id }, zwierze);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Zwierze updated)
    {
        var zwierze = BazaDanych.Zwierzeta.FirstOrDefault(a => a.Id == id);
        if (zwierze == null) return NotFound();

        if (updated.Imie != null)
            zwierze.Imie = updated.Imie;

        if (updated.Kategoria != null)
            zwierze.Kategoria = updated.Kategoria;

        if (updated.Masa != null)
            zwierze.Masa = updated.Masa;

        if (updated.KolorSiersci != null)
            zwierze.KolorSiersci = updated.KolorSiersci;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var zwierze = BazaDanych.Zwierzeta.FirstOrDefault(a => a.Id == id);
        if (zwierze == null) return NotFound();

        BazaDanych.Zwierzeta.Remove(zwierze);
        return NoContent();
    }

    [HttpGet("{id}/wizyty")]
    public IActionResult GetVisits(int id)
    {
        var wizyty = BazaDanych.Wizyty.Where(v => v.ZwierzeId == id).ToList();
        return Ok(wizyty);
    }
}