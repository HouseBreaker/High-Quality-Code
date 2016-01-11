namespace Exam.Models.Interfaces
{
	/// <summary>
	/// Interface for generic Blob model.
	/// </summary>
	public interface IBlob
	{
		string Name { get; }

		int Health { get; set; }

		int Damage { get; set; }

		IBehavior BlobBehavior { get; }

		IAttack BlobAttack { get; }
	}
}
