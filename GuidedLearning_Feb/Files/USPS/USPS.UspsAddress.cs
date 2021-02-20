using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidedLearning_Feb.USPS
{
	public partial class USPS
	{
		public class UspsAddress
		{
			public string Name { get; set; }
			public string Address1 { get; set; }
			public string Address2 { get; set; }
			public string City { get; set; }
			public string State { get; set; }
			public string Zip4 { get; set; }
			public string Zip5 { get; set; }
			public string ErrorDescription { get; set; }
		}
	}
}
