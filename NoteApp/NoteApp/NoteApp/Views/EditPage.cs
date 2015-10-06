using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace NoteApp
{
    public class EditPage : ContentPage
    {
        public NotesQuery _notesQuery;
        public NotesDB _notesDB;
        private DateTime _DateTime;
        public string primary;
        public EditPage()
        {
            //SQL local database connection
            _notesDB = new NotesDB();
            _notesQuery = new NotesQuery();

            var idEntry = new Entry { };
            idEntry.SetBinding(Entry.TextProperty, "Id");
            idEntry.IsVisible = false;

            var noteEntry = new Entry { };
            noteEntry.SetBinding(Entry.TextProperty, "Note");


            var updateButton = new Button { Text = "UPDATE" };
            var deleteButton = new Button { Text = "DELETE" };
            var cancelButton = new Button { Text = "CANCEL" };

            //Update the selected data
            updateButton.Clicked += (object sender, EventArgs e) =>
            {
                try
                {
                    _DateTime = DateTime.Now;
                    UpdateData(idEntry.Text.ToString(), noteEntry.Text.ToString(), _DateTime.ToString());
                    DisplayAlert("Alert", "Updated Succesfully.", "OK");
                    Navigation.PushAsync(new HomePage());
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    DisplayAlert("Sorry...", "Something went wrong. Try after sometime.", "OK");
                }
            };

            //Delete selected data
            deleteButton.Clicked += (object sender, EventArgs e) =>
            {
                try
                {
                    int Id = Convert.ToInt32(idEntry.Text.ToString());
                    _notesQuery.DeleteNote(Id);
                    DisplayAlert("Alert", "Deleted Succesfully.", "OK");
                    Navigation.PushAsync(new HomePage());
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    DisplayAlert("Sorry...", "Something went wrong. Try after sometime.", "OK");
                }
            };


            cancelButton.Clicked += (sender, e) =>
            {
                var NoteItem = (NotesDB)BindingContext;
                this.Navigation.PopAsync();
            };
            
            var btnStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children ={
                    updateButton,deleteButton,cancelButton
                }
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions=LayoutOptions.FillAndExpand,
                Padding = new Thickness(20),
                Children = {
                    idEntry,noteEntry,btnStack

				}
            };

        }

        public void UpdateData(string num_id, string note, string date)
        {
            int Id = Convert.ToInt32(num_id);
            _notesDB.Id = Id;
            _notesDB.Note = note;
            _notesDB.Date = date;
        }
    }
}
