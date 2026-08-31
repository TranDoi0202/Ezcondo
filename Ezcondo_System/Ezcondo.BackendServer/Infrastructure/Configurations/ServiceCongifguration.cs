using Ezcondo.BackendServer.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class ServiceCongifguration : IEntityTypeConfiguration<ServiceConfig>
	{
		public void Configure(EntityTypeBuilder<ServiceConfig> b)
		{
			b.ToTable("Service_Configs");
			b.HasKey(x => x.Id);

			b.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			b.Property(x => x.ServiceCode)
				.HasColumnName("service_code")
				.HasMaxLength(100)
				.IsRequired();

			b.Property(x => x.ServiceName)
				.HasColumnName("service_name")
				.HasMaxLength(100)
				.IsRequired();

			b.Property(x => x.Unit)
				.HasColumnName("unit")
				.IsRequired();

			b.Property(x => x.UnitPrice)
				.HasColumnName("unit_price")
				.HasPrecision(15, 2)
				.IsRequired();

			b.Property(x => x.VatRate)
				.HasColumnName("vat_rate")
				.HasPrecision(15, 2)
				.IsRequired();

			b.Property(x => x.IsDeleted)
				.HasColumnName("is_deleted")
				.HasDefaultValue(false)
				.IsRequired();

			b.Property(x => x.TenantId)
				.HasColumnName("tenant_id")
				.IsRequired();
			b.HasOne(x => x.Tenant)
				.WithMany(tenant => tenant.ServiceConfigs)
				.HasForeignKey(x => x.TenantId)
				.OnDelete(DeleteBehavior.Restrict);

			b.HasIndex(x => new { x.TenantId, x.ServiceCode })
				.HasDatabaseName("uq_service_config_tenant_code")
				.IsUnique();
		}
	}
}
