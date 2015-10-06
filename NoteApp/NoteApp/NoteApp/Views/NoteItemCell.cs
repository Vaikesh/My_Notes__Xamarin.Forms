using System;
using Xamarin.Forms;

namespace NoteApp
{
    public class NoteItemCell : ViewCell
    {
        public NoteItemCell()
        {
            var IdLabel = new Label
            {
                YAlign = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            IdLabel.SetBinding(Label.TextProperty, "Id");

            var DateLabel = new Label
            {
                YAlign = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            DateLabel.SetBinding(Label.TextProperty, "Date");

            var NoteLabel = new Label
            {
                YAlign = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            NoteLabel.SetBinding(Label.TextProperty, "Note");

            var line = new Label
            {
                Text= " ",
                BackgroundColor=Color.White,
                HeightRequest=2,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var layout = new StackLayout
            {
                Padding = new Thickness(20, 0, 20, 0),
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { /*IdLabel,*/ DateLabel, NoteLabel,line }
            };
            View = layout;
        }
    }
}
