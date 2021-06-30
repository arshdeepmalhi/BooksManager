using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BooksManager.Models;

namespace BooksManager
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var user = (UserInfo)BindingContext;
            await App.Database.CreateNewUser(user);
            int MaxUserID = await App.Database.GetMaxUserID();
            await DisplayAlert("registration success", string.Format("Your user id is {0}", MaxUserID), "OK");
            await Navigation.PopAsync();
        }

    }

}
 