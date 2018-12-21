using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Powah
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FirstRunPage : ContentPage
	{
		public FirstRunPage ()
		{
			InitializeComponent ();
		}
    }
}