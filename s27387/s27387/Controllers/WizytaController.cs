using Microsoft.AspNetCore.Mvc;
using s27387.Models;

namespace s27387.Controllers;


[ApiController]
[Route("{controller}")]
public class WizytaController : ControllerBase
{
    [HttpPost]
    public IActionResult DodajWizyte([FromBody] Wizyta wizyta)
    {
        var zwierze = BazaDanych.Zwierzeta.FirstOrDefault(a => a.Id == wizyta.ZwierzeId);
        if (zwierze == null)
            return NotFound("Zwierzę nie istnieje.");

        wizyta.Id = BazaDanych.Wizyty.Count + 1;
        BazaDanych.Wizyty.Add(wizyta);
        zwierze.Wizyty.Add(wizyta);

        return Ok(wizyta);
    }
}