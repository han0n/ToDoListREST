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

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
			var todoItem = (TodoItem)BindingContext;
            double valor = e.NewValue;

            if (valor == 3)
            {
                todoItem.Color = "LightCoral";
            }
            else
            {
                if (valor == 2)
                {
                    todoItem.Color = "LightSalmon";
                }
                else
                {
                    if (valor == 1)
                    {
                        todoItem.Color = "#0F0";
                    }
                    else
                    {
                        if (valor == 0)
                        {
                            todoItem.Color = "#F0F";
                        }
                    }
                }
            }
        }
    }
}
