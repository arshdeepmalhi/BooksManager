using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BooksManager.Models;
using BooksManager.Data;

namespace BooksManager
{
    public partial class DetailedBookPage : ContentPage
    {
        public DetailedBookPage()
        {
            InitializeComponent();
        }

        async void OnBorrowButtonClicked(object sender, EventArgs e)
        {
            var book = (BookInfo)BindingContext;
            if (book.Lent == true)
            {
                await DisplayAlert("prompt", "The book has been lent and cannot be borrowed", "OK");
            }
            else
            {
                book.Lent = true;
                await App.Database.BorrowBookAsync(book);
                await DisplayAlert("prompt", "Successfully borrowed", "OK");
                await Navigation.PopAsync();
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var book = (BookInfo)BindingContext;
            await App.Database.SaveBookInfoAsync(book);
            await DisplayAlert("prompt", "Successfully modified", "OK");
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var book = (BookInfo)BindingContext;
            if (book.Lent == true)
            {
                await DisplayAlert("prompt", "This book is being loaned out and cannot be deleted", "OK");
            }
            else
            {
                await App.Database.DeleteBookInfoAsync(book);
                await DisplayAlert("prompt", "successfully deleted", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
