using System;
using System.Reflection;
using System.Text.Json;



namespace class_library
{
	public class MeetingCreateService
	{
		public static void CreateMeeting()
		{
			Console.Clear();

			Dictionary<string, dynamic> PropertyValues = DeclareProperties();

			PropertyValues = CollectProperties(PropertyValues);

			MeetingModel TheMeeting = SetProperties(PropertyValues);

			SerializeJson(TheMeeting);



			Console.Clear();
			Console.WriteLine("Meeting saved");
			Console.WriteLine();
		}



		public static Dictionary<string, dynamic> DeclareProperties()
		{
			Dictionary<string, dynamic> PropertyValues = new Dictionary<string, dynamic>()
			{
				{"Name",null},
				{"ResponsiblePerson",null},
				{"Description",null},
				{"Category",null},
				{"Type",null},
				{"StartDate",null},
				{"EndDate",null},
				{"Participants",null}
			};

			List<string> Categories = new List<string> { "CodeMonkey", "Hub", "Short", "TeamBuilding" };
			List<string> Types = new List<string> { "Live", "InPerson" };

			return PropertyValues;
		}



		public static Dictionary<string, dynamic> CollectProperties(Dictionary<string, dynamic> _dictionary)
		{
			foreach (KeyValuePair<string, dynamic> kvp in _dictionary)
			{
				if (kvp.Key.Equals("ResponsiblePerson"))
				{
					_dictionary[kvp.Key] = UserService.LoggedInAs;
					continue;
				}

				else if (kvp.Key.Equals("Type"))
				{
					Console.WriteLine($"Specify {kvp.Key} for meeting (1 - Live, 2 - InPerson):");
					string input = Console.ReadLine();
					switch (input)
					{
						case "1": _dictionary[kvp.Key] = "Live"; break;
						case "2": _dictionary[kvp.Key] = "InPerson"; break;
					}
					continue;
				}

				else if (kvp.Key.Equals("Category"))
				{
					Console.WriteLine($"Specify {kvp.Key} for meeting (1 - CodeMonkey, 2 - Hub, 3 - Short, 4 - TeamBuilding):");
					string input = Console.ReadLine();

					switch (input)
					{
						case "1": _dictionary[kvp.Key] = "CodeMonkey"; break;
						case "2": _dictionary[kvp.Key] = "Hub"; break;
						case "3": _dictionary[kvp.Key] = "Short"; break;
						case "4": _dictionary[kvp.Key] = "TeamBuilding"; break;
					}
					continue;
				}

				else
				{
					Console.WriteLine($"Specify {kvp.Key} for meeting:");
					_dictionary[kvp.Key] = Console.ReadLine();
				}
			}

			return _dictionary;
		}



		public static MeetingModel SetProperties(Dictionary<string, dynamic> _dictionary)
		{
			MeetingModel Meeting = new MeetingModel();
			foreach (KeyValuePair<string, dynamic> kvp in _dictionary)
			{
				PropertyInfo MeetingInstance = typeof(MeetingModel).GetProperty(kvp.Key);
				MeetingInstance.SetValue(Meeting, kvp.Value);
			}

			return Meeting;
		}



		public static void SerializeJson(MeetingModel _meeting)
		{
			string MeetingsFile = DbInitService.GetProjectDirectory() + "/meetings.json";
			string? FileText = File.ReadAllText(MeetingsFile);
			List<MeetingModel> MeetingsList;
			string jsonString;

			if (FileText == "")
			{
				MeetingsList = new List<MeetingModel>() { _meeting };
				jsonString = JsonSerializer.Serialize<List<MeetingModel>>(MeetingsList);
				File.WriteAllText(MeetingsFile, jsonString);
			}
			else
			{
				MeetingsList = JsonSerializer.Deserialize<List<MeetingModel>>(FileText);
				MeetingsList.Add(_meeting);
				jsonString = JsonSerializer.Serialize<List<MeetingModel>>(MeetingsList);
				File.WriteAllText(MeetingsFile, jsonString);
			}
		}
	}
}

