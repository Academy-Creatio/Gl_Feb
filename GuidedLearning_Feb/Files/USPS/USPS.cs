using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GuidedLearning_Feb.USPS
{
	public partial class USPS
	{
		const string BaseUrl = "https://secure.shippingapis.com/ShippingAPI.dll?API=";
		public static async Task<UspsAddress> ZipCodeLookupAsync(ZipCodeLookupRequest request)
		{
			const string API = "ZipCodeLookup";
			string Url = string.Format("{0}{1}&XML={2}", BaseUrl, API, request.XML);

			string Address1 = "";
			string Address2 = "";
			string City = "";
			string State = "";
			string Zip4 = "";
			string Zip5 = "";
			string errorDescription = "";

			try
			{
				WebRequest wr = WebRequest.Create(Url);
				wr.Timeout = 5000;
				WebResponse response = await wr.GetResponseAsync();

				Stream dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);
				string responseFromServer = reader.ReadToEnd();
				reader.Close();
				dataStream.Close();
				response.Close();

				XDocument ZipCodeLookupResponse = XDocument.Parse(responseFromServer);
				if (ZipCodeLookupResponse.Elements().FirstOrDefault().Name == "Error")
				{
					errorDescription = ZipCodeLookupResponse.Element("Error").Element("Description").Value;
				}
				else
				{
					if (ZipCodeLookupResponse.Element("ZipCodeLookupResponse").Element("Address").HasElements)
					{
						IEnumerable<XElement> collection = ZipCodeLookupResponse.Element("ZipCodeLookupResponse").Element("Address").Elements();
						foreach (XElement x in collection)
						{
							if (x.Name.LocalName == "Address1")
							{
								Address1 = x.Value;
							}
							else if (x.Name.LocalName == "Address2")
							{
								Address2 = x.Value;
							}
							else if (x.Name.LocalName == "City")
							{
								City = x.Value;
							}
							else if (x.Name.LocalName == "State")
							{
								State = x.Value;
							}
							else if (x.Name.LocalName == "Zip4")
							{
								Zip4 = x.Value;
							}
							else if (x.Name.LocalName == "Zip5")
							{
								Zip5 = x.Value;
							}
							else if (x.Name == "Error" && x.HasElements)
							{
								foreach (XElement error in x.Elements())
								{
									if (error.Name == "Description")
									{
										errorDescription = error.Value;
									}
								}
							}
						}
					}
				}

			}
			catch (Exception ex)
			{
				errorDescription = ex.Message;
			}
			UspsAddress result = new UspsAddress
			{
				Name = request.Name,
				Address1 = Address1,
				Address2 = Address2,
				City = City,
				State = State,
				Zip4 = Zip4,
				Zip5 = Zip5,
				ErrorDescription = errorDescription
			};
			return result;
		}
	}
}
