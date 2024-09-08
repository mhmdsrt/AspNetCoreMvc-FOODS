using System.ComponentModel.DataAnnotations;

namespace AspNetCoreFood.Models
{
	public class Admin
	{
		[Key]
		public int AdminID { get; set; }

		[StringLength(20)]
		public string AdminUserName { get; set; }

		[StringLength(20)]
		public string AdminPassword { get; set; }

		[StringLength(1)]
		public string AdminRole { get; set; }
	}
}
