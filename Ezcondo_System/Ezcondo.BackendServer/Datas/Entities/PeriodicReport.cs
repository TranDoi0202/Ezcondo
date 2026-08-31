using Ezcondo.BackendServer.Datas.Enums;

namespace Ezcondo.BackendServer.Datas.Entities
{
	public class PeriodicReport
	{
		public Guid Id { get; set; }
		public ReportPeriodEnum ReportPeriod { get; set; }
		public ReportTypeEnum ReportType { get; set; }
		public string? AttachedFileUrl { get; set; }
		public ReportStatusEnum Status { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ReviewedAt { get; set; }
		public Guid PreparedBy { get; set; }
		public User User { get; set; }
		public Guid TenantId { get; set; }
		public Tenant Tenant { get; set; }
	}
}
