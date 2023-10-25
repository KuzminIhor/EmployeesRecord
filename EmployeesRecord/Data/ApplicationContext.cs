using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;

namespace EmployeesRecord.Data
{
	public class ApplicationContext : DbContext
	{
		private static ApplicationContext _context;

		public DbSet<Employee?> Employees { get; set; }
		public DbSet<Position> Positions { get; set; }

		private ApplicationContext()
        {
			Database.EnsureCreated();
		}

		public static ApplicationContext GetInstance()
		{
			if (_context == null)
			{
				_context = new ApplicationContext();
			}

			return _context;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EmployeesRecordsDB;Trusted_Connection=True;");
		}

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);

            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter, DateOnlyComparer>()
                .HaveColumnType("date");
        }
    }

    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
        { }
    }

    public class DateOnlyComparer : ValueComparer<DateOnly>
    {
        public DateOnlyComparer() : base(
            (x, y) => x.DayNumber == y.DayNumber,
            dateOnly => dateOnly.GetHashCode())
        { }
    }
}
