using Ezcondo.BackendServer.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class PeriodReportConfiguration : IEntityTypeConfiguration<PeriodicReport>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PeriodicReport> b)
		{
			b.ToTable("Periodic_Reports");
			b.HasKey(x => x.Id);

			b.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			b.Property(x => x.ReportPeriod)
				.HasColumnName("report_period")
				.IsRequired();

			b.Property(x => x.ReportType)
				.HasColumnName("report_type")
				.IsRequired();

			b.Property(x => x.AttachedFileUrl)
				.HasColumnName("attached_file_url")
				.HasMaxLength(500);

			b.Property(x => x.Status)
				.HasColumnName("status")
				.IsRequired();

			b.Property(x => x.CreatedAt)
				.HasColumnName("created_at")
				.IsRequired();

			b.Property(x => x.ReviewedAt)
				.HasColumnName("reviewed_at");

			b.Property(x => x.PreparedBy)
				.HasColumnName("prepared_by")
				.IsRequired();
			b.HasOne(x => x.User)
				.WithMany(user => user.PeriodReports)
				.HasForeignKey(x => x.PreparedBy)
				.OnDelete(DeleteBehavior.Restrict);

			b.Property(x => x.TenantId)
				.HasColumnName("tenant_id")
				.IsRequired();
			b.HasOne(x => x.Tenant)
				.WithMany(tenant => tenant.PeriodicReport)
				.HasForeignKey(x => x.TenantId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
