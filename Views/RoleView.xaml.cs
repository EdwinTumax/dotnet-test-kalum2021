using System.Windows;
using Kalum2021.ModelView;
using MahApps.Metro.Controls;

namespace Kalum2021.Views
{
    public partial class RoleView : MetroWindow
    {
        public RoleView()
        {
            InitializeComponent();
            RoleViewModel ModeloDatos = new RoleViewModel();  
            this.DataContext = ModeloDatos;
        }
        
    }
}