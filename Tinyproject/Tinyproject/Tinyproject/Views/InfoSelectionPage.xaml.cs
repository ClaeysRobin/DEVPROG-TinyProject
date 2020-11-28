using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinyproject.Repositories;
using Tinyproject.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ex01.Models;

namespace Tinyproject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoSelectionPage : ContentPage
    {
        private string Ticker, Name;
        private TrelloCard SelectedCard;
        public InfoSelectionPage(TrelloCard card)
        {
            InitializeComponent();
            Ticker = card.Ticker;
            Name = card.Name;
            SelectedCard = card;

            //change title of page to selected company
            this.Title = Name;

            btnCompanyInfo.Clicked += BtnCompanyInfo_Clicked;
            btnPriceInfo.Clicked += BtnPriceInfo_Clicked;
            
        }

        private async Task deleteStock(TrelloCard card)
        {
            //5. DELTE trelloCard
            card.IsClosed = true;
            await StockRepositories.DeleteCardAsync(card);
        }


        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            deleteStock(SelectedCard);
            Navigation.PushAsync(new Top10Page());
        }


        private void BtnPriceInfo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PriceInfoPage(Ticker, Name));
        }

        private void BtnCompanyInfo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CompanyInfoPage(Ticker, Name));
        }
    }
}