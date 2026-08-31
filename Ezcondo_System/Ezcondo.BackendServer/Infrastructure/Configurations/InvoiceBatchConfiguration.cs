using Ezcondo.BackendServer.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class InvoiceBatchConfiguration : IEntityTypeConfiguration<InvoiceBatch>
	{
		public void Configure(EntityTypeBuilder<InvoiceBatch> b)
		{
			b.ToTable("Invoice_Batches");
			b.HasKey(x => x.Id);

			b.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			b.Property(x => x.BillingMonth)
				.HasColumnName("billing_month")
				.HasMaxLength(7)
				.IsRequired();

			b.Property(x => x.TotalAmount)
				.HasColumnName("total_amount")
				.HasPrecision(15, 2)
				.IsRequired();

			b.Property(x => x.CreatedAt)
				.HasColumnName("created_at")
				.HasDefaultValueSql("now()")
				.IsRequired();

			b.Property(x => x.ApprovedAt)
				.HasColumnName("approved_at");

			b.Property(x => x.PreparedById)
				.HasColumnName("preparedBy")
				.IsRequired();
			b.HasOne(x => x.PreparedBy)
				.WithMany(pre => pre.PreparedByIds)
				.HasForeignKey(x => x.PreparedById)
				.OnDelete(DeleteBehavior.Cascade);

			b.Property(x => x.ApprovedById)
				.HasColumnName("approved_by");
			b.HasOne(x => x.ApprovedBy)
				.WithMany(app => app.ApprovedByIds)
				.HasForeignKey(x => x.ApprovedById)
				.OnDelete(DeleteBehavior.Cascade);

			b.Property(x => x.TenantId)
				.HasColumnName("tenant_id")
				.IsRequired();
			b.HasOne(x => x.Tenant)
				.WithMany(tenant => tenant.InvoiceBatches)
				.HasForeignKey(x => x.TenantId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
