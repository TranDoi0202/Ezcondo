using Ezcondo.BackendServer.Datas.Enums;

namespace Ezcondo.BackendServer.Datas.Entities
{
	public class Tenant
	{
		public Guid Id { get; set; }
		public string TenantName { get; set; }
		public string ContactName { get; set; }
		public string ContactPhone { get; set; }
		public string ContactEmail { get; set; }
		public string Address { get; set; }
		public TenantStatusEnum Status  { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public ICollection<TenantLicense> Licenses {  get; set; }
		public ICollection<User> Users { get; set; }
		public ICollection<PlatformPayment> PlatformPayments {  get; set; }
		public ICollection<SystemIssue> SystemIssues {  get; set; }
		public ICollection<SupportTicket> SupportTickets {  get; set; }
		public ICollection<PeriodicReport> PeriodicReport { get; set; }
		public ICollection<LegalDocument> LegalDocuments { get; set; }
		public ICollection<Rule> Rules { get; set; }
		public ICollection<ServiceConfig> ServiceConfigs { get; set; }
		public ICollection<InvoiceBatch> InvoiceBatches {  get; set; }
	}
}
