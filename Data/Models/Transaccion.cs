using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;
public class Transaccion
{
    [Key]
    public int transaccionId { get; set; }

    public double monto { get; set; }

    [ForeignKey("categoria")]
    public int? categoriaId { get; set; }

    public Categoria? categoria { get; set; }

    [ForeignKey("usuario")]
    public int? usuarioId { get; set; }

    public Usuario? usuario { get; set; }

    public DateTime fecha { get; set; }

    public string? notas { get; set; }

    public string tipo { get; set; } // "Gasto" o "Ingreso"

}
