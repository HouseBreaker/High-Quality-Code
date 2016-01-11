namespace Exam.Models.Interfaces
{
	/// <summary>
	/// Interface for models which can attack.
	/// </summary>
	public interface IAttack
	{
		void Attack(Blob sourceBlob, Blob targetBlob);
	}
}