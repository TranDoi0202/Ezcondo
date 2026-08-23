using Ezcondo.BackendServer.Datas.Enums;
using Ezcondo.BackendServer.Datas.JsonbDataType;

namespace Ezcondo.BackendServer.Datas.Entities
{
	public class LicensePackage
	{
		public Guid Id { get; set; }
		public string PackageName { get; set; }
		public Decimal Price { get; set; }
		public BillingCycleEnum BillingCycle { get; set; }
		public ListOfFeature Feature { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }	
	}
}
