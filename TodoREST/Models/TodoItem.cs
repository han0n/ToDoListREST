using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoREST
{
	public class TodoItem : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] String color = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(color));
		}

		public string ID { get; set; }

		public string Name { get; set; }

		public string Notes { get; set; }

		public bool Done { get; set; }

		public int Prioridad { get; set; }

		private string color;
		public string Color {
			get { return color; }
            set 
			{ 
				color = value;
				OnPropertyChanged();
			}
		}
	}
}
