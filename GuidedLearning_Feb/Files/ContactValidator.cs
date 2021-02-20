using GuidedLearning_Feb_API;
using System;
using System.Threading.Tasks;
using Terrasoft.Core;
using Terrasoft.Core.Entities;
using Terrasoft.Core.Factories;

namespace GuidedLearning_Feb.Files
{
	[DefaultBinding(typeof(IContactValidator))]
	public class ContactValidator : IContactValidator
	{
		UserConnection userConnection;
		public bool Validate(Guid ContacId, UserConnection UserConnection)
		{
			this.userConnection = UserConnection;
			ValidateAddress(ContacId);
			return false;
		}

		private void ValidateAddress(Guid ContacId)
		{
			const string tableName = "ContactAddress";
			EntitySchemaQuery esqResult = new EntitySchemaQuery(userConnection.EntitySchemaManager, tableName);
			esqResult.PrimaryQueryColumn.IsVisible = true;
			var filter = esqResult.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", ContacId);
			esqResult.Filters.Add(filter);

			var entities = esqResult.GetEntityCollection(userConnection);

			foreach(var entity in entities)
			{
				Entity contactAddress = userConnection.EntitySchemaManager.GetInstanceByName("ContactAddress").CreateEntity(userConnection);
				contactAddress.FetchFromDB(entity.PrimaryColumnValue);

				string cityName = contactAddress.GetTypedColumnValue<string>("CityName");
				string address = contactAddress.GetTypedColumnValue<string>("Address");
				Guid state = contactAddress.GetTypedColumnValue<Guid>("RegionId");
				if (
					contactAddress.GetTypedColumnValue<Guid>("CountryId") == new Guid("e0be1264-f36b-1410-fa98-00155d043204")
					&& state != Guid.Empty
					&& !string.IsNullOrEmpty(cityName) 
					&& !string.IsNullOrEmpty(address)
					)
				{
					var request = new USPS.USPS.ZipCodeLookupRequest(userConnection)
					{
						Address1 = address,
						Address2 = "",
						City = cityName,
						State = state
					};

					USPS.USPS.UspsAddress result = null;
					Task.Run(async () =>
					{
						result = await USPS.USPS.ZipCodeLookupAsync(request);

					}).Wait();

					if (string.IsNullOrEmpty(result?.ErrorDescription))
					{
						var zipCode = (!string.IsNullOrEmpty(result.Zip4)) ? $"{result.Zip5}-{result.Zip4}" : $"{result.Zip5}";
						contactAddress.SetColumnValue("Zip", zipCode);
						contactAddress.UpdateInDB();
					}
				}
			}
		}
	}
}
