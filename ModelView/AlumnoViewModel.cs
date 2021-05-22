using System;
using System.ComponentModel;
using System.Windows.Input;
using Kalum2021.DataContext;
using Kalum2021.Models;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Kalum2021.ModelView
{
    public class AlumnoViewModel : INotifyPropertyChanged, ICommand
    {
        public String Carne {get;set;}
        public String NoExpediente {get;set;}
        public String Apellidos {get;set;}
        public String Nombres {get;set;}
        public String Email {get;set;}
        private KalumDBContext dBContext;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public AlumnoViewModel Instancia {get;set;} 

        public AlumnosViewModel AlumnosViewModel {get;set;}

        public String Titulo {get;set;}

        private IDialogCoordinator DialogCoordinator;

        public AlumnoViewModel(AlumnosViewModel AlumnosViewModel, IDialogCoordinator DialogCoordinator)
        {
            this.Instancia = this;
            this.DialogCoordinator = DialogCoordinator;
            this.dBContext = new KalumDBContext();
            this.AlumnosViewModel = AlumnosViewModel;
            if(this.AlumnosViewModel.Seleccionado != null)
            {
                this.Carne = this.AlumnosViewModel.Seleccionado.Carne;
                this.NoExpediente = this.AlumnosViewModel.Seleccionado.NoExpediente;
                this.Apellidos = this.AlumnosViewModel.Seleccionado.Apellidos;
                this.Nombres = this.AlumnosViewModel.Seleccionado.Nombres;
                this.Email = this.AlumnosViewModel.Seleccionado.Email;
                this.Titulo = "Modificar Registro";
            }
            else if(this.AlumnosViewModel.Seleccionado == null)
            {
                this.Titulo = "Nuevo Registro";
            }
        }
        public bool CanExecute(object parametro)
        {
            return true;
        }

        public async void Execute(object parametro)
        {
            if(parametro.Equals("Guardar"))
            {
                try{
                    if(this.AlumnosViewModel.Seleccionado == null)
                    {
                        var ApellidosParameter = new SqlParameter("@Apellidos",this.Apellidos);
                        var NombresParameter = new SqlParameter("@Nombres", this.Nombres);
                        var EmailParameter = new SqlParameter("@Email",this.Email);
                        var Resultado = this.dBContext
                                                .Alumnos
                                                .FromSqlRaw("sp_registrar_alumno @Apellidos, @Nombres, @Email",ApellidosParameter, NombresParameter, EmailParameter)
                                                .ToList();
                        foreach(Object registro in Resultado)
                        {
                            this.AlumnosViewModel.Alumnos.Add((Alumno)registro);                        
                        }
                        await DialogCoordinator.ShowMessageAsync(this,"Alumnos","Registro actualizado!!!");
                    }
                    else if(this.AlumnosViewModel.Seleccionado != null)
                    {
                        int posicion = this.AlumnosViewModel.Alumnos.IndexOf(this.AlumnosViewModel.Seleccionado);
                        Alumno temporal = new Alumno();
                        temporal.Carne = this.AlumnosViewModel.Seleccionado.Carne;
                        temporal.NoExpediente = this.NoExpediente;
                        temporal.Apellidos = this.Apellidos;
                        temporal.Nombres = this.Nombres;
                        temporal.Email = this.Email;
                        this.dBContext.Entry(temporal).State = EntityState.Modified;
                        this.AlumnosViewModel.Alumnos.RemoveAt(posicion);
                        this.AlumnosViewModel.Alumnos.Insert(posicion,temporal);
                        this.dBContext.SaveChanges();                
                        await DialogCoordinator.ShowMessageAsync(this,"Alumnos","Registro actualizado!!!");
                    }                    
                }
                catch(Exception e)
                {
                    await DialogCoordinator.ShowMessageAsync(this,"Error",e.Message);
                }
            }
        }
    }
}