using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_Task6.Commands;
using WPF_Task6.Models;
using WPF_Task6.Repositories;
using WPF_Task6.Views;

namespace WPF_Task6.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand SelectedItemChangedCommand { get; set; }
        public RelayCommand CountUpCommand { get; set; }
        public RelayCommand CountDownCommand { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public RelayCommand ShowHistoryCommand { get; set; }

        private int beerCount;
        public int BeerCount
        {
            get { return beerCount; }
            set { beerCount = value; OnPropertyChanged(); }
        }

        private double totalamount;

        public double TotalAmount
        {
            get { return totalamount; }
            set { totalamount = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Beer> Beers { get; set; }

        private Beer selectedBeer;

        public Beer SelectedBeer
        {
            get { return selectedBeer; }
            set { selectedBeer = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            Beers = new ObservableCollection<Beer>(new FakeRepo().GetAllBeers());
            SelectedBeer = Beers[0];

            SelectedItemChangedCommand = new RelayCommand((newSelectedBeer) =>
            {
                var beer = newSelectedBeer as Beer;
                SelectedBeer = beer;
            });

            CountUpCommand = new RelayCommand(o =>
            {
                BeerCount++;
                TotalAmount = BeerCount * int.Parse(SelectedBeer.Price);
            });

            CountDownCommand = new RelayCommand(o =>
            {
                if (BeerCount <= 0)
                {
                    MessageBox.Show("Count cannot be less than zero!");
                }
                else
                {
                    BeerCount--;
                }
                TotalAmount = BeerCount * int.Parse(SelectedBeer.Price);
            });

            BuyCommand = new RelayCommand((e) =>
            {
                if (BeerCount == 0)
                {
                    MessageBox.Show("Increae count of beer! It cannot be 0!");
                    return;
                }
                MessageBox.Show($@"Succesfully Bought Beer : {SelectedBeer.Name}
Total Price : {TotalAmount}$");

                var beerUc = new BeerUC();
                var beerUcViewModel = new BeerUCViewModel();
                beerUcViewModel.Beer = SelectedBeer;
                beerUcViewModel.Count = BeerCount;
                beerUcViewModel.Profit = TotalAmount + "$";
                beerUc.DataContext = beerUcViewModel;
                App.PurchasedBeers.Add(beerUc);
            });

            ShowHistoryCommand = new RelayCommand((e) =>
            {
                var historyWindow = new HistoryWindow();
                if (App.PurchasedBeers.Count == 0)
                {
                    var tb = new TextBlock();
                    tb.Width = 800;
                    tb.Text = "No beer has been purchased yet . . .";
                    tb.FontSize = 30;
                    tb.TextAlignment = TextAlignment.Center;
                    tb.Margin = new Thickness(0, 30, 0, 0);
                    historyWindow.WrapPanel.Children.Add(tb);
                }
                else
                {
                    foreach (var item in App.PurchasedBeers)
                    {
                        historyWindow.WrapPanel.Children.Add(new BeerUC { DataContext = item.DataContext});
                    }
                }
                historyWindow.Show();
            });
        }
    }
}
