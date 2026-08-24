using Ezcondo.BackendServer.Datas.Enums;

namespace Ezcondo.BackendServer.Datas.Entities
{
	public class Role
	{
		public Guid Id { get; set; }
		public RoleNameEnum RoleName { get; set; }
		public RoleScopeEnum RoleScope { get; set; }
		public short HierarchyLevel { get; set; }
		public bool IsDeleted { get; set; }
		public ICollection<RolePermission> RolePermissions { get; set; }
	}
}
