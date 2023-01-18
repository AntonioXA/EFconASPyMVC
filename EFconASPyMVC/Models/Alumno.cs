using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFconASPyMVC.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30), MinLength(3)]
        public string Nombre { get; set; }
        public int Edad { get; set; }

        //Clave foránea con respecto a Clase
        public int ClaseId { get; set; }

        //propiedad navegacional
        public Usuario Usuario { get; set; }

        //propiedad navegacional
        public List<AlumnoTareas> AlumnoTareas { get; set; }

        //propiedad navegacional 
        public Clase Clase { get; set; }
    }
}
