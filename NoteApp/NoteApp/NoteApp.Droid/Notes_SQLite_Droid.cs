using System;
using System.IO;
using Xamarin.Forms;
using NoteApp.Droid;

[assembly: Dependency(typeof(Notes_SQLite_Droid))]
namespace NoteApp.Droid
{
    public class Notes_SQLite_Droid : INotes
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var filename = "Notes.db";
            var documentspath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;
        }
    }
}