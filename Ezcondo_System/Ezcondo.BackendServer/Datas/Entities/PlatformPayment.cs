using Ezcondo.BackendServer.Datas.Enums;

namespace Ezcondo.BackendServer.Datas.Entities
{
	public class PlatformPayment
	{
		public Guid Id { get; set; }
		public decimal Amount { get; set; }
		//mã tham chiếu gửi đến VNPAY
		public string? VnpTxnRef { get; set; }
		//mã giao dịch VNPAY trả về
		public string? VnpTransactionNo { get; set; }
		public DateTime? PaymentDate { get; set; }
		public PaymentStatusEnum Status { get; set; }
		public DateTime CreatedAt { get; set; }
		public Guid TenantId { get; set; }
		public Tenant Tenant { get; set; }
		public Guid TenantLicenseId { get; set; }
		public TenantLicense TenantLicense { get; set; }
	}
}
