using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<LecGroup> LecGroups { get; set; } = null!;
        public DbSet<Homework> Homeworks { get; set; } = null!;
        public DbSet<Lection> Lections { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<VisitJournal> VisitJournals { get; set; } = null!;



        public ApplicationContext()
        {
            Database.EnsureDeleted(); //удаление существующей бд в файле
            Database.EnsureCreated(); //создание бд
        }
        //конфигурация (пока просто добавление альт. ключей)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homework>().HasAlternateKey(u => new { u.Lection });
            modelBuilder.Entity<Lection>().HasAlternateKey(u => new { u.Teacher });
            modelBuilder.Entity<VisitJournal>().HasAlternateKey(u => new { u.Student, u.Lection });
            modelBuilder.Entity<Student>().HasAlternateKey(u => new { u.LecGroup });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db"); // подключение к бд
        }
    }
}
