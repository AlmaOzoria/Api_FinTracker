using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Usuario
{
    public int UsuarioId { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Contraseña { get; set; }
    public string FotoPerfil { get; set; }
    public string Divisa { get; set; }
}
