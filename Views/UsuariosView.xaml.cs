using System.Windows;
using Kalum2021.ModelView;

namespace Kalum2021.Views
{
    public partial class UsuariosView : Window
    {
        public UsuariosView()
        {        
           InitializeComponent();           
           UsuarioViewModel ModeloDatos = new UsuarioViewModel();
           this.DataContext = ModeloDatos;
        }
    }
}