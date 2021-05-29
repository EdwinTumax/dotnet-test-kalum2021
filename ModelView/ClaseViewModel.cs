using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Kalum2021.DataContext;
using Kalum2021.Models;
using MahApps.Metro.Controls.Dialogs;
using System.Linq;

namespace Kalum2021.ModelView
{
    public class ClaseViewModel : INotifyPropertyChanged, ICommand
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public ObservableCollection<CarreraTecnica> CarrerasTecnicas {get;set;}
        public ObservableCollection<Instructor> Instructores {get;set;}
        public ObservableCollection<Salon> Salones {get;set;}
        public ObservableCollection<Horario> Horarios {get;set;}
        private List<int> _Ciclos;
        private List<int> _CupoMaximo;

        public List<int> CupoMaximo
        {
            get
            {
                if(this._CupoMaximo == null)
                {
                    this._CupoMaximo = new List<int>();
                    int i = 0;
                    while(i < 30)
                    {
                        i++;
                        this._CupoMaximo.Add(i);
                    }
                }
                return this._CupoMaximo;
            }
            set
            {
                this._CupoMaximo = value;
            }
        }

        private List<int> _CupoMinimo;
        public List<int> CupoMinimo
        {
            get
            {
                if(this._CupoMinimo == null)
                {
                    this._CupoMinimo = new List<int>();
                    int i = 0;
                    do
                    {
                        i++;
                        this._CupoMinimo.Add(i);
                    }while(i < 30);
                }
                return this._CupoMinimo;
            }
            set
            {
                this._CupoMinimo = value;
            }
        }

        public List<int> Ciclos 
        {
            get
            {
                if(_Ciclos == null)
                {
                    this._Ciclos = new List<int>();
                    for(int i= 2020; i<=2030; i++)
                    {
                        this._Ciclos.Add(i);
                    }
                }
                return this._Ciclos;
            }
            set
            {
                this._Ciclos = value;
            }
        }
        public ClaseViewModel Instancia {get;set;}

        public ClasesViewModel ClasesViewModel {get;set;}

        public String Titulo {get;set;}

        private IDialogCoordinator DialogoCoordinator;

        private KalumDBContext KalumDBContext = new KalumDBContext();

        public ClaseViewModel(ClasesViewModel ClasesViewModel, IDialogCoordinator DialogCoordinator)
        {
            this.Instancia = this;
            this.DialogoCoordinator = DialogCoordinator;
            this.ClasesViewModel = ClasesViewModel;
            this.CarrerasTecnicas = new ObservableCollection<CarreraTecnica>(this.KalumDBContext.CarrerasTecnicas.ToList());            
            this.Instructores = new ObservableCollection<Instructor>(this.KalumDBContext.Instructores.ToList());
            this.Salones = new ObservableCollection<Salon>(this.KalumDBContext.Salones.ToList());
            this.Horarios = new ObservableCollection<Horario>(this.KalumDBContext.Horarios.ToList());
            if(ClasesViewModel.Seleccionado != null)
            {
                Titulo = "Modificar Registro";
            }
            else 
            {
                this.Titulo = "Nuevo Registro";                
            }

        }
        public bool CanExecute(object parametro)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
        }
    }
}