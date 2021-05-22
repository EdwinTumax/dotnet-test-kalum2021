using System;
using System.ComponentModel;
using System.Windows.Input;
using Kalum2021.Views;

namespace Kalum2021.ModelView
{
    public class MainViewModel : INotifyPropertyChanged, ICommand
    {

        public string Fondo {get;set;} = $"{Environment.CurrentDirectory}\\Images\\fondo2.gif";

        public MainViewModel Instancia {get;set;}
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public MainViewModel()
        {
            this.Instancia = this;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parametro)
        {
            if(parametro.Equals("Usuarios"))
            {
                UsuariosView ventanaUsuarios = new UsuariosView();
                ventanaUsuarios.ShowDialog();
            }
            else if(parametro.Equals("Roles"))
            {
                RoleView ventanaRoles = new RoleView();
                ventanaRoles.ShowDialog();
            }
            else if(parametro.Equals("Alumnos"))
            {
                AlumnosView ventanaAlumnos = new AlumnosView();
                ventanaAlumnos.ShowDialog();
            }
        }
    }
}