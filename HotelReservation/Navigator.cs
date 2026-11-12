using BusinessLogic;

namespace HotelReservation
{
    public static class Navigator
    {
        // Buksan ang bagong form at itago ang kasalukuyan
        public static void Open(Form current, Form next)
        {
            next.Show();
            current.Hide();
        }

        // Bumalik sa login screen
        public static void Logout(Form current)
        {
            Session.CurrentUser = null;

            frmLogIn login = (frmLogIn)Application.OpenForms["frmLogIn"];
            login.ClearFields();
            login.Show();
            current.Hide();
        }

        // Kapag pinindot ng user ang X, isara ang buong app
        public static void ExitIfUserClosed(FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}