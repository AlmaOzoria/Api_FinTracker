using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class PagoRecurrente
{
    [Key]
    public int pagoRecurrenteId { get; set; }

    public double monto { get; set; }

    [ForeignKey("categoria")]
    public int categoriaId { get; set; }

    public Categoria? categoria { get; set; }

    [ForeignKey("usuario")]
    public int? usuarioId { get; set; }

    public Usuario? usuario { get; set; }

    public string frecuencia { get; set; }

    public DateTime fechaInicio { get; set; }

    public DateTime? fechaFin { get; set; }

    public bool activo { get; set; } = true;

}
