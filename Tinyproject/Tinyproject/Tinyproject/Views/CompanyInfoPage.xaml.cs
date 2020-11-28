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
    public partial class CompanyInfoPage : ContentPage
    {
        private string Ticker, Name;
        public CompanyInfoPage(string ticker, string name)
        {
            InitializeComponent();
            Ticker = ticker ;
            Name = name;

            this.Title = Name;
            

            loaddata();

            
        }

        private async Task loaddata()
        {
            List<CompanyInfo> companyInfo = await StockRepositories.GetCompanyInfo(Ticker);
            lvwCompanyInfo.ItemsSource = companyInfo;
           
        }
    }
}