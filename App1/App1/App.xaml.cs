using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinMapSample;


namespace App1
{
	public partial class App : Application
	{
		public App ()
		{
            //InitializeComponent();

            //MainPage = new App1.MainPage();
            MainPage = new MapPage { Title = "Map/Zoom", Icon = "glyphish_74_location.png" };

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
