using System;
using System.Collections.Generic;

namespace Kalum2021.Models
{
    public class Horario
    {
        public string HorarioId {get;set;}
        public TimeSpan HorarioInicio {get;set;}
        public TimeSpan HorarioFinal {get;set;}
        public virtual List<Clase> Clases {get;set;}
        
        public override string ToString()
        {
            return $"{this.HorarioInicio.ToString(@"hh\:mm")} - {this.HorarioFinal:hh\\:mm}";
        }
    }
}