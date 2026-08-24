using Ezcondo.BackendServer.Datas.Entities;
using Ezcondo.BackendServer.Datas.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class TenantLicenseConfiguration : IEntityTypeConfiguration<TenantLicense>
	{
		public void Configure(EntityTypeBuilder<TenantLicense> builder)
		{
			builder.ToTable("Tenant_Licenses");

			builder.HasKey("Id");
			builder.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			builder.Property(x => x.ContractNumber)
				.HasColumnName("contract_number")
				.HasMaxLength(100)
				.IsRequired();
			builder.HasIndex(x => x.ContractNumber)
				.IsUnique();

			builder.Property(x => x.StartDate)
				.HasColumnName("start_date")
				.IsRequired();

			builder.Property(x => x.EndDate)
				.HasColumnName("end_date")
				.IsRequired();

			builder.Property(x => x.Status)
				.HasColumnName("status")
				.HasDefaultValue(LicenseStatusEnum.ACTIVE)
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

			builder.Property(x => x.TenantId) //khóa ngoại
				.HasColumnName("tenant_id")
				.IsRequired();

			builder.HasOne(x => x.Tenant)
				.WithMany(tenant => tenant.Licenses)
				.HasForeignKey(x => x.TenantId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.LicensePackageId) //Khóa ngoại
				.HasColumnName("license_package_id")
				.IsRequired();

			builder.HasOne(x => x.LicensePackage)
				.WithMany()
				.HasForeignKey(x => x.LicensePackageId)
				.OnDelete(DeleteBehavior.Restrict);


			//ràng buộc check
			builder.HasCheckConstraint("chk_license_dates", "end_date > start_date");
		}
	}
}
