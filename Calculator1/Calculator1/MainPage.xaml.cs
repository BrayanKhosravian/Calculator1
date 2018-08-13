using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator1.ViewModels;
using Xamarin.Forms;

namespace Calculator1
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		    BindingContext = new MainPageViewModel();
		}
	}
}
