using System.Collections.Generic;

namespace Kalum2021.Models
{
    public class Salon
    {
        public string SalonId {get;set;}
        public int Capacidad {get;set;}
        public string Descripcion {get;set;}
        public string NombreSalon {get;set;}
        public virtual List<Clase> Clases {get;set;}

        public override string ToString()
        {
            return this.NombreSalon;
        }
    }
}