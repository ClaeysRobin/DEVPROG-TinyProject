using Ex01.Models;
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
    public partial class Top10Page : ContentPage
    {
        private static Random _rnd = new Random();
        private string usedlist = "";
        public Top10Page()
        {
            InitializeComponent();
            // TestStockRepository();
            loadData();

            // btn clicked
            btnAdd.Clicked += BtnAdd_Clicked;

        }

        private async Task TestStockRepository()
        {
            // TRELLO
            //1. trelloBoard
            List<TrelloBoard> boardsList = await StockRepositories.GetTrelloBoardsAsync();
            TrelloBoard selectedboard = boardsList.Where(x => x.IsFavorite == true).First();

            //2. trelloList
            List<TrelloList> trelloLists = await StockRepositories.GetTrelloListAsync(selectedboard.BoardId);
            TrelloList selectedList = trelloLists[_rnd.Next(trelloLists.Count)];

            //3. trelloCard
            List<TrelloCard> trellocards = await StockRepositories.GetTrelloCardAsync(selectedList.ListId);
            TrelloCard selectedCard = trellocards[_rnd.Next(trellocards.Count)];


            DateTime date = new DateTime(2020, 11, 20);
            List<StockPrice> stockPrice = await StockRepositories.GetCompanyStockPrice(selectedCard.Ticker);
            List<StockSalesOnDate> stockSales = await StockRepositories.GetStockSalesOnDate(selectedCard.Ticker, date);
            List<CompanyInfo> companyInfo = await StockRepositories.GetCompanyInfo(selectedCard.Ticker);

        }

        private async Task loadData()
        {    // TRELLO
            //1. trelloBoard
            List<TrelloBoard> boardsList = await StockRepositories.GetTrelloBoardsAsync();
            TrelloBoard selectedboard = boardsList.Where(x => x.IsFavorite == true).First();

            //2. trelloList
            List<TrelloList> trelloLists = await StockRepositories.GetTrelloListAsync(selectedboard.BoardId);
            TrelloList selectedList = trelloLists[_rnd.Next(trelloLists.Count)];
            usedlist = selectedList.ListId;

            //3. trelloCard
            List<TrelloCard> trellocards = await StockRepositories.GetTrelloCardAsync(selectedList.ListId);
            TrelloCard selectedCard = trellocards[_rnd.Next(trellocards.Count)];

            
            lvwtop10.ItemsSource = trellocards;

            //check list for max companies
            if (trellocards.Count >= 10)
            {
                btnAdd.IsEnabled = false;
                btnAdd.Text = "Top 10 already full";
            }
        }

        private void lvwtop10_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // eerst object omzetten naar een trellocard object
            var selectedCompany = (TrelloCard)lvwtop10.SelectedItem;
            Navigation.PushAsync(new InfoSelectionPage(selectedCompany));
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPage(usedlist));
        }


    }
}