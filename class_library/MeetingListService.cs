using System;
using System.Text.Json;

namespace class_library
{
	public class MeetingListService
	{
		public static void ListMeetings()
		{
			Console.Clear();

			string MeetingFile = DbInitService.GetProjectDirectory() + "/meetings.json";
			string jsonText = File.ReadAllText(MeetingFile);
			List<MeetingModel> MeetingsList;


			try
            {
				MeetingsList = JsonSerializer.Deserialize<List<MeetingModel>>(jsonText);

				Console.WriteLine($"{MeetingsList.Count()} meeting(s) found:");
				foreach (MeetingModel meet in MeetingsList)
				{
					Console.WriteLine($"Name:	{meet.Name}		organiser: {meet.ResponsiblePerson}		date: {meet.StartDate}		Description:{meet.Description}");
				}
			}
            catch (JsonException)
            {
				Console.WriteLine($"Error in finding meetings.");
			}						
		}
	}
}

