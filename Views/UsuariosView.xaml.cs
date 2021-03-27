using System.Windows;
using Kalum2021.ModelView;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2021.Views
{
    public partial class UsuariosView : MetroWindow
    {
        public UsuariosView()
        {        
           InitializeComponent();           
           UsuariosViewModel ModeloDatos = new UsuariosViewModel(DialogCoordinator.Instance);
           this.DataContext = ModeloDatos;
        }
    }
}