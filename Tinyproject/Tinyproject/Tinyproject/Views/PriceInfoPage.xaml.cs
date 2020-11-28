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
        private string Name, Ticker, Date;
        public PriceInfoPage(string ticker, string name)
        {
            InitializeComponent();
            Name = name;
            Ticker = ticker;

            this.Title = Name;

            loaddata();

            btnHistory.Clicked += BtnHistory_Clicked;

            
        }

        private void BtnHistory_Clicked(object sender, EventArgs e)
        {
            lvwhistorytrades.IsVisible = true;
        }

        private async Task loaddata()
        {
            List<StockPrice> stockPrice = await StockRepositories.GetCompanyStockPrice(Ticker);
            List<StockSalesOnDate> stockSales = await StockRepositories.GetStockSalesOnDate(Ticker, DateTime.Today.AddDays(-1));

            lvwPriceInfo.ItemsSource = stockPrice;
            lvwhistorytrades.ItemsSource = stockSales;
        }
    }
}