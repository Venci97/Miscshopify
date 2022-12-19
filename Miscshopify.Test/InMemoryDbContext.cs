using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Miscshopify.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Test
{
	public class InMemoryDbContext
	{
		private readonly SqliteConnection connection;
		private readonly DbContextOptions<MiscshopifyContext> dbContextOptions;

		public InMemoryDbContext()
		{
			connection = new SqliteConnection("Filename=:memory:");
			connection.Open();

			dbContextOptions = new DbContextOptionsBuilder<MiscshopifyContext>()
				.UseSqlite(connection)
				.Options;

			using var context = new MiscshopifyContext(dbContextOptions);

			context.Database.EnsureCreated();
		}

		public MiscshopifyContext CreateContext() => new MiscshopifyContext(dbContextOptions);

		public void Dispose() => connection.Dispose();
	}
}
