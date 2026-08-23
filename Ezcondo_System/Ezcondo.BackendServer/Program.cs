using Ezcondo.BackendServer.Datas;
using Ezcondo.BackendServer.Datas.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
						.GetConnectionString("DefaultConnection");


//cấu hình Data Source cho enums
var dataSourceBulder = new NpgsqlDataSourceBuilder(
	builder
	.Configuration
	.GetConnectionString(connectionString)
);

//bật tính năng jsonb
dataSourceBulder.EnableDynamicJson();

//Map enums vào data source
dataSourceBulder.MapEnum<RoleScopeEnum>("role_scope_enum");
dataSourceBulder.MapEnum<RoleNameEnum>("role_name_enum");
dataSourceBulder.MapEnum<BillingCycleEnum>("billing_cycle_enum");
dataSourceBulder.MapEnum<TenantStatusEnum>("tenant_status_enum");
dataSourceBulder.MapEnum<LicenseStatusEnum>("license_status_enum");
dataSourceBulder.MapEnum<PaymentStatusEnum>("payment_status_enum");
dataSourceBulder.MapEnum<IssueSeverityEnum>("issue_severity_enum");
dataSourceBulder.MapEnum<IssueStatusEnum>("issue_status_enum");
dataSourceBulder.MapEnum<UserStatusEnum>("user_status_enum");
dataSourceBulder.MapEnum<TicketStatusEnum>("ticket_status_enum");
dataSourceBulder.MapEnum<TicketCategoryEnum>("ticket_category_enum");
dataSourceBulder.MapEnum<ReportPeriodEnum>("report_period_enum");
dataSourceBulder.MapEnum<ReportStatusEnum>("report_status_enum");
dataSourceBulder.MapEnum<ReportTypeEnum>("report_type_enum");

var dataSource = dataSourceBulder.Build();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseNpgsql(dataSource)
);



//=====

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
