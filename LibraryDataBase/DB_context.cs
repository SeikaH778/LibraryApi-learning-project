using LibraryDataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
namespace LibraryDataBase
{
    public class DB_context: DbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        public DB_context() { }
        readonly string ConnectionString = "Data Source=C:\\Users\\SeikaH\\Desktop\\LibraryDB.db";
        public DB_context(DbContextOptions<DB_context> options)
       : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(b=>b.Author).WithMany(a=>a.Books).HasForeignKey(b=>b.AuthorId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
