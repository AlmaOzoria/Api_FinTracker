using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class MetaAhorro
{
    public int MetaAhorroId { get; set; }
    public string NombreMeta { get; set; }
    public double MontoObjetivo { get; set; }
    public double MontoActual { get; set; }
    public DateTime FechaFinalizacion { get; set; }
    public string? Imagen { get; set; }
    public string? Progreso { get; set; }
 
}
