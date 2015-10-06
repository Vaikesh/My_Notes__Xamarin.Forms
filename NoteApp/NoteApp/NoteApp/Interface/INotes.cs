using System;
using SQLite.Net;

namespace NoteApp
{
    public interface INotes
    {
        SQLiteConnection GetConnection();
    }
}
