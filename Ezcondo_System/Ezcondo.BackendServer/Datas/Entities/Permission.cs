using Ezcondo.BackendServer.Datas.Enums;

namespace Ezcondo.BackendServer.Datas.Entities
{
	public class Permission
	{
		public Guid Id { get; set; }
		public string PermissionCode { get; set; }
		public RoleScopeEnum Scope { get; set; }
		public string? Description { get; set; }
		public bool IsDeleted { get; set; }
		public ICollection<RolePermission> RolePermissions { get; set; }
	}
}
