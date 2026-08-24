using Ezcondo.BackendServer.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ezcondo.BackendServer.Infrastructure.Configurations
{
	public class LicencsePackageConfiguration : IEntityTypeConfiguration<LicensePackage>
	{
		public void Configure(EntityTypeBuilder<LicensePackage> builder)
		{
			builder.ToTable("License_Packages");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnName("id")
				.HasDefaultValueSql("gen_random_uuid()");

			builder.Property(x => x.PackageName)
				.HasColumnName("package_name")
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(x => x.Price)
				.HasColumnName("price")
				.HasPrecision(15, 2)
				.IsRequired();

			builder.Property(x => x.BillingCycle)
				.HasColumnName("billing_cycle")
				.IsRequired();

			builder.Property(x => x.Feature)
				.HasColumnName("feature")
				.HasDefaultValueSql("'{}'::jsonb")
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
		}
	}
}
