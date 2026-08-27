using Ezcondo.BackendServer.Datas.Entities;
using Ezcondo.BackendServer.Datas.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class PlatformPaymentConfiguration : IEntityTypeConfiguration<PlatformPayment>
	{
		public void Configure(EntityTypeBuilder<PlatformPayment> builder)
		{
			builder.ToTable("Platform_Payments");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			builder.Property(x => x.Amount)
				.HasColumnName("amount")
				.HasPrecision(15, 2)
				.IsRequired();

			builder.Property(x => x.VnpTxnRef)
				.HasColumnName("vnp_txn_ref")
				.HasMaxLength(100);
			builder.HasIndex(x => x.VnpTxnRef)
				.IsUnique();

			builder.Property(x => x.VnpTransactionNo)
				.HasColumnName("vnp_transaction_no")
				.HasMaxLength(100);

			builder.Property(x => x.PaymentDate)
				.HasColumnName("payment_date");

			builder.Property(x => x.Status)
				.HasColumnName("status")
				.HasDefaultValue(PaymentStatusEnum.PENDING)
				.IsRequired();

			builder.Property(x => x.CreatedAt)
				.HasColumnName("created_at")
				.HasDefaultValueSql("now()")
				.IsRequired();

			builder.Property(x => x.TenantId)
				.HasColumnName("tenant_id")
				.IsRequired();
			builder.HasOne(x => x.Tenant)
				.WithMany(tenant => tenant.PlatformPayments)
				.HasForeignKey(x => x.TenantId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.TenantLicenseId)
				.HasColumnName("tenant_license_id")
				.IsRequired();
			builder.HasOne(x => x.TenantLicense)
				.WithMany(tenantlicense => tenantlicense.PlatformPayments)
				.HasForeignKey(x => x.TenantLicenseId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
