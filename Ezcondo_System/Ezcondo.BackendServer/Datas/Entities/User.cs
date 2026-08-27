using Ezcondo.BackendServer.Datas.Enums;

namespace Ezcondo.BackendServer.Datas.Entities
{
	public class User
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string? AvatarUrl { get; set; }
		public UserStatusEnum Status { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public Guid RoleId { get; set; }
		public Role Role { get; set; }
		public Guid TenantId { get; set; }
		public Tenant? Tenant { get; set; }
		public ICollection<AdminAuthLog> AdminAuthLogs { get; set; }
		public ICollection<SupportTicket> SupportTickets { get; set; }
	}
}
