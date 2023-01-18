using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFconASPyMVC.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(15), MinLength(4)]
        public string NombreUsuario { get; set; }

        public int AlumnoId { get; set; }

        public Alumno Alumno { get; set; }
    }
}
