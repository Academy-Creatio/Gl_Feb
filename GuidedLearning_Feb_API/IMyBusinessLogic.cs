namespace GuidedLearning_Feb_API
{
	public interface IMyBusinessLogic
	{
		/// <summary>
		/// Adds numbers
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns>result of addition</returns>
		int Add(int a, int b);
		int Divide(int a, int b);
		int Multiply(int a, int b);
		int Subtract(int a, int b);
	}
}