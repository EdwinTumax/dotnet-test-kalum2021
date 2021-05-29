using System.Collections.Generic;

namespace Kalum2021.Models
{
    public class Instructor
    {
        public string InstructorId {get;set;}
        public string Apellidos {get;set;}
        public string Nombres {get;set;}
        public string Comentario {get;set;}
        public string Direccion {get;set;}
        public string Estatus {get;set;}
        public string Foto {get;set;}
        public string Telefono {get;set;}
        public virtual List<Clase> Clases {get;set;}

        public override string ToString()
        {
            return $"{this.Apellidos} {this.Nombres}";
        }
    }
}