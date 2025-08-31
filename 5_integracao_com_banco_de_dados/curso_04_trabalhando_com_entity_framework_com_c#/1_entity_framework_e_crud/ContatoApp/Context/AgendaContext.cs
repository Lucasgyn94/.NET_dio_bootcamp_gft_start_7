using Microsoft.EntityFrameworkCore;

namespace ContatoApp;

public class AgendaContext : DbContext
{

    public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) { }
    
    public DbSet<Contato> Contatos{ get; set; }

}
