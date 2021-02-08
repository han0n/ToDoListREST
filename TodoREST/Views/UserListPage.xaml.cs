using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Models;
using TodoREST.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListPage : ContentPage
    {
        public UserListPage()
        {
            InitializeComponent();
            BindingContext = new UserListViewModel();

        }

        private void David_User(object sender, EventArgs e)
        {
            Nom.Text = "David Góngora";
            Img.Text = "f1.jpg";
            Entrar.IsVisible = true;
            Entrar.Text = "Acceder como Profe";
        }

        private void Carlos_User(object sender, EventArgs e)
        {
            Nom.Text = "Carlos Fernández";
            Img.Text = "c1.jpg";
            Entrar.IsVisible = true;
            Entrar.Text = "Acceder como Alumno";
        }
    }
}