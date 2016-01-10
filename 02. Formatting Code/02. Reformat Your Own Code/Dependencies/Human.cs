namespace _02.Reformat_Your_Own_Code.Dependencies
{
	using System;

	public abstract class Human
	{
		private const int PrintPadding = 20;
		private string firstName, lastName;

		protected Human(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public string FirstName
		{
			get
			{
				return this.firstName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("firstName", "Name cannot be empty.");
				}
				this.firstName = value;
			}
		}

		public string LastName
		{
			get
			{
				return this.lastName;
			}
			protected set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("lastName", "Name cannot be empty.");
				}
				this.lastName = value;
			}
		}

		public override string ToString()
		{
			return $"Name: {this.FirstName} {this.LastName}".PadRight(PrintPadding);
		}
	}
}
