using System;
using System.IO;
using System.Text.Json;

namespace class_library;




public class DbInitService
{
    public static string GetProjectDirectory()
    {
        return new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.ToString();
    }



    public static void SetupDirectory()
    {
        string Dir = DbInitService.GetProjectDirectory();
        string AppSettings = Dir + "/appsettings.json";




        if (!File.Exists(AppSettings))
        {

            string Meetingsfile = Dir + "/meetings.json";
            string UsersFile = Dir + "/users.json";
            List<string> Directories = new List<string> { Meetingsfile, UsersFile };
            File.CreateText(AppSettings).Dispose();


            foreach (string dir in Directories)
            {
                if (!File.Exists(dir))
                {
                    File.CreateText(dir).Dispose();
                }
            }

            RegisterService.Register(true);

        }
        else
        {

            Console.WriteLine("Would you like to Register (r) or Log-in (l)? Please type in 'r'/'l':");
            string key = Console.ReadLine();

            if (key == "r")
            {
                RegisterService.Register();
            }
            if (key == "l")
            {
                LoginService.Login();
            }
            else
            {
                Console.Clear();
                SetupDirectory();
            }
        }
    }
}