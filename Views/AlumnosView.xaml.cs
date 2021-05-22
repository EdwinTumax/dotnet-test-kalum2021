using Kalum2021.ModelView;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2021.Views
{
    public partial class AlumnosView : MetroWindow
    {
        public AlumnosView()
        {
            InitializeComponent();   
            AlumnosViewModel ModeloDatos = new AlumnosViewModel(DialogCoordinator.Instance);
            this.DataContext = ModeloDatos;
        }
    }
}