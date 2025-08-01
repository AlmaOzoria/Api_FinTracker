using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Api_FinTracker.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Transaccion> Transaccion { get; set; }
    public DbSet<PagoRecurrente> PagoRecurrente { get; set; }
    public DbSet<MetaAhorro> MetaAhorro { get; set; }
    public DbSet<LimiteGasto> LimiteGasto { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<CambiarContrasenaRequest> CambiarContrasenaRequest { get; set; }

}
