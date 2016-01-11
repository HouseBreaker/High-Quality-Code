namespace Exam.Models.Attacks
{
	using Exam.Models.Interfaces;

	public class PutridFart : IAttack
	{
		public void Attack(Blob sourceBlob, Blob targetBlob)
		{
			sourceBlob.Health -= targetBlob.Damage;
		}
	}
}