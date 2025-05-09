using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("{controller}")]
public class ZwierzeController : ControllerBase
{
    public String GetZwierze()
    {
        return "Zwierze";
    }
}