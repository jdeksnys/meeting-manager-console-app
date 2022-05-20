using System;
using System.Text.Json;


namespace class_library
{
    public class UserService
    {
        //public class TempAuthenticationClass
        //{
        //    public string LoggedInAs;
        //}
        public static string LoggedInAs { get; set; }


        public static List<UserClass> GetUsers()
        {
            string UsersFile = DbInitService.GetProjectDirectory() + "/users.json";

            string jsonText = File.ReadAllText(UsersFile);
            List<UserClass> UserList = JsonSerializer.Deserialize<List<UserClass>>(jsonText);
            return UserList;
        }
    }
}

