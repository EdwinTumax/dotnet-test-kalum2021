using System.Collections.ObjectModel;
using System.ComponentModel;
using Kalum2021.Models;
namespace Kalum2021.ModelView
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Usuarios> usuarios {get;set;}
        public event PropertyChangedEventHandler PropertyChanged;

        public UsuarioViewModel()
        {
            this.usuarios = new ObservableCollection<Usuarios>();
            this.usuarios.Add(new Usuarios(1,"etumax",true,"Edwin Rolando","Tumax Chaclan", "etumax@gmail.com"));
            this.usuarios.Add(new Usuarios(2,"nperez",true,"Nancy Elizabeth","Perez Carcamo", "eperez@gmail.com"));
            this.usuarios.Add(new Usuarios(3,"caquino",true,"Cesar Agusto","Aquino Gaitan", "caquino@gmail.com"));
        }

        public void NotificarCambio(string propiedad)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

    }
}