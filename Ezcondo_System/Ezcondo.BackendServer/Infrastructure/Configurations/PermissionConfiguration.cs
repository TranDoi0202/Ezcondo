using Ezcondo.BackendServer.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder)
		{
			builder.ToTable("Permissions");
			builder.HasKey("Id");

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uui()");

			builder.Property(x => x.PermissionCode)
				.HasColumnName("permission_code")
				.IsRequired();
			builder.HasIndex(x => x.PermissionCode)
				.IsUnique();

			builder.Property(x => x.Scope)
				.HasColumnName("scope")
				.IsRequired();

			builder.Property(x => x.Description)
				.HasColumnName("description");

			builder.Property(x => x.IsDeleted)
				.HasColumnName("is_deleted")
				.HasDefaultValue(false)
				.IsRequired();
		}
	}
}
