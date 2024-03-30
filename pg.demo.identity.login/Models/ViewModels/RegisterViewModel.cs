using pg.demo.identity.login.Models.CommonDefault;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace pg.demo.identity.login.Models.ViewModels
{
	public class RegisterViewModel
	{
		[DisplayName("Complete Name:")]
		[Required(ErrorMessage = Messages.Required)]
		[MaxLength(100, ErrorMessage = $"{Messages.MaxLeght} Must be 100")]
		[MinLength(5, ErrorMessage = $"{Messages.MinLeght} Must be 5")]
		public string Name { get; set; }

		[Required(ErrorMessage = Messages.Required)]
		public string Email { get; set; }

		[DisplayName("Confirm Email")]
		[Compare("Email", ErrorMessage = $"{Messages.MustBeEqual} 'Email'")]
		public string ConfirmEmail { get; set; }

		[DataType(DataType.Password)]
		[MaxLength(100, ErrorMessage = $"{Messages.MaxLeght} Must be 100")]
		[MinLength(5, ErrorMessage = $"{Messages.MinLeght} Must be 5")]
		public string Password { get; set; }

		[DisplayName("Confirm Password")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = $"{Messages.MustBeEqual} 'Password'")]
		public string ConfirmPassword { get;set; }
	}
}
