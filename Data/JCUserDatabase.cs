using SQLite;
using JohanCarrasco_Catalogo_P3.Models;

namespace JohanCarrasco_Catalogo_P3.Data
{
    public class JCUserDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;
        public JCUserDatabase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<User>();
        }
        public int AddNewUser(User user)
        {
            Init();
            if (user.Id != 0)
            {
                return conn.Update(user);
            }
            else
            {
                return conn.Insert(user);
            }
        }

        public List<User> GetAllUsers()
        {
            Init();
            List<User> users = conn.Table<User>().ToList();
            return users;
        }

        public int DeleteUser(User item)
        {
            Init();
            return conn.Delete(item);
        }
    }
}
