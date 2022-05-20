using System;
using class_library;



namespace class_library
{
    public class LoginService
    {
        public static void Login(string NameInput = null, string PasswordInput = null)
        {

            if (NameInput == null || PasswordInput == null)
            {
                Console.WriteLine("Enter username:");
                NameInput = Console.ReadLine();

                Console.WriteLine("Enter password:");
                PasswordInput = Console.ReadLine();
            }



            string jsonPassword = "";
            try
            {
                List<UserClass> Users = UserService.GetUsers();
                jsonPassword = (from u in Users
                                where u.Username == NameInput
                                select u.Password).First().ToString();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error in finding user. Try again.");
                Login();
            }



            if (PasswordInput == jsonPassword)
            {
                UserService.LoggedInAs = NameInput;
                Console.Clear();
                Console.WriteLine($"Logged in as {UserService.LoggedInAs}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Password incorrect. Try again.");
                Login();
            }
        }


        public static void Logout()
        {
            UserService.LoggedInAs = null;
            Console.Clear();
            DbInitService.SetupDirectory();
        }
    }
}

