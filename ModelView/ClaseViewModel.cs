using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Kalum2021.DataContext;
using Kalum2021.Models;
using MahApps.Metro.Controls.Dialogs;
using System.Linq;
using System.Windows;


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

        public string InstructorDefinido {get;set;} = "SELECCIONAR";
        public string HorarioDefinido {get;set;} = "SELECCIONAR";
        public string SalonDefinido {get;set;} = "SELECCIONAR";
        public string CarreraTecnicaDefinido {get;set;} = "SELECCIONAR";
        public string ValorDescripcion {get;set;}
        public string ValorCiclo {get;set;} = "0";
        public string ValorCupoMaximo {get;set;} = "0";
        public string ValorCupoMinimo {get;set;} = "0";
        public CarreraTecnica CarreraTecnicaSeleccionada {get;set;}
        private Instructor InstructorSeleccionado {get;set;}
        public Salon SalonSeleccionado {get;set;}
        public Horario HorarioSeleccionado {get;set;}

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
                this.ValorDescripcion = this.ClasesViewModel.Seleccionado.Descripcion;
                this.ValorCiclo = this.ClasesViewModel.Seleccionado.Ciclo.ToString();
                this.ValorCupoMaximo = this.ClasesViewModel.Seleccionado.CupoMaximo.ToString();
                this.ValorCupoMinimo = this.ClasesViewModel.Seleccionado.CupoMinimo.ToString();
                this.CarreraTecnicaSeleccionada = this.ClasesViewModel.Seleccionado.CarreraTecnica;
                this.InstructorSeleccionado = this.ClasesViewModel.Seleccionado.Instructor;
                this.HorarioSeleccionado = this.ClasesViewModel.Seleccionado.Horario;
                this.SalonSeleccionado = this.ClasesViewModel.Seleccionado.Salon;
                this.InstructorDefinido = this.ClasesViewModel.Seleccionado.Instructor.Apellidos + " " + this.ClasesViewModel.Seleccionado.Instructor.Nombres;
                this.CarreraTecnicaDefinido = this.ClasesViewModel.Seleccionado.CarreraTecnica.Nombre;
                this.SalonDefinido = this.ClasesViewModel.Seleccionado.Salon.NombreSalon;
                this.HorarioDefinido = $"{this.ClasesViewModel.Seleccionado.Horario.HorarioInicio.ToString(@"hh\:mm")} - {this.ClasesViewModel.Seleccionado.Horario.HorarioFinal:hh\\:mm}";
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

        public async void Execute(Object Parametro)
        {
            if(Parametro.Equals("Guardar"))
            {
                Clase NuevaClase = new Clase();
                NuevaClase.ClaseId = Guid.NewGuid().ToString();
                NuevaClase.Descripcion = ValorDescripcion;
                NuevaClase.Ciclo = Convert.ToInt16(ValorCiclo);
                NuevaClase.CupoMaximo = Convert.ToInt16(ValorCupoMaximo);
                NuevaClase.CupoMinimo = Convert.ToInt16(ValorCupoMinimo);
                NuevaClase.Instructor = InstructorSeleccionado;
                NuevaClase.Salon = SalonSeleccionado;
                NuevaClase.CarreraTecnica = CarreraTecnicaSeleccionada;
                NuevaClase.Horario = HorarioSeleccionado;
                KalumDBContext.Clases.Add(NuevaClase);
                KalumDBContext.SaveChanges();
                this.ClasesViewModel.Clases.Add(NuevaClase);
                await this.DialogoCoordinator.ShowMessageAsync(this,"Clases","Registro almacena");
            }
        }
    }
}