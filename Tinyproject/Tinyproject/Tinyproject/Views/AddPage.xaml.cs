using Ex01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinyproject.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tinyproject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        private static Random _rnd = new Random();
        private string ListId = "";
        public AddPage(string p_usedlist)
        {
            InitializeComponent();
            ListId = p_usedlist;

            btnAdd.Clicked += BtnAdd_Clicked;

            //change title of page to selected company
            this.Title = "Add new stock to watchlist";
        }

        //adding new trello
        private async Task AddNewCard(string NewName, string NewTicker)
        {
            TrelloCard newCard = new TrelloCard { Ticker = NewTicker, Name = NewName };
            await StockRepositories.AddCardAsync(ListId, newCard);
            
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entName.Text) && !string.IsNullOrWhiteSpace(entTicker.Text))
            {
                string NewName = entName.Text;
                string NewTicker = entTicker.Text.ToUpper();
                AddNewCard(NewName, NewTicker);

                Navigation.PushAsync(new Top10Page());
            }
        }
    }
}