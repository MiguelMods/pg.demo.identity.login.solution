using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pg.demo.identity.login.Models;

namespace pg.demo.identity.login.Data
{
	public class AppDataContext(DbContextOptions<AppDataContext> options) : IdentityDbContext<ApplicationUser>(options)
	{
	}
}
