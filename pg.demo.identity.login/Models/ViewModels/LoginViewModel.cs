using pg.demo.identity.login.Models.CommonDefault;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace pg.demo.identity.login.Models.ViewModels
{
	public class LoginViewModel
	{
		[DisplayName("UserName/Nickname:")]
		[Required(ErrorMessage = Messages.Required)]
		[MinLength(6, ErrorMessage = $"{Messages.MinLeght} Must By 6")]
		public string UserName { get; set; }

		[DisplayName("Password:")]
		[Required(ErrorMessage = Messages.Required)]
		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = $"{Messages.MinLeght} Must By 6")]
		public string Password { get; set; }

		[DisplayName("Please Remember Me:")]
		public bool RememberMe { get; set; }
	}
}
