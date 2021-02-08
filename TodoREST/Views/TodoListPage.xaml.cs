using System;
using Xamarin.Forms;

namespace TodoREST
{
	public partial class TodoListPage : ContentPage
	{
		public TodoListPage (string imagen, string nombre)
		{
            InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
            MuestraFecha();
            Avatar.Source = imagen;
            Nombre.Text = nombre;
        }

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			listView.ItemsSource = await App.TodoManager.GetTasksAsync ();
		}

		async void OnAddItemClicked (object sender, EventArgs e)
		{
            await Navigation.PushAsync(new TodoItemPage(true)
            {
                BindingContext = new TodoItem
                {
                    ID = Guid.NewGuid().ToString()
                }
            });
		}

		async void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = e.SelectedItem as TodoItem
            });
		}

        #region Métodos Propios

        private void MuestraFecha()
        {
            var idioma = new System.Globalization.CultureInfo("es-ES");
            var dia = idioma.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
            var fechaDia = DateTime.Now.Day.ToString();
            var mes = idioma.DateTimeFormat.GetMonthName(DateTime.Now.Month);

            lblDiaHoy.Text += dia.ToString() + ", " + fechaDia + " de " + mes;
        }

        #endregion

    }
}
