using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Categoria
{
    [Key]
    public int categoriaId { get; set; }

    public string nombre { get; set; }

    public string tipo { get; set; } // "Gasto" o "Ingreso"

    public string icono { get; set; }

    public string colorFondo { get; set; }
}
