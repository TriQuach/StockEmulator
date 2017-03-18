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

            secondquestion.Items.Add("your child hood hero?");
            secondquestion.Items.Add("your favourite color?");
            secondquestion.Items.Add("your superstar?");

            loginpage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Navigation.PopModalAsync())
            });

            

        }
        async void Register(object sender, EventArgs arg)
        {
            //name = fullname.Text; // muon lay entry nao, chi can qua SignUp.xaml tim x:Name tuong ung roi goi ham .Text
            //name = firstquestion.Items[firstquestion.SelectedIndex]; // tuong tu voi picker
            await Navigation.PopModalAsync();
        }
    }
}
