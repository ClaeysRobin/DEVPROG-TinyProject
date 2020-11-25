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
        private string Ticker, Name;
        public InfoSelectionPage(string p_ticker, string p_name)
        {
            InitializeComponent();
            Ticker = p_ticker;
            Name = p_name;

            //change title of page to selected company
            this.Title = Name;
            
            
        }
    }
}