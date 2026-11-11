using BusinessLogic.Repository;
using Model;

namespace BusinessLogic.Controller
{
    public class UserController
    {
        private UserRepository userRepo = new UserRepository();

        public User Login(string username, string password)
        {
            if (username.Trim() == "" || password == "")
            {
                throw new Exception("Please enter your username and password.");
            }

            User? user = userRepo.GetByUsername(username.Trim());

            if (user == null || user.Password != password)
            {
                throw new Exception("Invalid username or password.");
            }

            Session.CurrentUser = user;
            return user;
        }

        public void Logout()
        {
            Session.CurrentUser = null;
        }
    }
}