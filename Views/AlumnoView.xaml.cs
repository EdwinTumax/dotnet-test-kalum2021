using Kalum2021.ModelView;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2021.Views
{
    public partial class AlumnoView : MetroWindow
    {
        private AlumnoViewModel Modelo;
        private AlumnosViewModel AlumnosViewModel {get;set;}
        public AlumnoView(AlumnosViewModel AlumnosViewModel)
        {
            InitializeComponent();
            Modelo = new AlumnoViewModel(AlumnosViewModel, DialogCoordinator.Instance);
            this.DataContext = Modelo;
            this.AlumnosViewModel = AlumnosViewModel;
        }        
    }
}