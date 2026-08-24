using Ezcondo.BackendServer.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.ToTable("Roles");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			builder.Property(x => x.RoleName)
				.HasColumnName("role_name")
				.IsRequired();
			builder.HasIndex(x => x.RoleName)
				.IsUnique();

			builder.Property(x => x.RoleScope)
				.HasColumnName("role_scope")
				.IsRequired();

			builder.Property(x => x.HierarchyLevel)
				.HasColumnName("hierarchy_level")
				.IsRequired();//

			builder.Property(x => x.IsDeleted)
				.HasColumnName("is_deleted")
				.HasDefaultValue(false)
				.IsRequired();

			builder.HasCheckConstraint("chk_role_hierarchy_level"
				, @"hierarchy_level between 0 and 3");

			builder.HasCheckConstraint("chk_role_scope_consistency",
				@"(role_scope = 'PLATFORM' and role_name = 'ADMIN') or 
					(role_scope = 'TENANT' and role_name <> 'ADMIN')");
		}
	}
}
