using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TodoREST.Models;
using Xamarin.Forms;

namespace TodoREST.ViewModels
{
    class UserListViewModel : INotifyPropertyChanged
    {
        #region Atributos
        private string avatar;
        private string nombre;

        public UserListViewModel()
        {
            
        }
        #endregion

        #region Propiedades

        public string usuarioAvatar
        {
            get => avatar; 
            set 
            {
                avatar = value;
                var args = new PropertyChangedEventArgs(nameof(usuarioAvatar));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string usuarioNombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(usuarioNombre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        #endregion

        #region Comandos
        public ICommand UsuarioCmd 
        {
            get { return new RelayCommand(Acceso); }
        }
        public ICommand ProfeCmd
        {
            get { return new RelayCommand(Profesor); }
        }
        public ICommand AlumnoCmd
        {
            get { return new RelayCommand(Alumno); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Métodos
        private void Acceso()
        {
            if (usuarioNombre != null && usuarioAvatar != null)
            {
                Application.Current.MainPage.Navigation.PushAsync(new TodoListPage(usuarioAvatar, usuarioNombre));
            }
            else
            {
                Application.Current.MainPage.Navigation.PushAsync(new TodoListPage("m1.jpg", "Monstruo de las Galletas"));
            }
             
        }
        private void Profesor()
        {
            usuarioAvatar = "f1.jpg";
            usuarioNombre = "David Góngora";
        }
        private void Alumno()
        {
            usuarioAvatar = "c1.jpg";
            usuarioNombre = "Carlos Fernández";
        }
        #endregion

    }
}
