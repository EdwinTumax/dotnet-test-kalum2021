using System.Windows;
using Kalum2021.ModelView;

namespace Kalum2021.Views
{
    public partial class RoleView : Window
    {
        public RoleView()
        {
            InitializeComponent();
            RoleViewModel ModeloDatos = new RoleViewModel();  
            this.DataContext = ModeloDatos;
        }
        
    }
}