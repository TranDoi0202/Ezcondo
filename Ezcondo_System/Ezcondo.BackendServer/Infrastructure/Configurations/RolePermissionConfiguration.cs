using Ezcondo.BackendServer.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
	{
		public void Configure(EntityTypeBuilder<RolePermission> builder)
		{
			builder.ToTable("Role_Permission");
			builder.HasKey(x => new { x.RoleId, x.PermissionId });

			builder.Property(x => x.RoleId)
				.HasColumnName("role_id");
			builder.HasOne(x => x.Role)
				.WithMany(r => r.RolePermissions)
				.HasForeignKey(x => x.RoleId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(x => x.PermissionId)
				.HasColumnName("permission_id");
			builder.HasOne(x => x.Permission)
				.WithMany(p => p.RolePermissions)
				.HasForeignKey(x => x.PermissionId)
				.OnDelete(DeleteBehavior.Cascade);

		}
	}
}
