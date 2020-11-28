using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinyproject.Models;
using Tinyproject.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tinyproject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriceInfoPage : ContentPage
    {
        private string Name, Ticker;
        public PriceInfoPage(string ticker, string name)
        {
            InitializeComponent();
            Name = name;
            Ticker = ticker;

            this.Title = Name;

            loaddata();
        }

        private async Task loaddata()
        {
            List<StockPrice> stockPrice = await StockRepositories.GetCompanyStockPrice(Ticker);
            lvwPriceInfo.ItemsSource = stockPrice;
        }
    }
}