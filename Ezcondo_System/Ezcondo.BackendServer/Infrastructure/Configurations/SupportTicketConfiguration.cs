using Ezcondo.BackendServer.Datas.Entities;
using Ezcondo.BackendServer.Datas.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class SupportTicketConfiguration : IEntityTypeConfiguration<SupportTicket>
	{
		public void Configure(EntityTypeBuilder<SupportTicket> builder)
		{
			builder.ToTable("Support_Tickets");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			builder.Property(x => x.Description)
				.HasColumnName("description")
				.IsRequired();

			builder.Property(x => x.Status)
				.HasColumnName("status")
				.HasDefaultValue(TicketStatusEnum.OPEN)
				.IsRequired();

			builder.Property(x => x.IssueCategory)
				.HasColumnName("issue_category")
				.IsRequired();

			builder.Property(x => x.CreatedAt)
				.HasColumnName("created_at")
				.HasDefaultValueSql("now()")
				.IsRequired();

			builder.Property(x => x.ResolvedAt)
				.HasColumnName("resolved_at");

			builder.Property(x => x.TenantId)
				.HasColumnName("tenant_id")
				.IsRequired();
			builder.HasOne(x => x.Tenant)
				.WithMany(tenant => tenant.SupportTickets)
				.HasForeignKey(x => x.TenantId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
