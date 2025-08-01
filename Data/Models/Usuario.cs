using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Usuario
{
  
    [Key]
    public int usuarioId { get; set; }

    public string nombre { get; set; }

    public string apellido { get; set; }

    public string email { get; set; }

    public string contraseña { get; set; }

    public string? fotoPerfil { get; set; }

    public string divisa { get; set; }


    public double saldoTotal { get; set; }

    public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
    public ICollection<LimiteGasto> LimiteGasto { get; set; } = new List<LimiteGasto>();
    public ICollection<MetaAhorro> MetaAhorro { get; set; } = new List<MetaAhorro>();
    public ICollection<Transaccion> Transaccion { get; set; } = new List<Transaccion>();
    public ICollection<PagoRecurrente> PagoRecurrente { get; set; } = new List<PagoRecurrente>();
}
