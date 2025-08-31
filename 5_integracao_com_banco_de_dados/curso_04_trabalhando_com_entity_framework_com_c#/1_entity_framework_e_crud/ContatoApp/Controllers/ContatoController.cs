using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ContatoApp;

[ApiController]
[Route("[controller]")]
public class ContatoController : ControllerBase
{
    private readonly AgendaContext _context;

    public ContatoController(AgendaContext context)
    {
        this._context = context;
    }

    [HttpPost]
    public IActionResult Create(Contato contato)
    {
        this._context.Add(contato);
        this._context.SaveChanges();
        return Ok(contato);
    }

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        var contato = this._context.Contatos.Find(id);

        if (contato == null)
        {
            return NotFound();
        }

        return Ok(contato);
    }

}
