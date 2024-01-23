using System;
using System.Collections.Generic;

using Xamarin.Forms;
using xamarin_to_do_list.Models;

namespace xamarin_to_do_list.Views
{	
	public partial class EditTaskPage : ContentPage
	{	
		public EditTaskPage ()
		{
			InitializeComponent ();
            TimeFormating = new TimePicker
            {
                   Format = "HH:mm",

            };

        }
        
        void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            to_do todo = (to_do)BindingContext;

            if (IsValidInput(todo))
            {
                App.Database.SaveItem(todo);
                this.Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "Please fill in all required fields.", "OK");
            }
        }

        private bool IsValidInput(to_do todo)
        {
            if (string.IsNullOrWhiteSpace(todo.Title) ||
                string.IsNullOrWhiteSpace(todo.Description) ||
                todo.DueDate == DateTime.MinValue ||
                todo.Time == TimeSpan.MinValue)
            {
                return false;
            }

            return true;
        }

        void Delete_Clicked(System.Object sender, System.EventArgs e)
        {
            to_do todo = (to_do)BindingContext;
            App.Database.DeleteItem(todo.Id);
            Navigation.PopAsync();
        }

        void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        void Entry_Completed(System.Object sender, System.EventArgs e)
        {
            if (sender is Entry entry)
            {
                entry.Text = ToTitleCase(entry.Text);
            }

            if (sender is Entry entry1)
            {
                entry1.Text = char.ToUpper(entry1.Text[0]) + entry1.Text.Substring(1);

                to_do friend = (to_do)BindingContext;

                FormattedString formattedString = new FormattedString();

                formattedString.Spans.Add(new Span { Text = $" ToDo: {entry1.Text}", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });

                friend.Title = formattedString.ToString();
            }
        }

        private string ToTitleCase(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                }
            }

            return string.Join(' '.ToString(), words);
        }
    }
}

