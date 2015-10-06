using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace NoteApp
{
    public class CreatePage : ContentPage
    {
        public NotesQuery _notesQuery;
        public NotesDB _notesDB;

        private DateTime _DateTime;

        public string primary;
        public CreatePage()
        {
            //SQL local database connection
            _notesDB = new NotesDB();
            _notesQuery = new NotesQuery();

            var noteEditor = new Editor
            {
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var saveButton = new Button { Text = "SAVE", HorizontalOptions = LayoutOptions.FillAndExpand };
            var cancelButton = new Button { Text = "CANCEL", HorizontalOptions = LayoutOptions.FillAndExpand };

            
            saveButton.Clicked += (object sender, EventArgs e) =>
            {
                _DateTime = DateTime.Now;
                try
                {
                    InsertData(noteEditor.Text.ToString(), _DateTime.ToString());
                    DisplayAlert("Alert", "Saved Succesfully.", "OK");
                    Navigation.PushAsync(new HomePage());
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    DisplayAlert("Sorry...", "Something went wrong. Try after sometime.", "OK");
                    // Navigation.PushAsync(new HomePage());
                }
            };


            var btnStack = new StackLayout {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    saveButton,cancelButton
				}
            };


            cancelButton.Clicked += (sender, e) =>
            {
                var NoteItem = (NotesDB)BindingContext;
                this.Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    noteEditor,btnStack
				}
            };

        }
        public void InsertData(string note, string date)
        {
            _notesDB.Note = note;
            _notesDB.Date = date;
            _notesQuery.InsertDetails(_notesDB);
        }
    }
}
