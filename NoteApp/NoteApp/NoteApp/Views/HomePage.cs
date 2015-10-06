using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Text;

using Xamarin.Forms;

namespace NoteApp
{
    public class HomePage : ContentPage
    {
        ListView lstView;
        public NotesQuery _notesQuery;
        public NotesDB _notesDB;
        public HomePage()
        {
            //SQL local database connection
            _notesDB = new NotesDB();
            _notesQuery = new NotesQuery();

            var createBtn = new Button { Text = "Create note" };
            lstView = new ListView { };
            lstView.ItemTemplate = new DataTemplate(typeof(NoteItemCell));
            
            lstView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                {
                    return; // ensures we ignore this handler when the selection is just being cleared 
                }
                var detail_Item = (NotesDB)e.SelectedItem;
                var detailPage = new EditPage();
                detailPage.BindingContext = detail_Item;
                await Navigation.PushAsync(detailPage);
                ((ListView)sender).SelectedItem = null;   // clears the 'selected' background
            };

            createBtn.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushAsync(new CreatePage());
            };

            var mainlayout = new StackLayout { };
            mainlayout.Children.Add(createBtn);
            mainlayout.Children.Add(lstView);


            Content = mainlayout;
        }

        protected override void OnAppearing()
        {
            lstView.ItemsSource = _notesQuery.GetAllNotes();   //load the items to listview
            base.OnAppearing();
        }
    }
}
