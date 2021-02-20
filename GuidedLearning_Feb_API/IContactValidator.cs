using System;
using Terrasoft.Core;

namespace GuidedLearning_Feb_API
{
	public interface IContactValidator
	{
		bool Validate(Guid ContacId, UserConnection UserConnection);
	}
}