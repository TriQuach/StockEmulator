using StockEmulator.Models;
using StockEmulator.Utilities;
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


            firstQuestion.Items.Add("what's your name?");
            firstQuestion.Items.Add("how are you?");
            firstQuestion.Items.Add("where are you from?");

            secondQuestion.Items.Add("your child hood hero?");
            secondQuestion.Items.Add("your favourite color?");
            secondQuestion.Items.Add("your superstar?");

            loginPage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Navigation.PopModalAsync())
            });

            

        }
        async void PressRegister(object sender, EventArgs arg)
        {
            if (confirmPassword.Text != password.Text)
            {
                await DisplayAlert("Register Failed!", "Confirmed Password Does NOT Match Your Password!", "OK");
                return;
            }

            SignUpModel signUpInfo = new SignUpModel()
            {
                Username = username.Text,
                Password = password.Text,
                FullName = fullname.Text,
                FirstSecurityQuestion = firstQuestion.Items[firstQuestion.SelectedIndex],
                FirstSecurityAnswer = firstAnswer.Text,
                SecondSecurityQuestion = secondQuestion.Items[secondQuestion.SelectedIndex],
                SecondSecurityAnswer = secondAnswer.Text
            };

            bool success = await App.accountRestServiceManager.SignUpTaskAsync(signUpInfo);

            if (success)
            {
                Constants.currentUsername = signUpInfo.Username;

                //await Navigation.PopModalAsync();

                //var page = new MainPage();
                //NavigationPage.SetHasNavigationBar(page, false);
                //Navigation.InsertPageBefore(page, Navigation.NavigationStack[0]);
                //await Navigation.PopAsync();
                await Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Register Failed!", "Username Existed!", "OK");
                return;
            }
        }
    }
}
