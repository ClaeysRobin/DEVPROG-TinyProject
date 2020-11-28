using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tinyproject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriceInfoPage : ContentPage
    {
        private string Name;
        public PriceInfoPage(string name)
        {
            InitializeComponent();
            Name = name;
        }
    }
}