namespace Exam.Engine.Database
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	using Models;

	public class BlobDatabase : IEnumerable<Blob>
	{
		public BlobDatabase()
		{
			this.Collection = new List<Blob>();
			this.EndTurnActions = delegate { };
		}
		
		public Action<Blob> EndTurnActions { get; set; }

		private ICollection<Blob> Collection { get; }

		public void Add(Blob blob)
		{
			this.Collection.Add(blob);
		}

		public IEnumerator<Blob> GetEnumerator()
		{
			return this.Collection.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}