using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class LimiteGasto
{
 public int LimiteGastoId { get; set; }
    public string Categoria { get; set; } 
    public double MontoLimite { get; set; }
    public string Periodo { get; set; } 
    public double GastoActual { get; set; }
}
