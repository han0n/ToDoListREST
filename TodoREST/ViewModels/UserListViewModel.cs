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

        private ObservableCollection<User> listaUsuarios = new ObservableCollection<User>();

        public UserListViewModel()
        {
            this.listaUsuarios.Add(new User()
            {
                Avatar = "f1.jpg",
                Nombre = "David Góngora"
            });
            this.listaUsuarios.Add(new User()
            {
                Avatar = "c1.jpg",
                Nombre = "Carlos Fernández"
            });
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
        public ICommand UsuarioCmd {
            get
            {
                return new RelayCommand(Acceso);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Métodos
        private void Acceso()
        {
            foreach (var item in this.listaUsuarios.ToList())
            {
                if(item.Nombre == usuarioNombre.ToString())
                {
                    Application.Current.MainPage.Navigation.PushAsync(new TodoListPage(usuarioAvatar, usuarioNombre));
                }
            }
        }
        #endregion

    }
}
