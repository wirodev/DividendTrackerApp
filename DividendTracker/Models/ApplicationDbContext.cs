using DividendTracker.Data;
using DividendTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace DividendTracker.Models
{
	public class ApplicationDbContext : DbContext
	{   
		// constructor
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		// tables
		public DbSet<Stock> Stocks { get; set; }
		public DbSet<Dividend> Dividends { get; set; }
		public DbSet<UserPortfolio> UserPortfolios { get; set; }

		// override the OnModelCreating method to configure the relationships between the tables
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserPortfolio>()
				.HasOne(up => up.Stock)
				.WithMany(s => s.UserPortfolios) 
				.HasForeignKey(up => up.Ticker); 

			modelBuilder.ApplyConfiguration(new StockConfiguration());
			modelBuilder.ApplyConfiguration(new DividendConfiguration());
			// add the other configs here for the otehr tables.
			base.OnModelCreating(modelBuilder);
		}

	}


}
