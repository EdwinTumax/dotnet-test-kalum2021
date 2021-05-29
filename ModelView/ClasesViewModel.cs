using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Kalum2021.DataContext;
using Kalum2021.Models;
using MahApps.Metro.Controls.Dialogs;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Kalum2021.Views;

namespace Kalum2021.ModelView
{
    public class ClasesViewModel : INotifyPropertyChanged, ICommand
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public ClasesViewModel Instancia {get;set;}

        public Clase Seleccionado {get;set;}

        private IDialogCoordinator DialogCoordinator {get;set;}

        public KalumDBContext dBContext = new KalumDBContext();

        private ObservableCollection<Clase> _Clases;

        public ObservableCollection<Clase> Clases
        {
            get
            {
                if(this._Clases == null)
                {
                    this._Clases = new ObservableCollection<Clase>(dBContext.Clases.Include(c => c.Instructor).Include(c => c.CarreraTecnica).Include(c => c.Salon).Include(c => c.Horario).ToList());
                }
                return this._Clases;
            }
            set
            {
                this._Clases = value;
            }
        }

        public ClasesViewModel(IDialogCoordinator DialogCoordinator)
        {
            this.Instancia = this;
            this.DialogCoordinator = DialogCoordinator;
        }

        public bool CanExecute(object parametro)
        {
            return true;
        }

        public void Execute(object parametro)
        {
            if(parametro.Equals("Nuevo"))
            {
                ClaseView ventanaClase = new ClaseView(this.Instancia); 
                ventanaClase.ShowDialog();
            }
        }
    }
}