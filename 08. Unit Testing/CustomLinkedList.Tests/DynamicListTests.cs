// ReSharper disable InconsistentNaming
namespace CustomLinkedList.Tests
{
	using System;

	using CustomLinkedList;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class DynamicListTests
	{
		private DynamicList<int> list;

		[TestInitialize]
		public void Initialize()
		{
			this.list = new DynamicList<int>();

			this.list.Add(1);
			this.list.Add(2);
			this.list.Add(3);
		}

		[TestMethod]
		public void Indexer_SetValidIndex()
		{
			const int Expected = 10;

			this.list[1] = Expected;

			var actual = this.list[1];
			Assert.AreEqual(Expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Indexer_SetNegativeIndex_ShouldThrow()
		{
			this.list[-1] = 10;
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Indexer_SetInvalidIndex_ShouldThrow()
		{
			this.list[10] = 10;
		}

		[TestMethod]
		public void Indexer_GetExistingIndex()
		{
			var actual = this.list[1];
			const int Expected = 2;

			Assert.AreEqual(Expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Indexer_GetNegativeIndex_ShouldThrow()
		{
			var actual = this.list[-2];
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Indexer_GetInvalidIndex_ShouldThrow()
		{
			var actual = this.list[3];
		}

		[TestMethod]
		public void Add_ItemsToList()
		{
			this.list.Add(4);

			const int Expected = 4;
			var actual = this.list.Count;

			Assert.AreEqual(Expected, actual, "Elements are not being added properly.");
		}

		[TestMethod]
		public void Remove_ExistingElement()
		{
			this.list.Remove(2);

			const int Expected = 2;
			var actual = this.list.Count;

			Assert.AreEqual(Expected, actual);
		}

		[TestMethod]
		public void Remove_NonExistingElement()
		{
			const int NonExistingElement = 4;

			var actual = this.list.Remove(NonExistingElement);
			const int Expected = -1;
			Assert.AreEqual(Expected, actual);
		}

		[TestMethod]
		public void RemoveAt_ExistingIndex()
		{
			this.list.RemoveAt(2);

			var actual = this.list.Count;
			const int Expected = 2;

			Assert.AreEqual(Expected, actual);
		}

		[TestMethod]
		public void RemoveAt_EmptyOutList()
		{
			this.list.RemoveAt(2);
			this.list.RemoveAt(1);
			this.list.RemoveAt(0);

			const int Expected = 0;
			var actual = this.list.Count;

			Assert.AreEqual(Expected, actual);
		}

		[TestMethod]
		public void RemoveAt_RemoveLinkedListHead()
		{
			this.list.RemoveAt(0);

			const int Expected = 2;
			var actual = this.list[0];

			Assert.AreEqual(Expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void RemoveAt_NegativeIndex_ShouldThrow()
		{
			this.list.RemoveAt(-1);
		}

		[TestMethod]
		public void Count_CorrectUsage()
		{
			this.list.Add(4);

			const int Expected = 4;
			var actual = this.list.Count;

			Assert.AreEqual(Expected, actual);
		}

		[TestMethod]
		public void IndexOf_ExistingItem()
		{
			const int Expected = 2;
			var actual = this.list.IndexOf(3);

			Assert.AreEqual(Expected, actual);
		}

		[TestMethod]
		public void IndexOf_NonExistingItem()
		{
			const int Expected = -1;
			var actual = this.list.IndexOf(4);

			Assert.AreEqual(Expected, actual);
		}

		[TestMethod]
		public void Contains_DoesContain()
		{
			const bool Expected = true;
			var actual = this.list.Contains(2);

			Assert.AreEqual(Expected, actual);
		}

		[TestMethod]
		public void Contains_DoesNotContain()
		{
			const bool Expected = false;
			var actual = this.list.Contains(4);

			Assert.AreEqual(Expected, actual);
		}
	}
}