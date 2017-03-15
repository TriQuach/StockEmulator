using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StockEmulator.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            country.Items.Add("Viet Nam");
            country.Items.Add("Lao");
            country.Items.Add("Campuchia");
            country.Items.Add("Singapore");
            country.Items.Add("Australia");


            firstquestion.Items.Add("what's your name?");
            firstquestion.Items.Add("how are you?");
            firstquestion.Items.Add("where are you from?");



        }
    }
}
