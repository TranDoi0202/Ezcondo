using Ezcondo.BackendServer.Datas.Enums;

namespace Ezcondo.BackendServer.Datas.Entities
{
	public class SupportTicket //Yêu cầu hỗ trợ của tenant
	{
		public Guid Id { get; set; }
		public string Description { get; set; }
		public TicketStatusEnum Status { get; set; }
		public TicketCategoryEnum IssueCategory { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ResolvedAt { get; set; }
		public Guid CreatedBy { get; set; }
		public User UserCreated { get; set; }
		public Guid TenantId { get; set; }
		public Tenant Tenant { get; set; }
	}
}
