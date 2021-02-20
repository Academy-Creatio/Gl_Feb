using GuidedLearning_Feb_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Terrasoft.Core;

namespace GuidedLearning_Feb.USPS
{
	public partial class USPS
	{
		public class ZipCodeLookupRequest
		{
			public ZipCodeLookupRequest(UserConnection userConnection)
			{

				IConfToClio conf = Terrasoft.Core.Factories.ClassFactory.Get<IConfToClio>();
				Username = conf.GetSysSettingValue<string>(userConnection, "USPS_Username");
			}

			public string Name { get; set; }
			public string Address1 { get; set; }
			public string Address2 { get; set; }
			public string City { get; set; }
			public Guid State { get; set;}

			private readonly string Username;
			public string XML
			{
				get
				{
					XElement root = new XElement("ZipCodeLookupRequest",
						new XAttribute("USERID", Username),
						new XElement("Address",
							new XElement("Address1", Address1),
							new XElement("Address2", Address2),
							new XElement("City", City),
							new XElement("State", GetStateCode(State))
						)
					);
					return root.ToString();
				}
			}
			private string GetStateCode(Guid creatioState)
			{
				Dictionary<Guid, string> UsaStates = new Dictionary<Guid, string>
				{
					{new Guid("dcaf4282-f36b-1410-0299-00155d043204"), "MI"},
					{new Guid("f6af2204-f46b-1410-fc98-00155d043204"), "AL"},
					{new Guid("d8af122a-f46b-1410-fc98-00155d043204"), "CA"},
					{new Guid("99ae3e40-f36b-1410-fd98-00155d043204"), "DC"},
					{new Guid("d8bf2e4c-f36b-1410-fd98-00155d043204"), "FL"},
					{new Guid("f8be125e-f36b-1410-fd98-00155d043204"), "GA"},
					{new Guid("00b03270-f36b-1410-fd98-00155d043204"), "NY"},
					{new Guid("beae2282-f36b-1410-fd98-00155d043204"), "TX"},
					{new Guid("f6bf4290-f36b-1410-fd98-00155d043204"), "WA"},
					{new Guid("96bfc3d8-56a4-4a6c-8281-0e87bda8daae"), "KY"},
					{new Guid("6f58e2a4-6eb0-4450-8dbe-13f0a9541715"), "TN"},
					{new Guid("b10993b0-e355-4f12-80c2-141e49f3106c"), "SD"},
					{new Guid("b75b85a8-8259-4393-ab78-1c0f068ae90b"), "WY"},
					{new Guid("96ab9ca7-1965-4426-acfe-272f1e7a4080"), "IL"},
					{new Guid("df425d32-d849-4010-8885-27e8b4b778d0"), "LA"},
					{new Guid("b72ae6a2-7070-4c97-94c0-34b5765edbd0"), "DE"},
					{new Guid("1782e78d-2f18-498b-b6c7-386215b91d66"), "ID"},
					{new Guid("de6847f5-a04f-4c89-890a-3c8083cd9083"), "IA"},
					{new Guid("2eff6fed-ee4c-4799-a184-3f480cae3943"), "AR"},
					{new Guid("896e1da9-a276-47fc-98a6-421b98d3a787"), "NM"},
					{new Guid("872cce62-feba-44d1-98ec-426b627dcb96"), "MT"},
					{new Guid("7e091cae-1d81-4ee0-ae17-4436fcbb93b4"), "MN"},
					{new Guid("ccc3118e-6044-4ce5-ad74-4ea321a0fea6"), "VT"},
					{new Guid("4055656f-b979-4e5f-a91a-52842961c524"), "MD"},
					{new Guid("658acfe7-09ae-4747-b1b3-541e2dfa1b9e"), "MA"},
					{new Guid("7eae84c7-b960-47db-ae59-5fd3bc0b9a73"), "MO"},
					{new Guid("977e3cdc-d018-458a-9b73-67474ebc9f62"), "OR"},
					{new Guid("fa346ca3-244d-4c54-8e8a-6afadc9e0f52"), "NJ"},
					{new Guid("c320d949-3238-428f-bf0c-721a20c80930"), "CO"},
					{new Guid("e4761e8f-6890-4438-85c5-75547f22a553"), "AZ"},
					{new Guid("0e225f8c-5a50-4b0b-a18b-7b2f85367253"), "CT"},
					{new Guid("529a94ff-eff0-4be1-a6a0-81d7ca6eed53"), "NC"},
					{new Guid("73110658-0fe6-41e7-8e10-8a3e50eff097"), "ME"},
					{new Guid("e1afda65-714d-4040-a3ec-8c7944bd4cbd"), "NH"},
					{new Guid("81711be5-eb8d-4e19-8889-8e310e2744a1"), "ND"},
					{new Guid("38ce8349-107a-471f-967c-8fe3443894f6"), "RI"},
					{new Guid("ef25ff12-f3da-4a18-b658-9c473bdeca69"), "SC"},
					{new Guid("4e6c661e-a401-4de8-bd91-a4366fdc4d89"), "PA"},
					{new Guid("bf89ee26-9e2b-42c9-a3cd-aca53bcbb736"), "KS"},
					{new Guid("6b6b4922-fab0-4e22-abe7-bc31dafe5f56"), "IN"},
					{new Guid("3fd1d7f6-f46c-45bb-97cd-bc4fc41d3614"), "AK"},
					{new Guid("e6fdc56d-33b1-4c02-b17a-bec59adb9462"), "WV"},
					{new Guid("1eb55c1c-3046-44f1-91ab-c158241f5fdb"), "UT"},
					{new Guid("eaf513b2-1914-41ea-9f69-c17238496e45"), "VA"},
					{new Guid("7d9d18ea-72ea-4870-bb43-c7ecc73584b8"), "MS"},
					{new Guid("83b70eb5-246c-47e8-9777-d9d1e112ef11"), "NV"},
					{new Guid("1add246e-d83e-44b0-bfe7-de70fed2dcd9"), "OK"},
					{new Guid("3bad0137-82b6-41bd-8c3c-ee4bcacf6164"), "WI"},
					{new Guid("366d0be2-e83a-4fa2-a5b5-f437bff52d73"), "OH"},
					{new Guid("9136b502-6142-4e57-91ad-f71e4dc975a3"), "NE"},
					{new Guid("f9c816b2-1a82-4101-be0f-f90c0ed26521"), "HI"}
				};
				return UsaStates[creatioState];
			}

		}
	}
}
