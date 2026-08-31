using Ezcondo.BackendServer.Datas.Entities;
using Ezcondo.BackendServer.Datas.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class SystemIssueConfiguration : IEntityTypeConfiguration<SystemIssue>
	{
		public void Configure(EntityTypeBuilder<SystemIssue> builder)
		{
			builder.ToTable("System_Issues");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			builder.Property(x => x.Description)
				.HasColumnName("description");

			builder.Property(x => x.Title)
				.HasColumnName("title")
				.HasMaxLength(255)
				.IsRequired();

			builder.Property(x => x.Severity)
				.HasColumnName("severity")
				.IsRequired();

			builder.Property(x => x.Status)
				.HasColumnName("status")
				.HasDefaultValue(IssueStatusEnum.OPEN)
				.IsRequired();

			builder.Property(x => x.ReportedAt)
				.HasColumnName("reported_at")
				.HasDefaultValueSql("now()")
				.IsRequired();

			builder.Property(x => x.ResolvedAt)
				.HasColumnName("resolved_at");

			builder.Property(x => x.TenantId)
				.HasColumnName("tenant_id");
			builder.HasOne(x => x.Tenant)
				.WithMany(tenant => tenant.SystemIssues)
				.HasForeignKey(x => x.TenantId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
