using Terrasoft.Core;

namespace GuidedLearning_Feb_API
{
	public interface IConfToClio
	{
		void PostMessage(UserConnection userConnection, string senderName, string messageText);
		void PostMessageToAll(string senderName, string messageText);
		T GetSysSettingValue<T>(UserConnection userConnection, string sysSettingName);
	}
}
