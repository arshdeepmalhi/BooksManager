using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BooksManager.Models;
using BooksManager.Data;

namespace BooksManager
{
    public partial class DetailedRecordPage : ContentPage
    {
        public DetailedRecordPage()
        {
            InitializeComponent();
        }

        async void OnReturnButtonClicked(object sender, EventArgs e)
        {
            var record = (RecordInfo)BindingContext;
            if (record.Returned == true)
            {
                await DisplayAlert("prompt", "This book has been returned", "OK");
            }
            else
            {
                await App.Database.ReturnBookAsync(record);
                await DisplayAlert("prompt", "Returned successfully", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
