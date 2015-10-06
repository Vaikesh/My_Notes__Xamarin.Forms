using System;
using SQLite.Net.Attributes;

namespace NoteApp
{
    public class NotesDB
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }

        public string Date { get; set; }

        public NotesDB()
        {
        }
    }
}
