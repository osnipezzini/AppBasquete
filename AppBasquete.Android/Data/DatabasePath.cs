using AppBasquete.Data;
using AppBasquete.Droid.Data;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace AppBasquete.Droid.Data
{
    public class DatabasePath : IDBPath
    {
        public DatabasePath()
        { }
        public string GetDbPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "AppBasquete.db");
        }
    }
}