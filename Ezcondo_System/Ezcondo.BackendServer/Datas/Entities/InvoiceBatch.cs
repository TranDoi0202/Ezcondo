namespace Ezcondo.BackendServer.Datas.Entities
{
	public class InvoiceBatch
	{
		public Guid Id { get; set; }
		public string BillingMonth { get; set; }
		public Decimal TotalAmount { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ApprovedAt { get; set; }

		public Guid PreparedById { get; set; }
		public User PreparedBy { get; set; }
		public Guid? ApprovedById { get; set; }
		public User? ApprovedBy { get; set; }
		public Guid TenantId { get; set; }
		public Tenant Tenant { get; set; }
	}
}
