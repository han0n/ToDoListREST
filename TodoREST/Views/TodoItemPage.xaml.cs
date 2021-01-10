using System;
using Xamarin.Forms;

namespace TodoREST
{
	public partial class TodoItemPage : ContentPage
	{
		bool isNewItem;

		public TodoItemPage (bool isNew = false)
		{
			InitializeComponent ();
			isNewItem = isNew;

			if (isNewItem == true)
            {
				Titulo.Text = "Crear Tarea";
            }
            else
            {
				Titulo.Text = "Modificar Tarea";
            }

		}

		async void OnSaveButtonClicked (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.SaveTaskAsync (todoItem, isNewItem);
			await Navigation.PopAsync ();
		}

		async void OnDeleteButtonClicked (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.DeleteTaskAsync (todoItem);
			await Navigation.PopAsync ();
		}

		async void OnCancelButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PopAsync ();
		}


        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
			PickerLabel.Text = ListaPrioridad.Items[ListaPrioridad.SelectedIndex];
			// PickerLabel.Text = PickerList.SelectedItem.ToString() ;

			var todoItem = (TodoItem)BindingContext;
            var picker = sender as Picker;

			switch (picker.SelectedIndex)
            {
				case 0:
					todoItem.Color = "DarkGray";
					todoItem.Prioridad = 0;
					break;
				case 1:
					todoItem.Color = "LimeGreen";
					todoItem.Prioridad = 1;
					break;
				case 2:
					todoItem.Color = "Gold";
					todoItem.Prioridad = 2;
					break;
				case 3:
					todoItem.Color = "FireBrick";
					todoItem.Prioridad = 3;
					break;
			}

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
			ListaPrioridad.Focus();
		}
    }
}
