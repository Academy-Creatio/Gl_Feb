using GuidedLearning_Feb_API;
using Terrasoft.Core.Factories;

namespace GuidedLearning_Feb
{
	[DefaultBinding(typeof(IMyBusinessLogic))]
	public class MyBusinessLogic : IMyBusinessLogic
	{
		public int Add(int a, int b)
		{
			IConfToClio conf = ClassFactory.Get<IConfToClio>();
			conf.PostMessageToAll(GetType().FullName, "Test Message from clio with interfaces");
			return a + b;
		}
		public int Subtract(int a, int b)
		{
			return a - b;
		}

		public int Multiply(int a, int b)
		{
			return a * b;
		}

		public int Divide(int a, int b)
		{
			return a / b;
		}
	}
}
