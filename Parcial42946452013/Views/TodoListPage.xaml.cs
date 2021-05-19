﻿using Parcial42946452013.Models;
using System;
using Xamarin.Forms;

namespace Parcial42946452013
{
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }
}