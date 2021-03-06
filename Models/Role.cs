namespace Kalum2021.Models
{
    public class Role
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public Role()
        {
            
        }
        public Role(int Id, string Nombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
        }
    }
}