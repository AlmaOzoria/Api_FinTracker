using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class LimiteGasto
{
 
    [Key]
    public int limiteGastoId { get; set; }

    [ForeignKey("categoria")]
    public int categoriaId { get; set; }

    public Categoria? categoria { get; set; }

    [ForeignKey("usuario")]
    public int? usuarioId { get; set; }

    public Usuario? usuario { get; set; }

    public double montoLimite { get; set; }

    public string periodo { get; set; } // "Diario", "Semanal", "Mensual", "Anual"

    public double? gastadoActual { get; set; }
}
