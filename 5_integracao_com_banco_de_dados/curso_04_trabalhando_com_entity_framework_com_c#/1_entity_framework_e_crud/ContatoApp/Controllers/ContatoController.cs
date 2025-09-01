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
    public IActionResult Criar(Contato contato)
    {
        this._context.Add(contato);
        this._context.SaveChanges();
        return Ok(contato);
    }

    [HttpGet]
    public IActionResult ObterTodos()
    {
        var contato = this._context.Contatos.ToList();

        if (contato == null)
        {
            return NotFound();
        }

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

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, Contato contato)
    {
        var contatoBanco = this._context.Contatos.Find(id);

        if (contatoBanco == null)
        {
            return NotFound();
        }

        contatoBanco.Nome = contato.Nome;
        contatoBanco.Telefone = contato.Telefone;
        contatoBanco.Ativo = contato.Ativo;

        this._context.Update(contatoBanco);

        this._context.SaveChanges();

        return Ok(contatoBanco);
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var contatoBanco = this._context.Contatos.Find(id);

        if (contatoBanco == null)
        {
            return NotFound();
        }

        this._context.Contatos.Remove(contatoBanco);
        this._context.SaveChanges();

        return NoContent();
        
    }
}
