using GuidedLearning_Feb_API;
using Terrasoft.Configuration;
using Terrasoft.Core;
using Terrasoft.Core.Factories;

namespace GuidedLearnng_Feb
{

	[DefaultBinding(typeof(IConfToClio))]
	public class ConfToClio: IConfToClio
	{
		public void PostMessage(UserConnection userConnection, string senderName, string messageText)
		{
			MsgChannelUtilities.PostMessage(userConnection, senderName, messageText);
		}
		
		public void PostMessageToAll(string senderName, string messageText)
		{
			MsgChannelUtilities.PostMessageToAll(senderName, messageText);
		}

		public T GetSysSettingValue<T>(UserConnection userConnection, string sysSettingName)
		{
			return Terrasoft.Core.Configuration.SysSettings.GetValue<T>(userConnection, sysSettingName, default);
		}

	}
} 