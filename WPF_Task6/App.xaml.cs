using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_Task6.Models;
using WPF_Task6.Views;

namespace WPF_Task6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<BeerUC> PurchasedBeers { get; set; } = new List<BeerUC>();
    }
}
