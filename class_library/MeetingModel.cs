using System;


namespace class_library
{
	public class MeetingModel
	{
		public string Name { get; set; }
		public string ResponsiblePerson { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public string Type { get; set; }
		public string StartDate { get; set; } //datetime
		public string EndDate { get; set; } //datetime
		public string Participants { get; set; } //List<string>
	}
}

