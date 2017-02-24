﻿using StockEmulator.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator.Tabs
{
    public partial class FindStocksTab : ContentPage
    {
        public FindStocksTab()
        {
            InitializeComponent();
        }
        async void Show_Buy(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new BuyPage());
        }
        async public void Show_Sell(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new SellPage());
        }
    }
}