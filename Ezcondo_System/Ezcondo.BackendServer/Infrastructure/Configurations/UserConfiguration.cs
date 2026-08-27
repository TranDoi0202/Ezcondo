using Ezcondo.BackendServer.Datas.Entities;
using Ezcondo.BackendServer.Datas.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("Users");
			builder.HasKey("Id");

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			builder.Property(x => x.Email)
				.HasColumnName("email")
				.HasMaxLength(255)
				.IsRequired();
			builder.HasIndex(x => x.Email)
				.IsUnique();

			builder.Property(x => x.PasswordHash)
				.HasColumnName("password_hash")
				.HasMaxLength(255)
				.IsRequired();

			builder.Property(x => x.AvatarUrl)
				.HasColumnName("avatar_url")
				.HasMaxLength(255);

			builder.Property(x => x.Status)
				.HasColumnName("status")
				.HasDefaultValue(UserStatusEnum.ACTIVE)
				.IsRequired();

			builder.Property(x => x.IsDeleted)
				.HasColumnName("is_deleted")
				.HasDefaultValue(false)
				.IsRequired();

			builder.Property(x => x.DeletedAt)
				.HasColumnName("deleted_at");

			builder.Property(x => x.CreatedAt)
				.HasColumnName("created_at")
				.HasDefaultValueSql("now()")
				.IsRequired();

			builder.Property(x => x.UpdatedAt)
				.HasColumnName("updated_at")
				.HasDefaultValueSql("now()")
				.IsRequired();

			builder.Property(x => x.RoleId)
				.HasColumnName("role_id")
				.IsRequired();
			builder.HasOne(x => x.Role)
				.WithMany()
				.HasForeignKey(x => x.RoleId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.TenantId)// null nếu role=admin
				.HasColumnName("tenant_id");
			builder.HasOne(x => x.Tenant)
				.WithMany(tenant => tenant.Users)
				.HasForeignKey(x => x.TenantId)
				.OnDelete(DeleteBehavior.Restrict);

			//tìm toàn bộ users trong 1 tenant
			builder.HasIndex(x => x.TenantId)
				.HasDatabaseName("idx_users_tenant_id");

			//tìm user theo role
			builder.HasIndex(x => x.RoleId)
				.HasDatabaseName("idx_users_role_id");
		}
	}
}
