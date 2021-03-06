﻿using System;
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


            btnHistory.Clicked += BtnHistory_Clicked;

            
        }

        private void BtnHistory_Clicked(object sender, EventArgs e)
        {
            lvwhistorytrades.IsVisible = true;
        }

        private async Task loaddata()
        {
            if (DateTime.Today.DayOfWeek.ToString() == "saturday" || DateTime.Today.DayOfWeek.ToString() == "sunday")
            {
                btnHistory.IsEnabled = false;
                FrmWeekend.IsVisible = true;
            }
            else
            {
                FrmWeekend.IsVisible = false;

                List<StockPrice> stockPrice = await StockRepositories.GetCompanyStockPrice(Ticker);
                List<StockSalesOnDate> stockSales = await StockRepositories.GetStockSalesOnDate(Ticker, DateTime.Today.AddDays(-3));

                lvwPriceInfo.ItemsSource = stockPrice;
                lvwhistorytrades.ItemsSource = stockSales;
            }
        }
    }
}