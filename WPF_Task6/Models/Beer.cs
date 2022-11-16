using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Task6.Models
{
    public class Beer
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Volume { get; set; }
        public string ImageSource { get; set; }

        public Beer(string name, string price, string volume, string imageSource)
        {
            Name = name;
            Price = price;
            Volume = volume;
            ImageSource = imageSource;
        }
    }
}
