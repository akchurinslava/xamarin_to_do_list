using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using xamarin_to_do_list.Models;

namespace xamarin_to_do_list.Views
{	
	public partial class ListPage : ContentPage
	{	
		public ListPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            var sorted = TaskList.ItemsSource = App.Database.GetItems().OrderBy(x => x.DueDate).ThenBy(x => x.Time).ToList();
            TaskList.ItemsSource = sorted;
            base.OnAppearing();
        }

        private async void TaskList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            to_do selectedtodo = (to_do)e.SelectedItem;
            EditTaskPage editTaskPage = new EditTaskPage();
            editTaskPage.BindingContext = selectedtodo;
            await Navigation.PushAsync(editTaskPage);
        }

        private async void ADD_Clicked(System.Object sender, System.EventArgs e)
        {
            to_do task = new to_do();
            EditTaskPage editTaskPage = new EditTaskPage();
            editTaskPage.BindingContext = task;
            await Navigation.PushAsync(editTaskPage);
        }

    }
}

