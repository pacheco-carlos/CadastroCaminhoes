using CadsatroCaminhoes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadsatroCaminhoes.Data
{
	public class ApplicationDbContext :DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Caminhao> Caminhoes { get; set; }
	}
}
