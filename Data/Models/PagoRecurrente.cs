using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class PagoRecurrente
{
    public int PagoRecurrenteId { get; set; }
    public decimal Monto { get; set; }
    public string Categoria { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string Frecuencia { get; set; } // Diaria, Semanal, Mensual, Anual
    public bool Activo { get; set; } 
    
}
