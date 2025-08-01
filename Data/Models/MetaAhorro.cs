using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class MetaAhorro
{
    [Key]
    public int metaAhorroId { get; set; }

    public string nombreMeta { get; set; }

    public double montoObjetivo { get; set; }

    public DateTime fechaFinalizacion { get; set; }

    public double? contribucionRecurrente { get; set; }

    public string? imagen { get; set; }

    public double? montoActual { get; set; }

    public double? montoAhorrado { get; set; }
    public DateTime? fechaMontoAhorrado { get; set; }

    [ForeignKey("usuario")]
    public int? usuarioId { get; set; }

    public Usuario? usuario { get; set; }

}
