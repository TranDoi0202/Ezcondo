using Ezcondo.BackendServer.Datas.Entities;
using Ezcondo.BackendServer.Datas.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
	{
		public void Configure(EntityTypeBuilder<Tenant> builder)
		{
			builder.ToTable("Tenant");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			builder.Property(x => x.TenantName)
				.HasColumnName("tenant_name")
				.HasMaxLength(255)
				.IsRequired();//== not null

			builder.Property(x => x.ContactName)
				.HasColumnName("contact_name")
				.HasMaxLength(255)
				.IsRequired();

			builder.Property(x => x.ContactPhone)
				.HasColumnName("contact_phone")
				.HasMaxLength(20)
				.IsRequired();
			builder.HasIndex(x => x.ContactPhone).IsUnique();//unique

			builder.Property(x => x.Address)
				.HasColumnName("address")
				.IsRequired();

			builder.Property(x => x.Status)
				.HasColumnName("status")
				.HasDefaultValue(TenantStatusEnum.ACTIVE)
				.IsRequired();

			builder.Property(x => x.IsDeleted)
				.HasColumnName("is_deleted")
				.HasDefaultValue(false);

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

			//bỏ qua data đã xóa
			builder.HasQueryFilter(x => !x.IsDeleted);
		}
	}
}
