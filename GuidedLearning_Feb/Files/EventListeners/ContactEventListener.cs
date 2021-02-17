using Terrasoft.Core;
using Terrasoft.Core.Entities;
using Terrasoft.Core.Entities.Events;

namespace GuidedLearning_Feb.Files.EventListeners
{
	/// <summary>
	/// Listener for 'EntityName' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Contact")]
	class ContactEventListener : BaseEntityEventListener
	{
		#region Enum
		#endregion

		#region Delegates
		#endregion

		#region Constants
		#endregion

		#region Fields

		#region Fileds : Private
		#endregion

		#region Fileds : Protected
		#endregion

		#region Fileds : Internal
		#endregion

		#region Fileds : Protected Internal
		#endregion

		#region Fileds : Public
		#endregion

		#endregion

		#region Properties

		#region Properties : Private
		#endregion

		#region Properties : Protected
		#endregion

		#region Properties : Internal
		#endregion

		#region Properties : Protected Internal
		#endregion

		#region Properties : Public
		#endregion

		#endregion

		#region Events
		#endregion

		#region Methods

		#region Methods : Private

		#endregion

		#region Methods : Public

		#region Methods : Public : OnSave
		public override void OnSaving(object sender, EntityBeforeEventArgs e)
		{
			base.OnSaving(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;




			string newName = entity.GetTypedColumnValue<string>("Name");
			string oldName = entity.GetTypedOldColumnValue<string>("Name");
			

			EntityValidationMessage evm = new EntityValidationMessage
			{
				Column = entity.Schema.Columns.FindByName("Name"),
				MassageType = Terrasoft.Common.MessageType.Error,
				Text = "Error validation from clio"
			};





			entity.ValidationMessages.Add(evm);

			if(newName.Contains("Andrew "))
			{
				e.IsCanceled = true;
			}

			
			//entity.SetColumnValue("Notes", $"Old:{oldName} - New:{newName}");

		}
		public override void OnSaved(object sender, EntityAfterEventArgs e)
		{
			base.OnSaved(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;

			

		}
		#endregion

		#region Methods : Public : OnInsert
		public override void OnInserting(object sender, EntityBeforeEventArgs e)
		{
			base.OnInserting(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		public override void OnInserted(object sender, EntityAfterEventArgs e)
		{
			base.OnInserted(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		#endregion

		#region Methods : Public : OnUpdate
		public override void OnUpdating(object sender, EntityBeforeEventArgs e)
		{
			base.OnUpdating(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		public override void OnUpdated(object sender, EntityAfterEventArgs e)
		{
			base.OnUpdated(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		#endregion

		#region Methods : Public : OnDelete
		public override void OnDeleting(object sender, EntityBeforeEventArgs e)
		{
			base.OnDeleting(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
			e.IsCanceled = true;
		}
		public override void OnDeleted(object sender, EntityAfterEventArgs e)
		{
			base.OnDeleted(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		#endregion

		#endregion

		#endregion
	}
}
