using System;
using System.Text.Json;

namespace class_library
{
	public class MeetingDeleteService
	{
		public static void DeleteMeeting()
		{
			Console.Clear();
			Console.WriteLine("Enter name of meeting to delete:");
			string _name = Console.ReadLine();


			string MeetingFile = DbInitService.GetProjectDirectory() + "/meetings.json";
			string jsonString = File.ReadAllText(MeetingFile);
			List<MeetingModel> MeetingsList = JsonSerializer.Deserialize<List<MeetingModel>>(jsonString);
			MeetingModel MeetToDelete = null;


			try
			{
				MeetToDelete = (from m in MeetingsList
								where m.Name == _name
								select m).First();
			}
			catch (InvalidOperationException)
			{
				Console.WriteLine("Error in finding meeting.");
			}

			if (MeetToDelete != null)
			{
				if (MeetToDelete.ResponsiblePerson == UserService.LoggedInAs)
				{
					MeetingsList.Remove(MeetToDelete);
					jsonString = JsonSerializer.Serialize<List<MeetingModel>>(MeetingsList);
					File.WriteAllText(MeetingFile, jsonString);

					Console.Clear();
					Console.WriteLine("Meeting deleted.");
				}
				else
				{
					Console.Clear();
					Console.WriteLine($"Cannot delete - you are not responsible for the meeting \"{MeetToDelete.Name}\"");
				}
			}
		}
	}
}

