using EFconASPyMVC.Models;
using System.Linq;

namespace EFconASPyMVC.Context
{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated(); 

            
            if (context.Clases.Any())
            {
                return;   
            }

            var clases = new Clase[]
            {
            new Clase{Nombre="1 DAM"},
            new Clase{Nombre="2 DAM"},
            new Clase{Nombre="1 DAW"},
            new Clase{Nombre="2 DAW"},

            };
            foreach (Clase c in clases)
            {
                context.Clases.Add(c);
            }
            context.SaveChanges();


            //Añado alumnos
            var alum = new Alumno[]
            {
            new Alumno{Nombre="Paco",Edad=19,ClaseId=1},
            new Alumno{Nombre="Maria",Edad=18,ClaseId=1},
            new Alumno{Nombre="Arturo",Edad=21,ClaseId=4},
            new Alumno{Nombre="Jose",Edad=19,ClaseId=3},
            new Alumno{Nombre="Natalia",Edad=24,ClaseId=2},
            new Alumno{Nombre="Marcos",Edad=22,ClaseId=2},
            new Alumno{Nombre="Laura",Edad=18,ClaseId=3},
            new Alumno{Nombre="Sergio",Edad=20,ClaseId=4}
            };


            foreach (Alumno a in alum)
            {
                context.Alumnos.Add(a);
            }
            context.SaveChanges();

            //Añado usuarios
            var usu = new Usuario[]
            {
            new Usuario{NombreUsuario="Paco123",AlumnoId=1},
            new Usuario{NombreUsuario="Maria123",AlumnoId=2},
            new Usuario{NombreUsuario="Arturo123",AlumnoId=3},
            new Usuario{NombreUsuario="Jose123",AlumnoId=4},
            new Usuario{NombreUsuario="Natalia123",AlumnoId=5},
            new Usuario{NombreUsuario="Marcos123",AlumnoId=6},
            new Usuario{NombreUsuario="Laura123",AlumnoId=7},
            new Usuario{NombreUsuario="Sergio123",AlumnoId=8},
            };


            foreach (Usuario u in usu)
            {
                context.Usuarios.Add(u);
            }
            context.SaveChanges();


            //Añado tareas
            var tar = new Tarea[]
            {
            new Tarea{Tema="1"},
            new Tarea{Tema="2"},
            new Tarea{Tema="3"},
            new Tarea{Tema="4"},
            new Tarea{Tema="5"},
            new Tarea{Tema="6"},
            new Tarea{Tema="7"}
            };
            foreach (Tarea t in tar)
            {
                context.Tareas.Add(t);
            }
            context.SaveChanges();


            //Añado AlumnoTareas
            var at = new AlumnoTareas[]
            {
            new AlumnoTareas{AlumnoId=1, TareaId=1, Activo=true},
            new AlumnoTareas{AlumnoId=1, TareaId=2, Activo=true},
            new AlumnoTareas{AlumnoId=2, TareaId=1, Activo=true},
            new AlumnoTareas{AlumnoId=2, TareaId=3, Activo=true},
            new AlumnoTareas{AlumnoId=3, TareaId=3, Activo=true},
            new AlumnoTareas{AlumnoId=3, TareaId=5, Activo=true},
            new AlumnoTareas{AlumnoId=1, TareaId=7, Activo=true},
            new AlumnoTareas{AlumnoId=6, TareaId=7, Activo=true},
            new AlumnoTareas{AlumnoId=6, TareaId=6, Activo=true},
            new AlumnoTareas{AlumnoId=7, TareaId=6, Activo=true},
            new AlumnoTareas{AlumnoId=7, TareaId=4, Activo=true},
            new AlumnoTareas{AlumnoId=8, TareaId=4, Activo=false},
            new AlumnoTareas{AlumnoId=5, TareaId=4, Activo=false},
            new AlumnoTareas{AlumnoId=5, TareaId=2, Activo=false},
            new AlumnoTareas{AlumnoId=4, TareaId=6, Activo=false},
            new AlumnoTareas{AlumnoId=4, TareaId=4, Activo=false},
            new AlumnoTareas{AlumnoId=5, TareaId=3, Activo=false},
            new AlumnoTareas{AlumnoId=6, TareaId=1, Activo=false},
            };
            foreach (AlumnoTareas alT in at)
            {
                context.AlumnoTareas.Add(alT);
            }
            context.SaveChanges();
        }
    }
}
