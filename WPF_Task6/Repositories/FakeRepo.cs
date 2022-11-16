using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Task6.Models;

namespace WPF_Task6.Repositories
{
    public class FakeRepo
    {
        public List<Beer> GetAllBeers()
        {
            List<Beer> beers = new List<Beer>();
            var beer1 = new Beer("Draught Lager", "2", "300ml", @"\Images\beer1.jpg");
            var beer2 = new Beer("Old Yale Brewing", "6", "0.45l", @"\Images\beer2.jpeg");
            var beer3 = new Beer("Buxton Brewery", "5", "0.65l", @"\Images\beer3.jpeg");
            var beer4 = new Beer("Hoppin' Frog", "12", "1l", @"\Images\beer4.jpg");
            var beer5 = new Beer("Zlatni Medvjed ", "4", "0.5l", @"\Images\beer5.jpg");
            beers.Add(beer1);
            beers.Add(beer2);
            beers.Add(beer3);
            beers.Add(beer4);
            beers.Add(beer5);
            return beers;
        }
    }
}
