using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Task6.Models;

namespace WPF_Task6.ViewModels
{
    public class BeerUCViewModel : BaseViewModel
    {
        private Beer beer;

        public Beer Beer
        {
            get { return beer; }
            set { beer = value; OnPropertyChanged(); }
        }

        public int Count { get; set; }

        public string Profit { get; set; }

        public BeerUCViewModel()
        {

        }
    }
}
