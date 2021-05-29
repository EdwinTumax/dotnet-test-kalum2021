using Kalum2021.ModelView;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2021.Views
{
    public partial class ClaseView : MetroWindow
    {
        public ClaseView(ClasesViewModel ClasesViewModel)
        {
            InitializeComponent();  
            ClaseViewModel Modelo = new ClaseViewModel(ClasesViewModel, DialogCoordinator.Instance);
            this.DataContext = Modelo;
        }
    }
}