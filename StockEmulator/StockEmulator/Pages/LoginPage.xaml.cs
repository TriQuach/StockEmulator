using StockEmulator.Models;
using StockEmulator.Utilities;
using System;
using Xamarin.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace StockEmulator.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            SignUp.GestureRecognizers.Add(new TapGestureRecognizer
            {
               Command = new Command(() => Navigation.PushModalAsync(new SignUpPage()))
            });
            MultiTrigger multiTriggerLogin = new MultiTrigger(typeof(Button));

            Condition usernameBindingCondition = new BindingCondition
            {
                Binding = new Binding
                {
                    Source = username,
                    Path = "Text.Length",
                    Converter = new UsernamePasswordBoolConverter()
                },
                Value = true
            };
            Condition passwordBindingCondition = new BindingCondition
            {
                Binding = new Binding
                {
                    Source = password,
                    Path = "Text.Length",
                    Converter = new UsernamePasswordBoolConverter()
                },
                Value = true
            };

            Setter setterButtonLogin = new Setter
            {
                Property = Button.IsEnabledProperty,
                Value = true
            };

            multiTriggerLogin.Conditions.Add(usernameBindingCondition);
            multiTriggerLogin.Conditions.Add(passwordBindingCondition);

            multiTriggerLogin.Setters.Add(setterButtonLogin);

            loginButton.Triggers.Add(multiTriggerLogin);
        }

        class UsernamePasswordBoolConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if ((int)value > 0)
                {
                    return true;
                }
                return false;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        async public void PressLogin(object sender, EventArgs arg)
        {
            loginButton.IsEnabled = false;

            LoginModel thisUser = new LoginModel()
            {
                Username = username.Text,
                Password = password.Text
            };

            bool valid = await App.accountRestServiceManager.LoginTaskAsync(thisUser);

            loginButton.IsEnabled = true;
            if (valid)
            {
                Constants.currentUsername = thisUser.Username;

                //var page = new MainPage();
                //NavigationPage.SetHasNavigationBar(page, false);
                //Navigation.InsertPageBefore(page, this);
                //await Navigation.PopAsync();
                await Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Login Failed!", "Wrong USERNAME or PASSWORD!", "OK");
            }
//            Debug.WriteLine(valid);
        }
    }
}
