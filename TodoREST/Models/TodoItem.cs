﻿using System;

namespace TodoREST
{
	public class TodoItem
	{
		public string ID { get; set; }

		public string Name { get; set; }

		public string Notes { get; set; }

		public bool Done { get; set; }

		public int Prioridad { get; set; }

		public string Color { get; set; }
	}
}
