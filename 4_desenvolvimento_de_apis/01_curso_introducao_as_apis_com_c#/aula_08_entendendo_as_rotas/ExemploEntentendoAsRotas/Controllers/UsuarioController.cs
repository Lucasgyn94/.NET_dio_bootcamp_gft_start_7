using Microsoft.AspNetCore.Mvc;

namespace ExemploEntentendoAsRotas;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{

    [HttpGet("ObterDataHoraAtual")]
    public IActionResult ObterDataHora()
    {
        var obj = new
        {
            Data = DateTime.Now.ToLongDateString(),
            Hora = DateTime.Now.ToShortTimeString()
        };

        return Ok(obj);
    }

}
