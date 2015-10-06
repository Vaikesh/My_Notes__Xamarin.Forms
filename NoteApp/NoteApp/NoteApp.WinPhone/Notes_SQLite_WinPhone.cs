using System;
using System.IO;
using Xamarin.Forms;
using NoteApp.WinPhone;
using Windows.Storage;

[assembly: Dependency(typeof(Notes_SQLite_WinPhone))]
namespace NoteApp.WinPhone
{
    public class Notes_SQLite_WinPhone : INotes
    {
        public Notes_SQLite_WinPhone()
        {
        }
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var filename = "Notes.db";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);

            var platfrom = new SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8();
            var connection = new SQLite.Net.SQLiteConnection(platfrom, path);
            return connection;
        }
    }
}
