using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator
{
    public partial class WithoutTemplate : ContentPage
    {
        public WithoutTemplate()
        {
            InitializeComponent();
            var people = new List<Person>
            {
                new Person("Tri",21,"KT"),
                new Person("Tri",21,"KT"),
                new Person("Tri",21,"KT"),
                new Person("Tri",21,"KT"),


            };
            lstView.ItemsSource = people;
        }
    }
}
