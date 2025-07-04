using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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

    public decimal? montoActual { get; set; }

}
