using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFconASPyMVC.Models
{
    public class Clase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //propiedad navegacional
        public List<Alumno> Alumnos { get; set; }
    }
}
