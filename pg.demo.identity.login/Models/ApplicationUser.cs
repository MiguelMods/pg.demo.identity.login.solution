using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace pg.demo.identity.login.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required, StringLength(100), MaxLength(100)]
		public string? Name { get; set; }
		[Required, StringLength(100), MaxLength(100)]
		public string? NickName { get; set; }
	}
}
