using Ezcondo.BackendServer.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class AdminAuthLogConfiguration : IEntityTypeConfiguration<AdminAuthLog>
	{
		public void Configure(EntityTypeBuilder<AdminAuthLog> builder)
		{
			builder.ToTable("Admin_Auth_Logs");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			builder.Property(x => x.IpAddress)
				.HasColumnName("ip_address")
				.HasMaxLength(50);

			builder.Property(x => x.UserAgent)
				.HasColumnName("user_agent");

			builder.Property(x => x.LoginAt)
				.HasColumnName("login_at")
				.HasDefaultValueSql("now()")
				.IsRequired();

			builder.Property(x => x.AdminId)
				.HasColumnName("admin_id")
				.IsRequired();
			builder.HasOne(x => x.Admin)
				.WithMany(admin => admin.AdminAuthLogs)
				.HasForeignKey(x => x.AdminId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
