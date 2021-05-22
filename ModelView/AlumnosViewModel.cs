using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Kalum2021.DataContext;
using Kalum2021.Models;
using System.Linq;
using Kalum2021.Views;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2021.ModelView
{
    public class AlumnosViewModel : INotifyPropertyChanged, ICommand
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public AlumnosViewModel Instancia {get;set;}

        public Alumno Seleccionado {get;set;}

        private IDialogCoordinator DialogCoordinator {get;set;}

        private ObservableCollection<Alumno> _Alumnos;
        public ObservableCollection<Alumno> Alumnos 
        {
            get
            {
                if(this._Alumnos == null)
                {   
                    this._Alumnos = new ObservableCollection<Alumno>(dBContext.Alumnos.ToList());
                }
                return this._Alumnos;
            }
            set
            {
                this._Alumnos = value;
            }
        }

        public KalumDBContext dBContext = new KalumDBContext();

        public AlumnosViewModel(IDialogCoordinator DialogCoordinator)
        {
            this.Instancia = this;
            this.DialogCoordinator = DialogCoordinator;
        }
        public bool CanExecute(object parametro)
        {
            return true;
        }

        public async void Execute(object parametro)
        {
            if(parametro.Equals("Nuevo"))
            {
                this.Seleccionado = null;
                AlumnoView VentanaAlumno = new AlumnoView(this.Instancia);
                VentanaAlumno.ShowDialog();
            }
            else if(parametro.Equals("Modificar"))
            {
                if(this.Seleccionado == null)
                {
                    await this.DialogCoordinator.ShowMessageAsync(this,"Alumnos","Debe seleccionar un elemento",MessageDialogStyle.Affirmative);
                }
                else
                {
                    AlumnoView VentanaAlumno = new AlumnoView(this.Instancia);
                    VentanaAlumno.ShowDialog();
                }
            }
            else if(parametro.Equals("Eliminar"))
            {
                if(this.Seleccionado == null)
                {
                    await this.DialogCoordinator.ShowMessageAsync(this,"Alumnos","Debe seleccionar un elemento",MessageDialogStyle.Affirmative);
                }
                else
                {
                    MessageDialogResult resultado = await this.DialogCoordinator.
                        ShowMessageAsync(this,"Eliminar alumno","Esta seguro de eliminar el registro?",
                        MessageDialogStyle.AffirmativeAndNegative);
                    if(resultado == MessageDialogResult.Affirmative)
                    {
                        try
                        {
                            int posicion = this.Alumnos.IndexOf(this.Seleccionado);
                            this.dBContext.Remove(this.Seleccionado);
                            this.dBContext.SaveChanges();
                            this.Alumnos.RemoveAt(posicion);
                            await this.DialogCoordinator.ShowMessageAsync(this,"Alumnos","Registro eliminado");
                        }
                        catch(Exception e)
                        {   
                            await this.DialogCoordinator.ShowMessageAsync(this,"Error",e.Message);
                        }
                    }
                }
            }
        }
    }
}