namespace Ezcondo.BackendServer.Datas.Entities
{
	public class ServiceConfig
	{
		public Guid Id { get; set; }
		public string ServiceCode { get; set; }
		public string ServiceName { get; set; }
		public string Unit { get; set; }
		public Decimal UnitPrice { get; set; }
		public Decimal VatRate { get; set; }
		public bool IsDeleted { get; set; }
		public Guid TenantId { get; set; }
		public Tenant Tenant { get; set; }
	}
}
