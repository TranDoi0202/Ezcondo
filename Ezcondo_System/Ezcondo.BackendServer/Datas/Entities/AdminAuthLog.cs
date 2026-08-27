namespace Ezcondo.BackendServer.Datas.Entities
{
	public class AdminAuthLog
	{
		public Guid Id { get; set; }
		public string? IpAddress { get; set; }
		public string? UserAgent { get; set; }
		public DateTime LoginAt { get; set; }
		public Guid AdminId { get; set; }
		public User Admin {  get; set; }
	}
}
