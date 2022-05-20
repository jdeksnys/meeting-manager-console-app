using System;
using System.Text.Json;

namespace class_library
{
    public class RegisterService
    {
        public static void Register(bool FreshStart = false)
        {
            string UsersFile = DbInitService.GetProjectDirectory() + "/users.json";
            List<UserClass?> UsersList;

            Console.Clear();
            Console.WriteLine("Please register to access meetings:");

            Console.WriteLine("Create username:");
            string NewNameInput = Console.ReadLine();

            Console.WriteLine("Create password:");
            string NewPassInput = Console.ReadLine();


            if (FreshStart)
            {
                UsersList = new List<UserClass> { new UserClass(NewNameInput, NewPassInput) };
            }
            else
            {
                UsersList = UserService.GetUsers();
                UsersList.Add(new UserClass(NewNameInput, NewPassInput));
            }
            string jsonString = JsonSerializer.Serialize<List<UserClass>>(UsersList);
            File.WriteAllText(UsersFile, jsonString);

            LoginService.Login(NewNameInput, NewPassInput);
        }
    }
}

