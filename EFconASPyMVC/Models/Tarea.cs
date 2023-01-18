using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFconASPyMVC.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Tema { get; set; }

        //propiedad navegacional
        public List<AlumnoTareas> AlumnoTareas { get; set; }

    }
}
