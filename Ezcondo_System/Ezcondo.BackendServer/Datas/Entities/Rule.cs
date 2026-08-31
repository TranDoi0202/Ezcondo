namespace Ezcondo.BackendServer.Datas.Entities
{
	public class Rule
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public Guid TenantId { get; set; }
		public Tenant Tenant { get; set; }
	}
}
