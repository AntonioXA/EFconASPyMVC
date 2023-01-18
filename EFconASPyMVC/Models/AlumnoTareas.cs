using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFconASPyMVC.Models
{
    //Esta clase va a representar la relacion N:N
    public class AlumnoTareas
    {   
        public int AlumnoId { get; set; }
        public int TareaId { get; set; }

        public bool Activo { get; set; }

        //Propiedad navegacional
        public Alumno Alumno { get; set; }

        //Propiedad navegacional
        public Tarea Tarea { get; set; }

    }
}
