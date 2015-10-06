using System;
using System.Collections.Generic;
using System.Linq;

using SQLite.Net;
using Xamarin.Forms;

namespace NoteApp
{
    public class NotesQuery
    {
        static object locker = new object();

        SQLiteConnection _sqlconnection;

        //Getting connection and creating table
        public NotesQuery()
        {
            _sqlconnection = DependencyService.Get<INotes>().GetConnection();
            _sqlconnection.CreateTable<NotesDB>();
        }

        //Insert Note
        public int InsertDetails(NotesDB notesDB)
        {
            lock (locker)
            {
                return _sqlconnection.Insert(notesDB);
            }
        }

        //Update Note
        public int UpdateDetails(NotesDB noteDB)
        {
            lock (locker)
            {
                return _sqlconnection.Update(noteDB);
            }
        }

        //Delete Note
        public int DeleteNote(int id)
        {
            lock (locker)
            {
                return _sqlconnection.Delete<NotesDB>(id);
            }
        }

        //Get all Notes
        public IEnumerable<NotesDB> GetAllNotes()
        {
            lock (locker)
            {
                return (from i in _sqlconnection.Table<NotesDB>() select i).ToList();
            }
        }


        //Get specific Note by ID
        public NotesDB GetNote(int id)
        {
            lock (locker)
            {
                return _sqlconnection.Table<NotesDB>().FirstOrDefault(t => t.Id == id);
            }
        }

        //Dispose
        public void Dispose()
        {
            _sqlconnection.Dispose();
        }

    }
}
