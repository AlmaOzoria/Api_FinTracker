using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;
public class Transaccion
{
    public int TransaccionId { get; set; }
    public Double Monto { get; set; }
    public string Categoria { get; set; }
    public DateTime Fecha { get; set; }
    public string? Notas { get; set; }
    public string Tipo { get; set; } // "Ingreso" o "Gasto"

}
