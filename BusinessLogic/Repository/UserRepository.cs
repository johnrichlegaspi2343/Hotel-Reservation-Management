using Model;

namespace BusinessLogic.Repository
{
    public class UserRepository
    {
        public User? GetByUsername(string username)
        {
            using (var db = new AppDBContext())
            {
                return db.Users.FirstOrDefault(u => u.Username == username);
            }
        }
    }
}