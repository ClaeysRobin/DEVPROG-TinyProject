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
    public partial class InfoSelectionPage : ContentPage
    {
        private string name;
        public InfoSelectionPage(string p_name)
        {
            InitializeComponent();
            name = p_name;
            
            
        }
    }
}