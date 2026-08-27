using Ezcondo.BackendServer.Datas.Enums;

namespace Ezcondo.BackendServer.Datas.Entities
{
	public class SystemIssue
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }
		public IssueSeverityEnum Severity { get; set; }
		public IssueStatusEnum Status { get; set; }
		public DateTime ReportedAt { get; set; }
		public DateTime? ResolvedAt { get; set; }
		public Guid? TenantId { get; set; }
		public Tenant? Tenant { get; set; }
	}
}
