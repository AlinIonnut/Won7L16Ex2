using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Won7L16E2.Models;

namespace Won7L16E2.Data
{
    internal class CarDbContext:DbContext
    {
        private const string DbUrl = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\FastTrackIT\Cursuri\Cursul 16\Won7L16E2\CarsDb.mdf"";Integrated Security=True";
        public DbSet<Car> Cars { get; set; }

        public CarDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(DbUrl);
        }
    }
}
