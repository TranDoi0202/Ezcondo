using Ezcondo.BackendServer.Datas.Entities;
using Ezcondo.BackendServer.Datas.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ezcondo.BackendServer.Datas
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			//Ánh xạ Cs enums sang PostgreSQL enum
			builder.HasPostgresEnum<RoleScopeEnum>("role_scope_enum");
			builder.HasPostgresEnum<RoleNameEnum>("role_name_enum");
			builder.HasPostgresEnum<BillingCycleEnum>("billing_cycle_enum");
			builder.HasPostgresEnum<TenantStatusEnum>("tenant_status_enum");
			builder.HasPostgresEnum<LicenseStatusEnum>("license_status_enum");
			builder.HasPostgresEnum<PaymentStatusEnum>("payment_status_enum");
			builder.HasPostgresEnum<IssueSeverityEnum>("issue_severity_enum");
			builder.HasPostgresEnum<IssueStatusEnum>("issue_status_enum");
			builder.HasPostgresEnum<UserStatusEnum>("user_status_enum");
			builder.HasPostgresEnum<TicketStatusEnum>("ticket_status_enum");
			builder.HasPostgresEnum<TicketCategoryEnum>("ticket_category_enum");
			builder.HasPostgresEnum<ReportPeriodEnum>("report_period_enum");
			builder.HasPostgresEnum<ReportStatusEnum>("report_status_enum");
			builder.HasPostgresEnum<ReportTypeEnum>("report_type_enum");

			//Tự động quét assembly và tự động nạp các Configuration của entities
			builder.ApplyConfigurationsFromAssembly(
				typeof(ApplicationDbContext)
				.Assembly
			);

		}
	}
}
