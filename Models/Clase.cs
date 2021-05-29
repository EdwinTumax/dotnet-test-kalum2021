namespace Kalum2021.Models
{
    public class Clase
    {
        public string ClaseId {get;set;}
        public string Descripcion {get;set;}
        public int Ciclo {get;set;}
        public int CupoMaximo {get;set;}
        public int CupoMinimo {get;set;}
        public string CarreraId {get;set;}
        public string SalonId {get;set;}
        public string InstructorId {get;set;}
        public string HorarioId {get;set;}
        public virtual CarreraTecnica CarreraTecnica {get;set;}
        public virtual Salon Salon {get;set;}
        public virtual Instructor Instructor {get;set;}
        public virtual Horario Horario {get;set;}

    }
}