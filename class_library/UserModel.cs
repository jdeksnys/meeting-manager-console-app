using System;



namespace class_library
{
	public class UserClass
	{
		public string Username { get; set; }
		public string Password { get; set; }

		public UserClass(string Username, string Password)
		{
			this.Username = Username;
			this.Password = Password;
		}
	}
}

