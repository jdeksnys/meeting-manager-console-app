using System;
using class_library;



namespace jonas_deksnys_task
{
    public class ActionProcessor
    {
        public static void ProcessRequest()
        {
            List<string> Commands = new List<string>() { "Available commands:", "list   - list all meetings", "new  - create new meeting", "delete   - delete meeting", "logout      - log out of current user" };

            Console.WriteLine();
            foreach (string text in Commands)
            {
                Console.WriteLine($"{text}");
            }


            Console.WriteLine("\nPlease enter command:");
            string action = Console.ReadLine();

            switch (action)
            {
                case "list": MeetingListService.ListMeetings(); break;
                case "new": MeetingCreateService.CreateMeeting(); break;
                case "delete": MeetingDeleteService.DeleteMeeting(); break;
                case "logout": LoginService.Logout(); break;
                default: Console.Clear(); break;
            };
            //    case "addperson": AddPerson();
            //    case "removerperson": RemovePerson();            
            //}

            ProcessRequest();
        }
    }
}

