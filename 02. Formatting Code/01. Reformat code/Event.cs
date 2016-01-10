namespace _01.Reformat_code
{
	using System;
	using System.Text;

	using Wintellect.PowerCollections;

	public class Event : IComparable
	{
		public Event(DateTime date, string title, string location)
		{
			Date = date;

			this.Title = title;
			Location = location;
		}

		public string Title { get; }

		public DateTime Date { get; set; }

		public string Location { get; set; }

		public int CompareTo(object obj)
		{
			var other = obj as Event;
			var byDate = Date.CompareTo(other.Date);
			var byTitle = this.Title.CompareTo(other.Title);

			var byLocation = Location.CompareTo(other.Location);

			if (byDate == 0)
			{
				return byTitle == 0 ? byLocation : byTitle;
			}

			return byDate;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
			sb.Append(" | " + this.Title);

			if (!string.IsNullOrEmpty(this.Location))
			{
				sb.Append(" | " + this.Location);
			}

			return sb.ToString();
		}
	}
}