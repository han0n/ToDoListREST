﻿using Xamarin.Forms;

namespace TodoREST
{
    public static class Constants
    {
        // URL of REST service
        public static string RestUrl = Device.RuntimePlatform == Device.Android ? "http://10.0.2.2:5000/api/todoitems/{0}" : "http://localhost:5001/api/todoitems/{0}";
    }
}
