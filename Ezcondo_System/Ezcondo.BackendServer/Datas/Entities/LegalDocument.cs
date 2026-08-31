namespace Ezcondo.BackendServer.Datas.Entities
{
	public class LegalDocument
	{
		public Guid Id { get; set; }
		public string DocCategory { get; set; }
		public string FileUrl { get; set; }
		public DateTime? IssueDate { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool IsDeleted { get; set; }
		public Guid TenantId { get; set; }
		public Tenant Tenant { get; set; }
	}
}
