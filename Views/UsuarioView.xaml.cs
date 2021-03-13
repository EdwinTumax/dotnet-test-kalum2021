using System.Windows;
using Kalum2021.ModelView;

namespace Kalum2021.Views
{
    public partial class UsuarioView : Window
    {
        public UsuarioView(UsuariosViewModel UsuarioViewModel)
        {
            InitializeComponent(); 
            UsuarioViewModel Modelo = new UsuarioViewModel(UsuarioViewModel);
            this.DataContext = Modelo;
        }
        
    }
}