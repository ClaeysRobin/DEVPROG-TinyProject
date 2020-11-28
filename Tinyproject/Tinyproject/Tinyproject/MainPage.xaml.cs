using Ex01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinyproject.Models;
using Tinyproject.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tinyproject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private static Random _rnd = new Random();
        public MainPage()
        {
            InitializeComponent();
            // TestStockRepository();
            loadData();
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


            //DateTime date = new DateTime(2020, 11, 20);
            List<StockPrice> stockPrice = await StockRepositories.GetCompanyStockPrice(selectedCard.Ticker);
            //List<StockSalesOnDate> stockSales = await StockRepositories.GetStockSalesOnDate(selectedCard.Ticker, date);
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

            //3. trelloCard
            List<TrelloCard> trellocards = await StockRepositories.GetTrelloCardAsync(selectedList.ListId);
            TrelloCard selectedCard = trellocards[_rnd.Next(trellocards.Count)];
            
            lvwtop10.ItemsSource = trellocards;
        }
    }
}
