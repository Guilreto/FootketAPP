
namespace FootketAPP.Helpers
{

    using SQLite.Net;
    using System.IO;
    using Models;

    public class Database
    {
        string path;
        SQLiteConnection conn;

        public Database()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalCacheFolder.Path,
                "FootketDB.sqlite");
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),
                path);

            //Creacion de Tablas
            conn.CreateTable<UserModel>();
        }

        public int Register(UserModel user)
        {
            int code = 1;
            try { 
            return conn.Insert(new UserModel()
            {
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email
            });
            } catch (SQLiteException ex)
            {
                code = -1;
            }
            return code;
        }

        public bool Login(string user, string password)
        {
            var query = conn.Table<UserModel>().
                Where(t => t.UserName == user && t.Password == password);
            if (query.Count() > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
