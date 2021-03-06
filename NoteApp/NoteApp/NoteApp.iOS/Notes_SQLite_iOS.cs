using System;
using System.IO;
using Xamarin.Forms;
using NoteApp.iOS;

[assembly: Dependency(typeof(Notes_SQLite_iOS))]
namespace NoteApp.iOS
{
    public class Notes_SQLite_iOS : INotes
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "Notes.db";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
    }
}