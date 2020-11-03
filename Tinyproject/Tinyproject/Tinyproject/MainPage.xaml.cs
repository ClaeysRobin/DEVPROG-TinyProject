using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinyproject.Models;
using Tinyproject.Repositories;
using Xamarin.Forms;

namespace Tinyproject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            TestStockRepository();
        }

        private async Task TestStockRepository()
        {
            DateTime date = new DateTime(2020,11,02);
            List<StockPrice> stockPrice = await StockRepositories.GetCompanyStockPrice("amzn");
            List<StockSalesOnDate> stockSales = await StockRepositories.GetStockSalesOnDate("amzn", date);
            List<CompanyInfo> companyInfo = await StockRepositories.GetCompanyInfo("amzn");
            
        }
    }
}
