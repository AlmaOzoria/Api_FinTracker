using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string Nombre { get; set; }
    public string Tipo { get; set; } 
    public string? Icono { get; set; } 
    public string? ColorFondo { get; set; } 
}
