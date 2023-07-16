using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG_2020_4068_Desktop_UI
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        private readonly string _path = @"E:\EG_2020_4068_Desktop_UI\EG_2020_4068_Desktop_UI\persons.db";
        protected override void
            OnConfiguring(DbContextOptionsBuilder optionBuilder)
            => optionBuilder.UseSqlite($"Data Source={_path}");
    }
}
