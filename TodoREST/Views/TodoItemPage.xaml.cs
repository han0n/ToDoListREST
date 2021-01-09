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
            var todoItem = (TodoItem)BindingContext;
            var picker = sender as Picker;

            if (picker.SelectedIndex == 0)
            {
                todoItem.Color = "LightCoral";
            }

            if (picker.SelectedIndex == 1)
            {
                todoItem.Color = "LightSalmon";
            }

            if (picker.SelectedIndex == 2)
            {
                todoItem.Color = "#0F0";
            }

            if (picker.SelectedIndex == 3)
            {
                todoItem.Color = "#F0F";
            }



        }
    }
}
